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

namespace GestionPersonnel.View.Controls
{
    public partial class Udettes : UserControl
    {
        private readonly DetteStorage _dettesStorage;
        private readonly AvanceStorage _avancesStorage;
        private readonly EmployeStorage _employeeStorage;

        public Udettes(string connectionString)
        {
            _dettesStorage = new DetteStorage(connectionString);
            _avancesStorage = new AvanceStorage(connectionString);
            _employeeStorage = new EmployeStorage(connectionString);
            InitializeComponent();
        }

        private async void Udettes_Load(object sender, EventArgs e)
        {
            await LoadDebtDetails();
            await LoadEmployees();
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
                DettesGrid.Rows.Add(i, paiment.Nom, paiment.Prenom, paiment.NomFonction, paiment.TotaleDette, paiment.MontantRetrait, paiment.TotaleAvances);
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
        }

        private async void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(guna2TextBox2.Text) && string.IsNullOrWhiteSpace(guna2TextBox1.Text))
                {
                    MessageBox.Show("Veuillez saisir un montant de dette ou d'avance valide.", "erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(guna2TextBox2.Text))
                {
                    if (!decimal.TryParse(guna2TextBox2.Text, out decimal montantDette))
                    {
                        MessageBox.Show("Veuillez saisir une valeur numérique valide pour le montant de la Dette.", "erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                MessageBox.Show("Dette et/ou avance ajoutées avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDebtDetails();
            }
            catch (FormatException)
            {
                MessageBox.Show("Veuillez saisir des valeurs numériques valides pour les montants des dettes et des avances.", "Erreur d'entrée", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite lors de l'ajout de la dette et de l'avance: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
