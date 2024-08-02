using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionPersonnel.Models.Employees;
using GestionPersonnel.Models.Salaires;
using GestionPersonnel.Models.SalairesBase;
using GestionPersonnel.Models.TypeDePaiment;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace GestionPersonnel.View.Controls
{
    public partial class UPaiement : UserControl
    {
        private readonly PaymentController _paymentController;

        public UPaiement(string connectionString)
        {
            _paymentController = new PaymentController(connectionString);
            InitializeComponent();
        }
        private void panelPaiement_Paint(object sender, PaintEventArgs e)
        {
            this.panelPaiement.BringToFront();
        }

        private async Task LoadEmployeesAsync()
        {
            var employees = await _paymentController.GetAllEmployeesAsync();
            guna2ComboBox1.DataSource = employees;
            guna2ComboBox1.DisplayMember = "FullName";
            guna2ComboBox1.ValueMember = "EmployeID";
            guna2ComboBox1.SelectedIndex = -1;
        }

        private async Task LoadPaymentTypesAsync()
        {
            var typesPaiement = await _paymentController.GetAllPaymentTypesAsync();
            guna2ComboBox2.DataSource = typesPaiement;
            guna2ComboBox2.DisplayMember = "NomTypePaiement";
            guna2ComboBox2.ValueMember = "TypePaiementID";
            guna2ComboBox2.SelectedIndex = -1;
        }

        private async void guna2Button2_Click(object sender, EventArgs e)
        {
            panelPaiement.Visible = true;
            await LoadEmployeesAsync();
            await LoadPaymentTypesAsync();
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

                    // Check if there is already a salary base record for the selected employee
                    var existingSalaryBases = await _paymentController.GetSalaryBasesByEmployeeIdAsync(selectedEmployee.EmployeID);
                    if (existingSalaryBases.Count > 0)
                    {
                        // If a record exists, update it
                        var existingSalairesBase = existingSalaryBases[0];
                        existingSalairesBase.SalaireBase = salaireBase;
                        existingSalairesBase.TypePaiementID = selectedTypePaiement.TypePaiementID;

                        await _paymentController.UpdateSalaryBaseAsync(existingSalairesBase);
                        MessageBox.Show("Record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // If no record exists, add a new one
                        await _paymentController.AddSalaryBaseAsync(salairesBase);
                        MessageBox.Show("Record added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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

        private async Task LoadSalaireDetailsByDate()
        {
            DateTime selectedDateTime = DateEntrerEmployes.Value.Date;

            List<SalaireDetail> salaires = await _paymentController.GetSalariesByMonthAsync(selectedDateTime);

            tabpaiement.Rows.Clear();
            int i = 0;
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

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            await LoadSalaireDetailsByDate();
        }

        private async Task GeneratePdfForEmployee(
    string nom, string prenom, string fonction, string typePaiement,
    decimal salaire, decimal primes, decimal avances, decimal dettes,
    decimal salaireNet)
        {
            try
            {
                using (PdfDocument document = new PdfDocument())
                {
                    PdfPage page = document.AddPage();
                    XGraphics gfx = XGraphics.FromPdfPage(page);

                    XFont titleFont = new XFont("Arial", 14, XFontStyleEx.Bold);
                    XFont contentFont = new XFont("Arial", 10);
                    XFont headerFont = new XFont("Arial", 12, XFontStyleEx.Bold);
                    XFont smallFont = new XFont("Arial", 8);

                    gfx.DrawString("Fiche de Paie", titleFont, XBrushes.Black,
                        new XRect(0, 20, page.Width, page.Height),
                        XStringFormats.TopCenter);

                    string generationTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    gfx.DrawString($"Date de génération : {generationTime}", contentFont, XBrushes.Black,
                        new XRect(20, 20, page.Width - 40, 20),
                        XStringFormats.TopLeft);

                    int yPos = 60;
                    gfx.DrawString($"Nom : {nom}", contentFont, XBrushes.Black, new XRect(20, yPos, page.Width - 40, 20), XStringFormats.TopLeft);
                    yPos += 20;
                    gfx.DrawString($"Prénom : {prenom}", contentFont, XBrushes.Black, new XRect(20, yPos, page.Width - 40, 20), XStringFormats.TopLeft);
                    yPos += 20;
                    gfx.DrawString($"Fonction : {fonction}", contentFont, XBrushes.Black, new XRect(20, yPos, page.Width - 40, 20), XStringFormats.TopLeft);
                    yPos += 20;
                    gfx.DrawString($"Type de paiement : {typePaiement}", contentFont, XBrushes.Black, new XRect(20, yPos, page.Width - 40, 20), XStringFormats.TopLeft);
                    yPos += 20;

                    int tableWidth = (int)page.Width - 40;
                    int columnWidth = tableWidth / 3;

                    // Draw header
                    gfx.DrawRectangle(XBrushes.LightGray, 20, yPos, tableWidth, 20);
                    gfx.DrawString("Description", headerFont, XBrushes.Black, new XRect(20, yPos, columnWidth, 20), XStringFormats.Center);
                    gfx.DrawString("Montant", headerFont, XBrushes.Black, new XRect(20 + columnWidth, yPos, columnWidth, 20), XStringFormats.Center);
                    gfx.DrawString("Total", headerFont, XBrushes.Black, new XRect(20 + 2 * columnWidth, yPos, columnWidth, 20), XStringFormats.Center);
                    yPos += 20;

                    string FormatCurrency(decimal amount) => $"{amount:N2} DA";

                    gfx.DrawString("Salaire", contentFont, XBrushes.Black, new XRect(20, yPos, columnWidth, 15), XStringFormats.CenterLeft);
                    gfx.DrawString(FormatCurrency(salaire), contentFont, XBrushes.Black, new XRect(20 + columnWidth, yPos, columnWidth, 15), XStringFormats.CenterRight);
                    gfx.DrawString(string.Empty, contentFont, XBrushes.Black, new XRect(20 + 2 * columnWidth, yPos, columnWidth, 15), XStringFormats.CenterRight);
                    yPos += 15;

                    gfx.DrawString("Primes", contentFont, XBrushes.Black, new XRect(20, yPos, columnWidth, 15), XStringFormats.CenterLeft);
                    gfx.DrawString(FormatCurrency(primes), contentFont, XBrushes.Black, new XRect(20 + columnWidth, yPos, columnWidth, 15), XStringFormats.CenterRight);
                    gfx.DrawString(string.Empty, contentFont, XBrushes.Black, new XRect(20 + 2 * columnWidth, yPos, columnWidth, 15), XStringFormats.CenterRight);
                    yPos += 15;

                    gfx.DrawString("Avances", contentFont, XBrushes.Black, new XRect(20, yPos, columnWidth, 15), XStringFormats.CenterLeft);
                    gfx.DrawString(FormatCurrency(avances), contentFont, XBrushes.Black, new XRect(20 + columnWidth, yPos, columnWidth, 15), XStringFormats.CenterRight);
                    gfx.DrawString(string.Empty, contentFont, XBrushes.Black, new XRect(20 + 2 * columnWidth, yPos, columnWidth, 15), XStringFormats.CenterRight);
                    yPos += 15;

                    gfx.DrawString("Dettes", contentFont, XBrushes.Black, new XRect(20, yPos, columnWidth, 15), XStringFormats.CenterLeft);
                    gfx.DrawString(FormatCurrency(dettes), contentFont, XBrushes.Black, new XRect(20 + columnWidth, yPos, columnWidth, 15), XStringFormats.CenterRight);
                    gfx.DrawString(string.Empty, contentFont, XBrushes.Black, new XRect(20 + 2 * columnWidth, yPos, columnWidth, 15), XStringFormats.CenterRight);
                    yPos += 15;

                    gfx.DrawString("Salaire Net", contentFont, XBrushes.Black, new XRect(20, yPos, columnWidth, 15), XStringFormats.CenterLeft);
                    gfx.DrawString(FormatCurrency(salaireNet), contentFont, XBrushes.Black, new XRect(20 + columnWidth, yPos, columnWidth, 15), XStringFormats.CenterRight);
                    gfx.DrawString(string.Empty, contentFont, XBrushes.Black, new XRect(20 + 2 * columnWidth, yPos, columnWidth, 15), XStringFormats.CenterRight);
                    yPos += 20;

                    gfx.DrawString("Ce document est destiné uniquement à l'usage du destinataire et ne doit pas être partagé avec d'autres personnes.", smallFont, XBrushes.Black,
                        new XRect(20, page.Height - 30, page.Width - 40, 20), XStringFormats.BottomLeft);

                    using (var ms = new MemoryStream())
                    {
                        Properties.Resources.FABELEC.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        XImage image = XImage.FromStream(ms);
                        gfx.DrawImage(image, page.Width - 120, 20, 75, 60);
                    }

                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                        saveFileDialog.Title = "Enregistrer le bulletin de salaire";
                        saveFileDialog.FileName = $"{nom}_{prenom}_BulletinDeSalaire.pdf";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string filename = saveFileDialog.FileName;
                            document.Save(filename);
                            MessageBox.Show($"PDF généré avec succès : {filename}", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void generatePdfBtn_Click(object sender, EventArgs e)
        {
            if (tabpaiement.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in tabpaiement.SelectedRows)
                {
                    string nom = row.Cells[1].Value.ToString();
                    string prenom = row.Cells[2].Value.ToString();
                    string fonction = row.Cells[3].Value.ToString();
                    string typePaiement = row.Cells[4].Value.ToString();
                    decimal salaire = Convert.ToDecimal(row.Cells[5].Value);
                    decimal primes = Convert.ToDecimal(row.Cells[6].Value);
                    decimal avances = Convert.ToDecimal(row.Cells[7].Value);
                    decimal dettes = Convert.ToDecimal(row.Cells[8].Value);
                    decimal salaireNet = Convert.ToDecimal(row.Cells[9].Value);

                    await GeneratePdfForEmployee(nom, prenom, fonction, typePaiement, salaire, primes, avances, dettes, salaireNet);
                }
            }
            else
            {
                MessageBox.Show("Please select at least one employee to generate the PDF.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panelPaiement.Visible = false;
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

        private void tabpaiement_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UPaiement_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void DateEntrerEmployes_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
