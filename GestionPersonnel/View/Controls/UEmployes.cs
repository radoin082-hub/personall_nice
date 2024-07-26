using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms.Helpers.Transitions;
using GestionPersonnel.Models.Employees;
using GestionPersonnel.Models.Fonctions;
using GestionPersonnel.Properties;
using GestionPersonnel.Storages.EmployeesStorages;
using GestionPersonnel.Storages.FonctionsStorages;
using Guna.UI2.WinForms;
using Microsoft.Extensions.Configuration;

namespace GestionPersonnel.View
{
    public partial class UEmployes : UserControl
    {
        private readonly EmployeStorage _employeStorage;
        private readonly FonctionStorage _fonctionStorage;
        private List<Employee> _allEmployees;
        private byte[] photo;
        private int? editingEmployeeId = null;
        private int? editingFunctionId = null; 
        private Dictionary<int, string> _fonctionsDictionary;
        private readonly string _connectionString;
        public UEmployes(string connectionString)
        {
            _connectionString = connectionString;
            InitializeComponent();
            _employeStorage = new EmployeStorage(connectionString);
            _fonctionStorage = new FonctionStorage(connectionString);
            Load += UEmployes_Load;
            guna2TextBox1.TextChanged += guna2TextBox1_TextChanged;
            guna2DataGridView1.CellFormatting += guna2DataGridView1_CellFormatting;
            guna2DataGridView1.CellClick += Guna2DataGridView1_CellClick;
            guna2Button3.Click += guna2Button3_Click;
        }

        private void InitializeDataGridView()
        {

        }

