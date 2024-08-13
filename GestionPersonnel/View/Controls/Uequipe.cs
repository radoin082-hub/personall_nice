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
            await PopulateComboBoxAsync(); // Ensure this is called to populate guna2ComboBox2
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
                await LoadChefAsync(equipeId);
            }
        }

        private async Task LoadChefAsync(int equipeId)
        {
            
            try
            {
                var equipe = await _equipeStorage.GetById(equipeId);
                var chef = await _employeeStorage.GetById(equipe.ChefEquipeID);

                guna2ComboBox4.DataSource = new List<Employee> { chef };
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
                await LoadChefAsync(equipeId);
            }
        }
    }
}
