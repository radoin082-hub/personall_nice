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
using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Image = System.Drawing.Image;
using System.IO;
using PdfSharp.Drawing;
using System.Drawing.Imaging;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using System.Drawing.Imaging;
using PdfDocument = PdfSharp.Pdf.PdfDocument;
using PdfPage = PdfSharp.Pdf.PdfPage;

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
            tabpaiement.CellContentClick += tabpaiement_CellContentClick;
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

        private async void tabpaiement_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && tabpaiement.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                try
                {
                    var selectedRow = tabpaiement.Rows[e.RowIndex];
                    string nom = selectedRow.Cells["NomEmploye"].Value?.ToString() ?? string.Empty;
                    string prenom = selectedRow.Cells["PrenomEmploye"].Value?.ToString() ?? string.Empty;
                    string fonction = selectedRow.Cells["NomFonction"].Value?.ToString() ?? string.Empty;
                    string typePaiement = selectedRow.Cells["TypePaiement"].Value?.ToString() ?? string.Empty;
                    decimal salaire = selectedRow.Cells["Salaire"].Value != null ? Convert.ToDecimal(selectedRow.Cells["Salaire"].Value) : 0;
                    decimal primes = selectedRow.Cells["Primes"].Value != null ? Convert.ToDecimal(selectedRow.Cells["Primes"].Value) : 0;
                    decimal avances = selectedRow.Cells["Avances"].Value != null ? Convert.ToDecimal(selectedRow.Cells["Avances"].Value) : 0;
                    decimal dettes = selectedRow.Cells["Dettes"].Value != null ? Convert.ToDecimal(selectedRow.Cells["Dettes"].Value) : 0;
                    decimal salaireNet = selectedRow.Cells["SalaireNet"].Value != null ? Convert.ToDecimal(selectedRow.Cells["SalaireNet"].Value) : 0;

                    await GeneratePdfForEmployee(nom, prenom, fonction, typePaiement, salaire, primes, avances, dettes, salaireNet);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private async Task GeneratePdfForEmployee(string nom, string prenom, string fonction, string typePaiement,
      decimal salaire, decimal primes, decimal avances, decimal dettes, decimal salaireNet)
        {
            try
            {
                using (PdfDocument document = new PdfDocument())
                {
                    // Create an empty page
                    PdfPage page = document.AddPage();
                    XGraphics gfx = XGraphics.FromPdfPage(page);

                    // Draw the title
                    XFont titleFont = new XFont("Verdana", 20);
                    gfx.DrawString("Bulletin de Paie", titleFont, XBrushes.Black,
                        new XRect(0, 20, page.Width, page.Height),
                        XStringFormats.TopCenter);

                    // Create fonts for content and headers
                    XFont contentFont = new XFont("Verdana", 12);
                    XFont headerFont = new XFont("Verdana", 12);

                    // Table settings
                    int tableX = 20;
                    int tableWidth = (int)(page.Width - 40);
                    int rowHeight = 20;
                    int columnWidth1 = 150; // Adjust as needed
                    int columnWidth2 = tableWidth - columnWidth1;

                    // Draw table header for employee details
                    int yPos = 60;
                    gfx.DrawRectangle(XBrushes.LightGray, tableX, yPos, tableWidth, rowHeight);
                    gfx.DrawString("Détails", headerFont, XBrushes.Black,
                        new XRect(tableX, yPos, tableWidth, rowHeight),
                        XStringFormats.TopCenter);

                    yPos += rowHeight;

                    // Function to draw table rows
                    void DrawTableRow(string label, string value)
                    {
                        gfx.DrawRectangle(XBrushes.White, tableX, yPos, tableWidth, rowHeight);
                        gfx.DrawRectangle(XPens.Black, tableX, yPos, tableWidth, rowHeight);
                        gfx.DrawString(label, contentFont, XBrushes.Black,
                            new XRect(tableX, yPos, columnWidth1, rowHeight),
                            XStringFormats.TopLeft);
                        gfx.DrawString(value, contentFont, XBrushes.Black,
                            new XRect(tableX + columnWidth1, yPos, columnWidth2, rowHeight),
                            XStringFormats.TopLeft);
                        yPos += rowHeight;
                    }

                    // Draw employee details
                    DrawTableRow("Nom:", nom);
                    DrawTableRow("Prénom:", prenom);
                    DrawTableRow("Fonction:", fonction);
                    DrawTableRow("Type de Paiement:", typePaiement);

                    // Add spacing before salary details
                    yPos += 10;

                    // Draw table header for salary details
                    gfx.DrawRectangle(XBrushes.LightGray, tableX, yPos, tableWidth, rowHeight);
                    gfx.DrawString("Salaire et Primes", headerFont, XBrushes.Black,
                        new XRect(tableX, yPos, tableWidth, rowHeight),
                        XStringFormats.TopCenter);

                    yPos += rowHeight;

                    // Draw salary details
                    DrawTableRow("Salaire:", salaire.ToString("C"));
                    DrawTableRow("Primes:", primes.ToString("C"));
                    DrawTableRow("Avances:", avances.ToString("C"));
                    DrawTableRow("Dettes:", dettes.ToString("C"));
                    DrawTableRow("Salaire Net:", salaireNet.ToString("C"));

                    yPos += 20;

                    // Add employee photo if available
                    if (photoProfileEmployes.Image != null)
                    {
                        using (MemoryStream photoStream = new MemoryStream())
                        {
                            photoProfileEmployes.Image.Save(photoStream, ImageFormat.Png);
                            XImage image = XImage.FromStream(photoStream);
                            gfx.DrawImage(image, 20, yPos, 150, 150);
                        }
                    }

                    // Show SaveFileDialog to choose path
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                        saveFileDialog.Title = "Save PDF File";
                        saveFileDialog.FileName = $"{nom}_{prenom}_BulletinDePaie.pdf";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Save the document
                            document.Save(saveFileDialog.FileName);
                            MessageBox.Show($"PDF generated successfully: {saveFileDialog.FileName}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while generating PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    using (var ms = new MemoryStream(selectedEmployee.Photo))
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
            int i=0;
            foreach (var salaireDetails in salaires)
            {
                i++;
                tabpaiement.Rows.Add(
                    i,
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
