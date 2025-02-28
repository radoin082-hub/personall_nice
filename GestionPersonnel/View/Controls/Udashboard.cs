﻿using GestionPersonnel.Storages.EmployeesStorages;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionPersonnel.Storages.AvancesStorages;
using GestionPersonnel.Storages.DettesStorages;

namespace GestionPersonnel.View
{
    public partial class Udashboard : UserControl
    {
        private readonly string _connectionString;

        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.Timer clockTimer;
        private readonly EmployeStorage _employeeStorage;
        private readonly AvanceStorage _avanceStorage;
        private readonly DetteStorage _detteStorage;

        public Udashboard(string connectionString)
        {
            _connectionString = connectionString;
            InitializeComponent();
            _detteStorage = new DetteStorage(connectionString);
            _avanceStorage = new AvanceStorage(connectionString);
            _employeeStorage = new EmployeStorage(connectionString);
        }

        private async void Udashboard_Load(object sender, EventArgs e)
        {
            this.refreshTimer = new System.Windows.Forms.Timer();
            this.refreshTimer.Interval = 60000; // 1 minute interval for data refresh
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            refreshTimer.Start();
            await RefreshData();

            this.clockTimer = new System.Windows.Forms.Timer();
            this.clockTimer.Interval = 1000; // 1 second interval for clock update
            this.clockTimer.Tick += new System.EventHandler(this.clockTimer_Tick);
            clockTimer.Start();
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
                decimal totalDette = await _detteStorage.GetTotalDettes();
                label1.Text = $"{totalDette} DA";
                decimal totalAdvances = await _avanceStorage.GetTotale(specificDate);
                label3.Text = $"{totalAdvances} DA";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ALL data null: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clockTimer_Tick(object sender, EventArgs e)
        {
           // clock1.Text = DateTime.Now.ToString("HH:mm:ss");
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
