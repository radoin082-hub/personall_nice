using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionPersonnel.Models.Employees;
using GestionPersonnel.Models.Pointage;
using GestionPersonnel.Services.EmployeeServices; // Correct namespace for EmployeeService

namespace GestionPersonnel.View.Controls
{
    public partial class UPointage : UserControl
    {
        private readonly EmployeeService _employeeService;
        private readonly PointageService _pointageService;

        public UPointage(string connectionString)
        {
            _employeeService = new EmployeeService(connectionString);
            _pointageService = new PointageService(connectionString);
            InitializeComponent();
        }

        private void showiconedit(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && (tabpointage.Columns[e.ColumnIndex] is DataGridViewButtonColumn))
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);

                DataGridViewButtonColumn buttonColumn = (DataGridViewButtonColumn)tabpointage.Columns[e.ColumnIndex];
                Image icon = buttonColumn.Tag as Image;

                if (icon != null)
                {
                    int iconWidth = 30;
                    int iconHeight = 30;
                    int iconX = e.CellBounds.X + (e.CellBounds.Width - iconWidth) / 2;
                    int iconY = e.CellBounds.Y + (e.CellBounds.Height - iconHeight) / 2;

                    e.Graphics.DrawImage(icon, new Rectangle(iconX, iconY, iconWidth, iconHeight));
                }

                using (Pen pen = new Pen(tabpointage.GridColor, 0))
                {
                    e.Graphics.DrawRectangle(pen, e.CellBounds);
                }

                e.Handled = true;
            }
        }

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            DateTime selectedDateTime = DateEntrerEmployes.Value.Date;
            DateOnly selectedDate = DateOnly.FromDateTime(selectedDateTime);

            List<Employee> employees = await _employeeService.GetAllEmployees();

            bool noPointageShown = false;
            tabpointage.Rows.Clear();
            int i = 0;
            foreach (var employee in employees)
            {
                Pointage? pointage = await _pointageService.GetPointageByIdAndDate(employee.EmployeID, selectedDate);

                if (pointage != null)
                {
                    i++;
                    tabpointage.Rows.Add(
                        i,
                        employee.Nom,
                        employee.Prenom,
                        employee.FonctionName,
                        pointage.Stat,
                        pointage.HeuresTravaillees,
                        pointage.persontage + " %",
                        pointage.Remarque,
                        employee.EmployeID,
                        pointage.PointageID
                    );
                }
                else
                {
                    if (!noPointageShown)
                    {
                        noPointageShown = true;
                    }
                }
            }
        }

        private async void guna2DataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == tabpointage.Columns["ModifierColumn"].Index && e.RowIndex >= 0)
            {
                panelaupdpointage.Visible = true;
                var row = tabpointage.Rows[e.RowIndex];

                string nom = row.Cells["Nom"].Value?.ToString() ?? string.Empty;
                string prenom = row.Cells["Prenom"].Value?.ToString() ?? string.Empty;
                string fonction = row.Cells["Fonction"].Value?.ToString() ?? string.Empty;
                string status = row.Cells["Status"].Value?.ToString() ?? string.Empty;
                string heur = row.Cells["Heur"].Value?.ToString() ?? string.Empty;
                string pourcentage = row.Cells["Pourcentage"].Value?.ToString() ?? string.Empty;
                string remarque = row.Cells["Remarque"].Value?.ToString() ?? string.Empty;

                int employeId = Convert.ToInt32(row.Cells["EmployeID"].Value);

                var employee = await _employeeService.GetEmployeeById(employeId);
                if (employee != null)
                {
                    if (employee.Photo != null)
                    {
                        using (var ms = new System.IO.MemoryStream(employee.Photo))
                        {
                            photoProfileEmployes.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        photoProfileEmployes.Image = Properties.Resources.icons8_delete_48;
                    }

                    labname.Text = nom;
                    labprenom.Text = prenom;
                    labfonction.Text = fonction;
                    addfonction.Text = status;
                    guna2TextBox2.Text = heur;
                    guna2TextBox3.Text = pourcentage;
                    guna2TextBox4.Text = remarque;
                }
            }
        }

        private async void Guna2Button4_Click(object sender, EventArgs e)
        {
            if (tabpointage.CurrentRow == null)
            {
                MessageBox.Show("Aucune ligne sélectionnée.");
                return;
            }

            int pointageId = Convert.ToInt32(tabpointage.CurrentRow.Cells["PointageID"].Value);
            decimal heuresTravaillees;

            if (decimal.TryParse(guna2TextBox2.Text, out heuresTravaillees))
            {
                var pointageToUpdate = new Pointage
                {
                    PointageID = pointageId,
                    HeuresTravaillees = heuresTravaillees,
                    Remarque = guna2TextBox4.Text
                };

                try
                {
                    await _pointageService.UpdatePointage(pointageToUpdate);
                    MessageBox.Show("Mise à jour réussie !");
                    await LoadPointages();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la mise à jour : {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Veuillez entrer une valeur valide pour les heures travaillées.");
            }
        }

        private void DateEntrerEmployes_ValueChanged(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void UPointage_Load(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private async Task LoadPointages()
        {
            DateTime selectedDateTime = DateEntrerEmployes.Value.Date;
            DateOnly selectedDate = DateOnly.FromDateTime(selectedDateTime);
            List<Employee> employees = await _employeeService.GetAllEmployees();

            bool noPointageShown = false;
            tabpointage.Rows.Clear();
            int i = 0;
            foreach (var employee in employees)
            {
                Pointage? pointage = await _pointageService.GetPointageByIdAndDate(employee.EmployeID, selectedDate);

                if (pointage != null)
                {
                    i++;
                    tabpointage.Rows.Add(
                        i,
                        employee.Nom,
                        employee.Prenom,
                        employee.FonctionName,
                        pointage.Stat,
                        pointage.HeuresTravaillees,
                        pointage.persontage + " %",
                        pointage.Remarque,
                        employee.EmployeID,
                        pointage.PointageID
                    );
                }
                else
                {
                    if (!noPointageShown)
                    {
                        noPointageShown = true;
                    }
                }
            }
        }

        private void tabpointage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Premarque_Click(object sender, EventArgs e)
        {

        }

        private void Phuer_Click(object sender, EventArgs e)
        {

        }

        private void labname_Click(object sender, EventArgs e)
        {

        }

        private void addfonction_Click(object sender, EventArgs e)
        {

        }

        private void photoProfileEmployes_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelaupdpointage_Paint(object sender, PaintEventArgs e)
        {
            this.panelaupdpointage.BringToFront();
        }
    }
}
