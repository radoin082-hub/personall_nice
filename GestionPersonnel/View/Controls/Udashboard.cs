using GestionPersonnel.Storages.EmployeesStorages;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionPersonnel.Storages.DettesStorages;

namespace GestionPersonnel.View
{
    public partial class Udashboard : UserControl
    {
        private readonly string _connectionString;

        private System.Windows.Forms.Timer refreshTimer;
        private readonly EmployeStorage _employeeStorage;
        private readonly DetteStorage _detteStorage;

        public Udashboard(string connectionString)
        {
            _connectionString = connectionString;
            InitializeComponent();
            _detteStorage = new DetteStorage(connectionString);
            _employeeStorage = new EmployeStorage(connectionString);
        }

        private async void Udashboard_Load(object sender, EventArgs e)
        {
            this.refreshTimer = new System.Windows.Forms.Timer();
            this.refreshTimer.Interval = 1;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            refreshTimer.Start();
            await RefreshData();
        }

        private async void refreshTimer_Tick(object sender, EventArgs e)
        {
            await RefreshData();
        }

        private async Task RefreshData()
        {
            try
            {
                DateTime specificDate = DateTime.Now;

                int totalEmployees = await _employeeStorage.GetTotalNumberOfEmployees();
                label11.Text = totalEmployees.ToString();

                decimal totalSalary = await _employeeStorage.GetTotalSalaryForMonth(specificDate);
                label6.Text = $"{totalSalary}" + " DA";
                decimal totalAdvances = await _detteStorage.GetTotalDettes();
                label1.Text = $"{totalAdvances}" + " DA";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ALL data null: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e) { }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e) { }

        private void label10_Click(object sender, EventArgs e) { }

        private void pictureBox7_Click(object sender, EventArgs e) { }

        private void label7_Click(object sender, EventArgs e) { }

        private void timer1_Tick(object sender, EventArgs e) { }

        private void label6_Click(object sender, EventArgs e) { }

        private void label11_Click(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
