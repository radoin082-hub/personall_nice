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
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
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


        private async Task GeneratePdfForEmployee(string nom, string prenom, string fonction, string typePaiement, decimal salaire, decimal primes, decimal avances, decimal dettes, decimal salaireNet)
        {
            try
            {
                // Créer un nouveau document PDF
                using (PdfDocument document = new PdfDocument())
                {
                    PdfPage page = document.AddPage();
                    XGraphics gfx = XGraphics.FromPdfPage(page);

                    // Définir les polices
                    XFont titleFont = new XFont("Arial", 14, XFontStyleEx.Bold);
                    XFont headerFont = new XFont("Arial", 10, XFontStyleEx.Bold);
                    XFont contentFont = new XFont("Arial", 10);

                    // Titre
                    gfx.DrawString("Bulletin de salaire", titleFont, XBrushes.Black,
                        new XRect(0, 20, page.Width, page.Height),
                        XStringFormats.TopCenter);

                    // Informations sur l'employé et l'employeur
                    int yPos = 60;
                    gfx.DrawString("Nom: " + nom, contentFont, XBrushes.Black, new XRect(20, yPos, page.Width, page.Height), XStringFormats.TopLeft);
                    yPos += 15;
                    gfx.DrawString("Prénom: " + prenom, contentFont, XBrushes.Black, new XRect(20, yPos, page.Width, page.Height), XStringFormats.TopLeft);
                    yPos += 15;
                    gfx.DrawString("Fonction: " + fonction, contentFont, XBrushes.Black, new XRect(20, yPos, page.Width, page.Height), XStringFormats.TopLeft);
                    yPos += 15;
                    gfx.DrawString("Type de paiement: " + typePaiement, contentFont, XBrushes.Black, new XRect(20, yPos, page.Width, page.Height), XStringFormats.TopLeft);

                    // Titre des détails du salaire
                    yPos += 30;
                    gfx.DrawRectangle(XBrushes.LightGray, 20, yPos, page.Width - 40, 20);
                    gfx.DrawString("Détails du salaire", headerFont, XBrushes.Black, new XRect(20, yPos, page.Width - 40, 20), XStringFormats.Center);

                    // Tableau des détails du salaire
                    yPos += 20;
                    int tableX = 20;
                    int tableWidth = (int)(page.Width - 40);
                    int rowHeight = 20;
                    int columnWidth1 = tableWidth / 3;
                    int columnWidth2 = tableWidth / 3;
                    int columnWidth3 = tableWidth / 3;

                    gfx.DrawRectangle(XPens.Black, tableX, yPos, columnWidth1, rowHeight);
                    gfx.DrawRectangle(XPens.Black, tableX + columnWidth1, yPos, columnWidth2, rowHeight);
                    gfx.DrawRectangle(XPens.Black, tableX + columnWidth1 + columnWidth2, yPos, columnWidth3, rowHeight);
                    gfx.DrawString("Détails", contentFont, XBrushes.Black, new XRect(tableX, yPos, columnWidth1, rowHeight), XStringFormats.CenterLeft);
                    gfx.DrawString("Montant", contentFont, XBrushes.Black, new XRect(tableX + columnWidth1, yPos, columnWidth2, rowHeight), XStringFormats.Center);
                    gfx.DrawString("Déduction", contentFont, XBrushes.Black, new XRect(tableX + columnWidth1 + columnWidth2, yPos, columnWidth3, rowHeight), XStringFormats.Center);

                    yPos += rowHeight;

                    // Méthode auxiliaire pour dessiner les lignes de salaire
                    void DrawSalaryRow(string label, decimal value)
                    {
                        gfx.DrawRectangle(XPens.Black, tableX, yPos, columnWidth1, rowHeight);
                        gfx.DrawRectangle(XPens.Black, tableX + columnWidth1, yPos, columnWidth2, rowHeight);
                        gfx.DrawRectangle(XPens.Black, tableX + columnWidth1 + columnWidth2, yPos, columnWidth3, rowHeight);
                        gfx.DrawString(label, contentFont, XBrushes.Black, new XRect(tableX, yPos, columnWidth1, rowHeight), XStringFormats.CenterLeft);
                        gfx.DrawString(value.ToString("C"), contentFont, XBrushes.Black, new XRect(tableX + columnWidth1, yPos, columnWidth2, rowHeight), XStringFormats.Center);
                        gfx.DrawString("", contentFont, XBrushes.Black, new XRect(tableX + columnWidth1 + columnWidth2, yPos, columnWidth3, rowHeight), XStringFormats.Center);
                        yPos += rowHeight;
                    }

                    // Ajouter les détails du salaire
                    DrawSalaryRow("Salaire:", salaire);
                    DrawSalaryRow("Primes:", primes);
                    DrawSalaryRow("Avances:", avances);
                    DrawSalaryRow("Dettes:", dettes);
                    DrawSalaryRow("Salaire Net:", salaireNet);

                    // Enregistrer le fichier PDF
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Fichiers PDF (*.pdf)|*.pdf";
                        saveFileDialog.Title = "Enregistrer le fichier PDF";
                        saveFileDialog.FileName = $"{nom}_{prenom}_BulletinDeSalaire.pdf";

                        // Afficher la boîte de dialogue et enregistrer le fichier si l'utilisateur appuie sur OK
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            document.Save(saveFileDialog.FileName);
                            MessageBox.Show($"PDF généré avec succès: {saveFileDialog.FileName}", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite lors de la génération du PDF: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
