using GestionPersonnel.Storages.EmployeeEquipeStorages;
using GestionPersonnel.Storages.EquipeStorages;
using GestionPersonnel.Storages.EmployeesStorages;
using GestionPersonnel.Storages.FonctionsStorages;
using GestionPersonnel.Models.Employees;
using GestionPersonnel.Models.EmplyeeEquipe;
using GestionPersonnel.Models.Equipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionPersonnel.Models.Fonctions;
using Guna.UI2.WinForms;

namespace GestionPersonnel.View.Controls
{
    public partial class Uequipe : UserControl
    {
        private readonly EmployeeEquipeStorage _employeeEquipeStorage;
        private readonly EquipeStorage _equipeStorage;
        private readonly EmployeStorage _employeeStorage;
        private readonly FonctionStorage _fonctionStorage;

        public Uequipe(string connectionString)
        {
            _employeeEquipeStorage = new EmployeeEquipeStorage(connectionString);
            _equipeStorage = new EquipeStorage(connectionString);
            _employeeStorage = new EmployeStorage(connectionString);
            _fonctionStorage = new FonctionStorage(connectionString);
            InitializeComponent();
            InitializeDefaultSelections();


        }

        private async void Uequipe_Load_1(object sender, EventArgs e)
        {
            await LoadFunctionsAsync();
            await PopulateComboBoxAsync();

        }

        private async Task LoadFunctionsAsync()
        {
            try
            {
                var functions = await _fonctionStorage.GetAll();
                guna2ComboBox1.DataSource = functions;
                guna2ComboBox1.DisplayMember = "NomFonction";
                guna2ComboBox1.ValueMember = "FonctionID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading functions: {ex.Message}");
            }
        }

