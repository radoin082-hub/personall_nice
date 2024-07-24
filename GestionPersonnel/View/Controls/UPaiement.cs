using GestionPersonnel.Storages.EmployeesStorages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionPersonnel.Models.Employees;
using System.Drawing;
using GestionPersonnel.Storages.TypeDePaimentStorages;
using GestionPersonnel.Models.TypeDePaiment;
using GestionPersonnel.Models.SalairesBase;
using GestionPersonnel.Storages.SalairesBaseStorages;

using GestionPersonnel.Models.Salaires;
using GestionPersonnel.Storages.SalairesStorages;
using Guna.UI2.WinForms;

namespace GestionPersonnel.View.Controls
{
    public partial class UPaiement : UserControl
    {
        private readonly string _connectionString;
        private readonly EmployeStorage _employeStorage;
        private readonly TypeDePaiementStorage _paiementStorage;
        private readonly SalaireBaseStorage _salaireBaseStorage;
        private readonly SalaireStorage _salaireDetailsStorage;

        public UPaiement(string connectionString)
        {
            _connectionString = connectionString;
            _employeStorage = new EmployeStorage(connectionString);
            _paiementStorage = new TypeDePaiementStorage(connectionString);
            _salaireBaseStorage = new SalaireBaseStorage(connectionString);
            _salaireDetailsStorage = new SalaireStorage(connectionString);
            InitializeComponent();
        }

        private void showiconedit(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && (tabpaiement.Columns[e.ColumnIndex] is DataGridViewButtonColumn))
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);

                DataGridViewButtonColumn buttonColumn = (DataGridViewButtonColumn)tabpaiement.Columns[e.ColumnIndex];
                Image icon = buttonColumn.Tag as Image;

                if (icon != null)
                {
                    int iconWidth = 30;
                    int iconHeight = 30;
                    int iconX = e.CellBounds.X + (e.CellBounds.Width - iconWidth) / 2;
                    int iconY = e.CellBounds.Y + (e.CellBounds.Height - iconHeight) / 2;

                    e.Graphics.DrawImage(icon, new Rectangle(iconX, iconY, iconWidth, iconHeight));
                }

                using (Pen pen = new Pen(tabpaiement.GridColor, 0))
                {
                    e.Graphics.DrawRectangle(pen, e.CellBounds);
                }

                e.Handled = true;
            }
        }


        private async void guna2Button2_Click(object sender, EventArgs e)
        {
            panelPaiement.Visible = true;
            await getall_employees();
            await getall_types_paiement();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panelPaiement.Visible = false;
        }

        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void labfonction_Click(object sender, EventArgs e)
        {

        }

        private async void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedItem is Employee selectedEmployee)
            {
                label6.Text = selectedEmployee.FullName;
                label7.Text = selectedEmployee.FonctionName;

                if (selectedEmployee.Photo != null)
                {
                    using (var ms = new System.IO.MemoryStream(selectedEmployee.Photo))
                    {
                        photoProfileEmployes.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    photoProfileEmployes.Image = null;
                }
            }
        }

        private async Task getall_employees()
        {
            List<Employee> employees = await _employeStorage.GetAll();

            guna2ComboBox1.DataSource = employees;
            guna2ComboBox1.DisplayMember = "FullName";
            guna2ComboBox1.ValueMember = "EmployeID";
            guna2ComboBox1.SelectedIndex = -1;
        }

        private async Task getall_types_paiement()
        {
            List<TypeDePaiement> typesPaiement = await _paiementStorage.GetAll();
            guna2ComboBox2.DataSource = typesPaiement;
            guna2ComboBox2.DisplayMember = "NomTypePaiement";
            guna2ComboBox2.ValueMember = "TypePaiementID";
            guna2ComboBox2.SelectedIndex = -1;
        }

        private async void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2ComboBox1.SelectedItem is Employee selectedEmployee && guna2ComboBox2.SelectedItem is TypeDePaiement selectedTypePaiement)
                {
                    decimal salaireBase = decimal.Parse(guna2TextBox2.Text);
                    var salairesBase = new SalairesBase
                    {
                        SalaireBase = salaireBase,
                        TypePaiementID = selectedTypePaiement.TypePaiementID,
                        EmplyeId = selectedEmployee.EmployeID
                    };

                    int newId = await _salaireBaseStorage.Add(salairesBase);
                    MessageBox.Show($"Record added successfully with ID {newId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select both an employee and a payment type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            await LoadSalaireDetailsByDate();
        }

        private async Task LoadSalaireDetailsByDate()
        {
            DateTime selectedDateTime = DateEntrerEmployes.Value.Date;
           
            List<SalaireDetail> salaires = await _salaireDetailsStorage.GetSalariesByMonth(selectedDateTime);

            tabpaiement.Rows.Clear();

            foreach (var salaireDetails in salaires)
            {
                tabpaiement.Rows.Add(
                    salaireDetails.NomEmploye,
                    salaireDetails.PrenomEmploye,
                    salaireDetails.NomFonction,
                    salaireDetails.TypePaiement,
                    salaireDetails.Salaire,
                    salaireDetails.Primes,
                    salaireDetails.Avances,
                    salaireDetails.Dettes,
                    salaireDetails.SalaireNet
                    
                );
            }
        }

        
    }
}