        private void Guna2DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && (guna2DataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn))
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);

                DataGridViewButtonColumn buttonColumn = (DataGridViewButtonColumn)guna2DataGridView1.Columns[e.ColumnIndex];
                Image icon = buttonColumn.Tag as Image;

                if (icon != null)
                {
                    int iconWidth = 24; // Adjust as needed
                    int iconHeight = 24; // Adjust as needed
                    int iconX = e.CellBounds.X + (e.CellBounds.Width - iconWidth) / 2;
                    int iconY = e.CellBounds.Y + (e.CellBounds.Height - iconHeight) / 2;

                    e.Graphics.DrawImage(icon, new Rectangle(iconX, iconY, iconWidth, iconHeight));
                }

                using (Pen pen = new Pen(guna2DataGridView1.GridColor, -4))
                {
                    e.Graphics.DrawRectangle(pen, e.CellBounds);
                }

                e.Handled = true;
            }
        }

        private void guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (!guna2DataGridView1.Rows[e.RowIndex].IsNewRow)
                {
                    e.CellStyle.Font = new Font(guna2DataGridView1.Font.FontFamily, 13);
                }
            }
        }

        private async Task LoadEmployees()
        {
            try
            {
                _allEmployees = await _employeStorage.GetAll();
                _allEmployees = _allEmployees
                    .Where(emp => emp != null &&
                                  !string.IsNullOrEmpty(emp.Nom) &&
                                  !string.IsNullOrEmpty(emp.Prenom) &&
                                  !string.IsNullOrEmpty(emp.NSecuriteSocial))
                    .ToList();

                UpdateDataGridView(_allEmployees);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the employees: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDataGridView(List<Employee> employees)
        {
            guna2DataGridView1.Rows.Clear();
            int count=0;
            foreach (var employee in employees)
            {
                count++;
                if (employee != null &&

                    !string.IsNullOrEmpty(employee.Nom) &&
                    !string.IsNullOrEmpty(employee.Prenom) &&
                    !string.IsNullOrEmpty(employee.NSecuriteSocial))
                {
                    string fonctionName = _fonctionsDictionary != null && _fonctionsDictionary.ContainsKey(employee.FonctionID)
                                          ? _fonctionsDictionary[employee.FonctionID]
                                          : "Unknown";

                    guna2DataGridView1.Rows.Add(count,employee.Nom, employee.Prenom, employee.NSecuriteSocial, fonctionName);
                }
            }
        }

        private async void UEmployes_Load(object sender, EventArgs e)
        {
            InitializeDataGridView();
            await LoadFonctionsData();
            await LoadEmployees();
        }

        private void search(object sender, EventArgs e)
        {
            string searchQuery = guna2TextBox1.Text.ToLower();
            var filteredEmployees = _allEmployees
                .Where(emp => emp.Nom.ToLower().Contains(searchQuery) || emp.Prenom.ToLower().Contains(searchQuery)
                || emp.NSecuriteSocial.ToLower().Contains(searchQuery) || emp.FonctionID.ToString().ToLower().Contains(searchQuery)
                || (_fonctionsDictionary != null && _fonctionsDictionary.ContainsKey(emp.FonctionID)
                    && _fonctionsDictionary[emp.FonctionID].ToLower().Contains(searchQuery)))
                .ToList();
            UpdateDataGridView(filteredEmployees);
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            search(sender, e);
        }

        private void Guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.RowIndex >= _allEmployees.Count)
            {
                return;
            }

            var selectedEmployee = _allEmployees[e.RowIndex];
            if (guna2DataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "ModifierColumn")
                {
                    editingEmployeeId = selectedEmployee.EmployeID;
                    PopulateEmployeeDetails(selectedEmployee);
                    panelajouteremploye.Visible = true;
                }
                else if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "SupprimerColumn")
                {
                    DeleteEmployee(selectedEmployee.EmployeID);
                }
            }
        }

        private async void DeleteEmployee(int employeeId)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this employee?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {    
                    await _employeStorage.Delete(employeeId);
                    MessageBox.Show("Employee deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadEmployees();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateEmployeeDetails(Employee employee)
        {
            nomEmployes.Text = employee.Nom;
            prenomEmployes.Text = employee.Prenom;
            DateNaissanceEmployes.Value = employee.DateDeNaissance;
            NSecuriteSocialeEmployes.Text = employee.NSecuriteSocial;
            AdresseEmployes.Text = employee.Adresse;
            NTelephoneEmployes.Text = employee.NTelephone;
            SituationFamilialeEmployes.Text = employee.SitiationFamiliale;
            GroupeSanguinEmployes.Text = employee.GroupSanguin;

            if (_fonctionsDictionary != null && _fonctionsDictionary.ContainsKey(employee.FonctionID))
            {
                FonctionEmployes.Text = _fonctionsDictionary[employee.FonctionID];
            }
            else
            {
                FonctionEmployes.Text = "Unknown";
            }

            DateEntrerEmployes.Value = employee.DateEntree;
            if (employee.Photo != null)
            {
                using (var ms = new MemoryStream(employee.Photo))
                {
                    photoProfileEmployes.Image = Image.FromStream(ms);
                }
            }
            else
            {
                photoProfileEmployes.Image = null;
            }
            photo = employee.Photo;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panelajouteremploye.Visible = false;
            ClearInputFields();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            panelajouteremploye.Visible = true;
            panelajouterfonction.Visible = false;
            ClearInputFields();
        }

        private void photoProfileBtn_Click_1(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog
                {
                    Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.svg"
                };

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = dialog.FileName;
                    photoProfileEmployes.Image = new Bitmap(filePath);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        Image image = Image.FromFile(filePath);
                        image.Save(ms, image.RawFormat);
                        photo = ms.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while selecting the photo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ajouteremploye_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(nomEmployes.Text) || string.IsNullOrEmpty(prenomEmployes.Text) ||
                    string.IsNullOrEmpty(NSecuriteSocialeEmployes.Text) || string.IsNullOrEmpty(AdresseEmployes.Text) ||
                    string.IsNullOrEmpty(NTelephoneEmployes.Text) || string.IsNullOrEmpty(SituationFamilialeEmployes.Text) ||
                    string.IsNullOrEmpty(GroupeSanguinEmployes.Text) || FonctionEmployes.SelectedValue == null ||
                    DateEntrerEmployes.Value == null || photo == null)
                {
                    MessageBox.Show("Entrer les informations manquantes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int fonctionId = (int)FonctionEmployes.SelectedValue;
                Employee employee = new Employee
                {
                    Nom = nomEmployes.Text,
                    Prenom = prenomEmployes.Text,
                    DateDeNaissance = DateNaissanceEmployes.Value,
                    NSecuriteSocial = NSecuriteSocialeEmployes.Text,
                    Adresse = AdresseEmployes.Text,
                    NTelephone = NTelephoneEmployes.Text,
                    SitiationFamiliale = SituationFamilialeEmployes.Text,
                    GroupSanguin = GroupeSanguinEmployes.Text,
                    FonctionID = fonctionId, 
                    DateEntree = DateEntrerEmployes.Value,
                    DateSortie = null,
                    Photo = photo
                };

                if (editingEmployeeId.HasValue)
                {
                    employee.EmployeID = editingEmployeeId.Value;
                    await _employeStorage.Update(employee);
                    MessageBox.Show("L'employé a été mis à jour avec succès", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    editingEmployeeId = null;

                }
                else
                {
                    await _employeStorage.Add(employee);
                    MessageBox.Show("Un employé a été ajouté avec succès", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                await LoadEmployees();
                panelajouteremploye.Visible = false;
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding/updating the employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ClearInputFields()
        {
            nomEmployes.Clear();
            prenomEmployes.Clear();
            NSecuriteSocialeEmployes.Clear();
            AdresseEmployes.Clear();
            NTelephoneEmployes.Clear();
            SituationFamilialeEmployes.SelectedIndex = -1;
            GroupeSanguinEmployes.SelectedIndex = -1;
            FonctionEmployes.SelectedIndex = -1;
            DateNaissanceEmployes.Value = DateTime.Now;
            DateEntrerEmployes.Value = DateTime.Now;
            photoProfileEmployes.Image = null;
            photo = null;
            editingEmployeeId = null;
        }

        private void reste(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private async Task LoadFonctions()
        {
            try
            {
                var fonctions = await _fonctionStorage.GetAll();
                _fonctionsDictionary = fonctions.ToDictionary(f => f.FonctionID, f => f.NomFonction);
                FonctionEmployes.DataSource = fonctions;
                FonctionEmployes.DisplayMember = "NomFonction";
                FonctionEmployes.ValueMember = "FonctionID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading functions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadFonctionsData()
        {
            try
            {
                var fonctions = await _fonctionStorage.GetAll();

                if (fonctions == null)
                {
                    MessageBox.Show("Failed to load functions. The returned list is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _fonctionsDictionary = fonctions.ToDictionary(f => f.FonctionID, f => f.NomFonction);

                if (_fonctionsDictionary == null || _fonctionsDictionary.Count == 0)
                {
                    MessageBox.Show("Failed to load functions. The dictionary is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FonctionEmployes.DataSource = fonctions;
                FonctionEmployes.DisplayMember = "NomFonction";
                FonctionEmployes.ValueMember = "FonctionID";
                display_function.DataSource = fonctions;
                display_function.DisplayMember = "NomFonction";
                display_function.ValueMember = "FonctionID";
                FonctionEmployes.SelectedIndex = -1;
                display_function.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading functions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            panelajouterfonction.Visible = true;
            panelajouteremploye.Visible = false;
            ClearInputFields();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panelajouterfonction.Visible = false;
            ClearInputFields();
            modifier_fuction.Clear();
            addfonction.Clear();
            display_function.SelectedItem = -1;

        }

        private async void guna2Button4_Click(object sender, EventArgs e)
        {
            string nomFonction = addfonction.Text;

            if (string.IsNullOrEmpty(nomFonction))
            {
                MessageBox.Show("Please enter a function name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (editingFunctionId.HasValue)
                {
                    var functionToUpdate = await _fonctionStorage.GetById(editingFunctionId.Value);
                    functionToUpdate.NomFonction = nomFonction;
                    await _fonctionStorage.Update(functionToUpdate);
                    MessageBox.Show("Function updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    editingFunctionId = null;
                }
                else
                {
                    Fonction newFonction = new Fonction { NomFonction = nomFonction };
                    await _fonctionStorage.Add(newFonction);
                    MessageBox.Show("Function added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                addfonction.Clear();
                await LoadFonctionsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding/updating the function: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void guna2Button3_Click(object sender, EventArgs e)
        {
            if (display_function.SelectedItem is Fonction selectedFunction)
            {
                try
                {
                    await _fonctionStorage.Delete(selectedFunction.FonctionID);
                    MessageBox.Show("Function deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadFonctionsData();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while deleting the function: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a function to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        public async Task RefreshData()
        {
            await LoadEmployees();
        }

        private void labelNom_Click(object sender, EventArgs e) { }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e) { }

        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { }

        private void FonctionEmployes_SelectedIndexChanged(object sender, EventArgs e) { }

        private void photoProfileEmployes_Click(object sender, EventArgs e) { }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void labelPrenom_Click(object sender, EventArgs e) { }

        private void NSecuriteSocialeEmployes_TextChanged(object sender, EventArgs e) { }

        private void labelDateEntrer_Click(object sender, EventArgs e) { }

        private void AdresseEmployes_TextChanged(object sender, EventArgs e) { }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e) { }

        private void UEmployes_Load_1(object sender, EventArgs e) { }

        private void labelDateNaissance_Click(object sender, EventArgs e) { }

        private void GroupeSanguinEmployes_SelectedIndexChanged(object sender, EventArgs e) { }

        private void photoProfileEmployes_Click_1(object sender, EventArgs e) { }

        private void label7_Click(object sender, EventArgs e) { }

        private void guna2DataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e) { }

        private void label2_Click(object sender, EventArgs e) { }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e) { }

        private void label4_Click(object sender, EventArgs e) { }

        private void guna2DataGridView1_CellContentClick_3(object sender, DataGridViewCellEventArgs e) { }

        private void guna2Button5_Click(object sender, EventArgs e) { }

        private async void ModifierFunction_Click(object sender, EventArgs e)
        {
            try
            {
                if (display_function.SelectedItem != null)
                {
                    var selectedFunction = (Fonction)display_function.SelectedItem;
                    selectedFunction.NomFonction = modifier_fuction.Text; 
                    await _fonctionStorage.Update(selectedFunction);

                    MessageBox.Show("Function updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panelajouterfonction.Visible = false;
                    panelajouteremploye.Visible = true;

                    await LoadFonctionsData();
                }
                else
                {
                    MessageBox.Show("Please select a function to modify.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void display_function_SelectedIndexChanged(object sender, EventArgs e)
        {   modifier_fuction.Clear();
            display_function.SelectedItem = -1;
            if (display_function.SelectedItem != null)
            {
                // Assuming SelectedItem is of type Fonction
                Fonction selectedFonction = display_function.SelectedItem as Fonction;
                if (selectedFonction != null)
                {
                    modifier_fuction.Text = selectedFonction.NomFonction;
                }
            }
            
        }



    }
}