        private async Task LoadEmployeesAsync(int functionId)
        {
            try
            {
                var employees = await _employeeStorage.GetEmployeesByFunctionId(functionId);

                guna2ComboBox3.DataSource = employees;
                guna2ComboBox3.DisplayMember = "FullName";
                guna2ComboBox3.ValueMember = "EmployeID";

                checkedListBox1.DataSource = employees;
                checkedListBox1.DisplayMember = "FullName";
                checkedListBox1.ValueMember = "EmployeID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading employees: {ex.Message}");
            }
        }

        private async void guna2Button3_Click(object sender, EventArgs e)
        {
            string equipeName = guna2TextBox2.Text.Trim();
            if (string.IsNullOrEmpty(equipeName))
            {
                MessageBox.Show("Please enter the team name.");
                return;
            }

            try
            {
                var selectedFunction = (Fonction)guna2ComboBox1.SelectedItem;
                var selectedEmployee = (Employee)guna2ComboBox3.SelectedItem;

                if (selectedFunction == null || selectedEmployee == null)
                {
                    MessageBox.Show("No function or employee selected.");
                    return;
                }


                string nom = selectedEmployee.Nom.Trim();
                string prenom = selectedEmployee.Prenom.Trim();
                string nomFonction = selectedFunction.NomFonction.Trim();

                int? chefId = await _employeeStorage.GetEmployeeIdByName(nom, prenom, nomFonction);

                if (chefId == null)
                {
                    MessageBox.Show("Chef de l'équipe not found.");
                    return;
                }

                int equipeId = await _equipeStorage.Add(new Equipe { NomEquipe = equipeName, ChefEquipeID = chefId.Value });

                foreach (var item in checkedListBox1.CheckedItems)
                {
                    int employeeId = ((Employee)item).EmployeID;
                    await _employeeEquipeStorage.Add(new EmployeeEquipe { EmployeeID = employeeId, EquipeeID = equipeId });
                }

                MessageBox.Show("Team and employee assignments saved successfully.");
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void ClearInputs()
        {
            guna2TextBox2.Clear();
            guna2ComboBox1.SelectedIndex = -1;
            guna2ComboBox2.SelectedIndex = -1;
            guna2ComboBox4.SelectedIndex = -1;
            checkedListBox1.ClearSelected();
        }
        private void InitializeDefaultSelections()
        {
            guna2ComboBox2.SelectedIndex = -1;
            guna2ComboBox4.SelectedIndex = -1;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            panelAddEquipe.Visible = true;
            panelUpdateEquipe.Visible = false;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            panelUpdateEquipe.Visible = true;
            panelAddEquipe.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panelAddEquipe.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panelUpdateEquipe.Visible = false;
        }

        private async void guna2ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedValue is int functionId)
            {
                await LoadEmployeesAsync(functionId);
            }
        }

        private async void guna2ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox2.SelectedValue is int equipeId)
            {
                await LoadAllEquipeAsync(equipeId);
            }
        }

        private async Task LoadAllEquipeAsync(int equipeId)
        {

            try
            {

                var equips = await _employeeStorage.GetAll();

                guna2ComboBox4.DataSource = equips;
                guna2ComboBox4.DisplayMember = "FullName";
                guna2ComboBox4.ValueMember = "EmployeID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the chef details: {ex.Message}");
            }
        }

        private async Task PopulateComboBoxAsync()
        {

            try
            {

                var equipes = await _equipeStorage.GetAll();
                guna2ComboBox2.DataSource = equipes;
                guna2ComboBox2.DisplayMember = "NomEquipe";
                guna2ComboBox2.ValueMember = "EquipeID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while populating the combo box: {ex.Message}");
            }
        }

        private async void panelUpdateEquipe_Paint(object sender, EventArgs e)
        {
            guna2ComboBox2.SelectedIndex = -1;

        }

        private async void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox2.SelectedValue is int equipeId)
            {
                await LoadAllEquipeAsync(equipeId);
                await LoadEmployeesForEquipeAsync(equipeId);
            }

        }

        private async Task LoadEmployeesForEquipeAsync(int equipeId)
        {
            try
            {
                // Retrieve all employees
                var allEmployees = await _employeeStorage.GetAll();

                // Retrieve employees in the selected team
                var employeesInEquipe = await _employeeEquipeStorage.GetEmployeesByEquipeId(equipeId);

                // Set the data source for the CheckedListBox
                checkedListBox2.DataSource = allEmployees;
                checkedListBox2.DisplayMember = "FullName";
                checkedListBox2.ValueMember = "EmployeID";

                // Check the employees who are already in the selected team
                foreach (var employee in allEmployees)
                {
                    checkedListBox2.SetItemChecked(checkedListBox2.Items.IndexOf(employee),
                        employeesInEquipe.Any(e => e.EmployeID == employee.EmployeID));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading employees for the team: {ex.Message}");
            }
        }


        private async void guna2Button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve selected team and new chef
                var selectedEquipe = (Equipe)guna2ComboBox2.SelectedItem;
                var newChef = (Employee)guna2ComboBox4.SelectedItem;

                if (selectedEquipe == null || newChef == null)
                {
                    MessageBox.Show("Please select a valid team and chef.");
                    return;
                }

                string newEquipeName = guna2TextBox2.Text.Trim();
                if (string.IsNullOrEmpty(newEquipeName))
                {
                    MessageBox.Show("Please enter the new team name.");
                    return;
                }

                // Retrieve the employee IDs from checkedListBox2
                var checkedEmployeeIds = checkedListBox2.CheckedItems
                    .Cast<Employee>()
                    .Select(e => e.EmployeID)
                    .ToList();

                // Update the team with the new name and chef
                selectedEquipe.NomEquipe = newEquipeName;
                selectedEquipe.ChefEquipeID = newChef.EmployeID;

                await _equipeStorage.Update(selectedEquipe);

                // Remove existing employees from the team
                await _equipeStorage.de(selectedEquipe.EquipeID);

                // Add new employees to the team
                foreach (var employeeId in checkedEmployeeIds)
                {
                    await _employeeEquipeStorage.Add(new EmployeeEquipe
                    {
                        EmployeeID = employeeId,
                        EquipeeID = selectedEquipe.EquipeID
                    });
                }

                MessageBox.Show("Team updated successfully.");
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the team: {ex.Message}");
            }
        }

    }
}
