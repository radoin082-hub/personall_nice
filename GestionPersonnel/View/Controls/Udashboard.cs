using GestionPersonnel.Storages.EmployeesStorages;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPersonnel.View
{
    public partial class Udashboard : UserControl
    {
        private System.Windows.Forms.Timer refreshTimer;

        private readonly EmployeStorage _employeeStorage;

        public Udashboard()
        {
            InitializeComponent();
            _employeeStorage = new EmployeStorage();  // Initialize your storage class
        }

        private async void Udashboard_Load(object sender, EventArgs e)
        {
            this.refreshTimer = new System.Windows.Forms.Timer();
            this.refreshTimer.Interval = 1; // Set the interval to 60000 milliseconds (1 minute)
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);

            // Start the timer when the control loads
            refreshTimer.Start();

            // Fetch and display the total number of employees initially
            await DisplayTotalEmployees();
        }

        private async void refreshTimer_Tick(object sender, EventArgs e)
        {
            // Fetch and display the total number of employees periodically
            await DisplayTotalEmployees();
        }

        private async Task DisplayTotalEmployees()
        {
            try
            {
                int totalEmployees = await _employeeStorage.GetTotalNumberOfEmployees();
                label11.Text = totalEmployees.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching the total number of employees: {ex.Message}");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
