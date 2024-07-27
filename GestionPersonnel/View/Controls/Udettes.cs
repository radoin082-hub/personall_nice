using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionPersonnel.Models.Dettes;
using GestionPersonnel.Storages.DettesStorages;

namespace GestionPersonnel.View.Controls
{
    public partial class Udettes : UserControl
    {
        private readonly DetteStorage _dettesStorage;

        public Udettes(string connectionString)
        {
            _dettesStorage = new DetteStorage(connectionString);
            InitializeComponent();
        }

        private async void Udettes_Load(object sender, EventArgs e)
        {
            await LoadDebtDetails();
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
                MessageBox.Show($"An error occurred while loading debt details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDataGridView(List<PaimentsInfo> paimentsInfos)
        {
            DettesGrid.Rows.Clear();
            foreach (var paiment in paimentsInfos)
            {
                DettesGrid.Rows.Add(paiment.Nom, paiment.Prenom, paiment.NomFonction, paiment.TotaleDette, paiment.MontantRetrait, paiment.TotaleAvances);
            }
        }
    }
}
