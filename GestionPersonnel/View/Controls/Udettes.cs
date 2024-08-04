using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionPersonnel.Models.Dettes;
using GestionPersonnel.Storages.DettesStorages;
using GestionPersonnel.Models.Avances;
using GestionPersonnel.Models.Employees;
using GestionPersonnel.Storages.AvancesStorages;
using GestionPersonnel.Storages.EmployeesStorages;
using GestionPersonnel.Storages.SalairesStorages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionPersonnel.View.Controls
{
    public partial class Udettes : UserControl
    {
        private readonly DetteStorage _dettesStorage;
        private readonly AvanceStorage _avancesStorage;
        private readonly EmployeStorage _employeeStorage;
        private readonly SalaireStorage _SalaireStorage;

        public Udettes(string connectionString)
        {
            _dettesStorage = new DetteStorage(connectionString);
            _avancesStorage = new AvanceStorage(connectionString);
            _employeeStorage = new EmployeStorage(connectionString);
            _SalaireStorage = new SalaireStorage(connectionString);

            InitializeComponent();
            palenHistoriqueAetD.Visible = false;
        }

        private async void Udettes_Load(object sender, EventArgs e)
        {
            await LoadDebtDetails();
            await LoadEmployees();
        }
        private void showiconedit(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && (DettesGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn))
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);

                DataGridViewButtonColumn buttonColumn = (DataGridViewButtonColumn)DettesGrid.Columns[e.ColumnIndex];
                Image icon = buttonColumn.Tag as Image;

                if (icon != null)
                {
                    int iconWidth = 30;
                    int iconHeight = 30;
                    int iconX = e.CellBounds.X + (e.CellBounds.Width - iconWidth) / 2;
                    int iconY = e.CellBounds.Y + (e.CellBounds.Height - iconHeight) / 2;

                    e.Graphics.DrawImage(icon, new Rectangle(iconX, iconY, iconWidth, iconHeight));
                }

                using (Pen pen = new Pen(DettesGrid.GridColor, 0))
                {
                    e.Graphics.DrawRectangle(pen, e.CellBounds);
                }

                e.Handled = true;
            }
        }

        private async Task LoadDebtDetails()
        {
            try
            {
                var paimentsInfos = await _dettesStorage.GetEmployeeDebtDetails();
                UpdateDataGridView(paimentsInfos);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite lors du chargement des détails de la dette: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadEmployees()
        {
            try
            {
                var employees = await _employeeStorage.GetAll();
                guna2ComboBox1.DataSource = employees;
                guna2ComboBox1.DisplayMember = "FullName";
                guna2ComboBox1.ValueMember = "EmployeID";
                guna2ComboBox1.SelectedIndex = -1;
                guna2ComboBox2.DataSource = employees;
                guna2ComboBox2.DisplayMember = "FullName";
                guna2ComboBox2.ValueMember = "EmployeID";
                guna2ComboBox2.SelectedIndex = -1;
                guna2ComboBox3.DataSource = employees;
                guna2ComboBox3.DisplayMember = "FullName";
                guna2ComboBox3.ValueMember = "EmployeID";
                guna2ComboBox3.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite lors du chargement des employés: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDataGridView(List<PaimentsInfo> paimentsInfos)
        {
            DettesGrid.Rows.Clear();
            int i = 0;
            foreach (var paiment in paimentsInfos)
            {
                i++;
                var row = new DataGridViewRow();
                row.CreateCells(DettesGrid);
                row.SetValues(i, paiment.Nom, paiment.Prenom, paiment.NomFonction, paiment.TotaleDette, paiment.MontantRetrait, paiment.TotaleAvances, paiment.EmployeID);
                row.Tag = paiment.EmployeID;
                DettesGrid.Rows.Add(row);

            }
        }


        private void DettesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panelDetteAvance.Visible = false;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            panelDetteAvance.Visible = true;
            panelMontant.Visible = false;
        }
        //Avance Add
        private async void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(guna2TextBox1.Text))
                {
                    MessageBox.Show("Veuillez saisir un montant de dette ou d'avance valide.", "erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(guna2TextBox1.Text))
                {
                    if (!decimal.TryParse(guna2TextBox1.Text, out decimal montantAvance))
                    {
                        MessageBox.Show("Veuillez saisir une valeur numérique valide pour le montant de l'avance.", "erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int employeeIdForAvance = (int)guna2ComboBox2.SelectedValue;

                    var avance = new Avance
                    {
                        EmployeID = employeeIdForAvance,
                        Montant = montantAvance,
                        Date = DateTime.Now
                    };
                    await _avancesStorage.Add(avance);
                }

                MessageBox.Show("Avance ajoutées avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDebtDetails();
            }
            catch (FormatException)
            {
                MessageBox.Show("Veuillez saisir des valeurs numériques valides pour les montants des avances.", "Erreur d'entrée", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est programm lors de l'ajout de l'avance: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Dette Add
        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(guna2TextBox2.Text))
                {
                    MessageBox.Show("Veuillez saisir un montant de dette ou d'avance valide.", "erreur de validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(guna2TextBox2.Text))
                {
                    if (!decimal.TryParse(guna2TextBox2.Text, out decimal montantDette))
                    {
                        MessageBox.Show("Veuillez saisir une valeur numérique valide pour le montant de la Dette.",
                            "erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int employeeIdForDette = (int)guna2ComboBox1.SelectedValue;

                    var dette = new Dette
                    {
                        EmployeID = employeeIdForDette,
                        Montant = montantDette,
                        Date = DateTime.Now
                    };
                    await _dettesStorage.Add(dette);
                }
                MessageBox.Show("Dette ajoutées avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDebtDetails();
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Veuillez saisir des valeurs numériques valides pour les montants des dettes et des avances.",
                    "Erreur d'entrée", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est programm lors de l'ajout de la dette et de l'avance: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private async void DettesGrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == DettesGrid.Columns["ModifierColumn"].Index)
            {
                try
                {

                    var row = DettesGrid.Rows[e.RowIndex];
                    int employeID = (int)row.Tag;


                    palenHistoriqueAetD.Visible = true;

                    await DisplayEmployeeDebtAndAdvances(employeID);

                    var employee = await _employeeStorage.GetById(employeID);
                    if (employee != null)
                    {
                        label11.Text = employee.Nom;
                        label12.Text = employee.Prenom;
                    }
                    else
                    {
                        MessageBox.Show("Employee details not found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error in DettesGrid_CellContentClick_1: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private async Task DisplayEmployeeDebtAndAdvances(int employeID)
        {
            try
            {
                var debts = await _dettesStorage.GetByEmployeId(employeID);
                var avances = await _avancesStorage.GetByEmployeId(employeID);

                if (guna2DataGridView1 == null || guna2DataGridView2 == null)
                {
                    MessageBox.Show("DataGridView controls are not initialized.", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                guna2DataGridView1.Rows.Clear();
                guna2DataGridView2.Rows.Clear();
                int countDettes = 0;
                foreach (var debt in debts)
                {
                    countDettes++;
                    guna2DataGridView1.Rows.Add(countDettes, debt.Montant, debt.Date);
                }
                int countAvance = 0;
                foreach (var avanc in avances)
                {
                    countAvance++;
                    guna2DataGridView2.Rows.Add(countAvance, avanc.Montant, avanc.Date);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite lors du chargement des dettes et des avances: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            panelDetteAvance.Visible = false;
            panelMontant.Visible = true;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            panelMontant.Visible = false;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            palenHistoriqueAetD.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DettesSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelMontant_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(guna2TextBox3.Text))
                {
                    MessageBox.Show("Veuillez saisir un montant de dette ou d'avance valide.", "erreur de validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(guna2TextBox3.Text))
                {
                    if (!decimal.TryParse(guna2TextBox3.Text, out decimal montantDette))
                    {
                        MessageBox.Show("Veuillez saisir une valeur numérique valide pour le montant de la Dette.",
                            "erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int employeeIdForDette = (int)guna2ComboBox3.SelectedValue;

                     DateTime datemantant = DateTime.Now;
                    await _SalaireStorage.UpdateDette(employeeIdForDette, montantDette, datemantant);
                    MessageBox.Show(datemantant.ToString() , "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                     await LoadDebtDetails();
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Veuillez saisir des valeurs numériques valides pour les montants des dettes et des avances.",
                    "Erreur d'entrée", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est programm lors de l'ajout de la dette et de l'avance: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
