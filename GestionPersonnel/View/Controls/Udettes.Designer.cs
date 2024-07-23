namespace GestionPersonnel.View.Controls
{
    partial class Udettes
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DettesGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            Nom = new DataGridViewTextBoxColumn();
            Prenom = new DataGridViewTextBoxColumn();
            Fonction = new DataGridViewTextBoxColumn();
            TotaleDette = new DataGridViewTextBoxColumn();
            MontantDeMois = new DataGridViewTextBoxColumn();
            Remarque = new DataGridViewTextBoxColumn();
            button1 = new Button();
            guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)DettesGrid).BeginInit();
            SuspendLayout();
            // 
            // DettesGrid
            // 
            dataGridViewCellStyle7.BackColor = Color.White;
            DettesGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = Color.White;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            DettesGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            DettesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DettesGrid.Columns.AddRange(new DataGridViewColumn[] { Nom, Prenom, Fonction, TotaleDette, MontantDeMois, Remarque });
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.White;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle9.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            DettesGrid.DefaultCellStyle = dataGridViewCellStyle9;
            DettesGrid.GridColor = Color.White;
            DettesGrid.Location = new Point(3, 83);
            DettesGrid.Name = "DettesGrid";
            DettesGrid.RowHeadersVisible = false;
            DettesGrid.Size = new Size(1060, 593);
            DettesGrid.TabIndex = 0;
            DettesGrid.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            DettesGrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            DettesGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            DettesGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            DettesGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            DettesGrid.ThemeStyle.BackColor = Color.White;
            DettesGrid.ThemeStyle.GridColor = Color.White;
            DettesGrid.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            DettesGrid.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            DettesGrid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            DettesGrid.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            DettesGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DettesGrid.ThemeStyle.HeaderStyle.Height = 17;
            DettesGrid.ThemeStyle.ReadOnly = false;
            DettesGrid.ThemeStyle.RowsStyle.BackColor = Color.White;
            DettesGrid.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DettesGrid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            DettesGrid.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            DettesGrid.ThemeStyle.RowsStyle.Height = 25;
            DettesGrid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            DettesGrid.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            DettesGrid.CellContentClick += DettesGrid_CellContentClick;
            // 
            // Nom
            // 
            Nom.HeaderText = "Nom";
            Nom.Name = "Nom";
            // 
            // Prenom
            // 
            Prenom.HeaderText = "Prenom";
            Prenom.Name = "Prenom";
            // 
            // Fonction
            // 
            Fonction.HeaderText = "Fonction";
            Fonction.Name = "Fonction";
            // 
            // TotaleDette
            // 
            TotaleDette.HeaderText = "TotaleDette";
            TotaleDette.Name = "TotaleDette";
            // 
            // MontantDeMois
            // 
            MontantDeMois.HeaderText = "MontantDeMois";
            MontantDeMois.Name = "MontantDeMois";
            // 
            // Remarque
            // 
            Remarque.HeaderText = "Remarque";
            Remarque.Name = "Remarque";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(100, 88, 255);
            button1.ForeColor = Color.Lime;
            button1.Location = new Point(752, 18);
            button1.Name = "button1";
            button1.Size = new Size(146, 46);
            button1.TabIndex = 1;
            button1.Text = "Ajouter Dette";
            button1.UseVisualStyleBackColor = false;
            // 
            // guna2TextBox1
            // 
            guna2TextBox1.CustomizableEdges = customizableEdges1;
            guna2TextBox1.DefaultText = "";
            guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Font = new Font("Segoe UI", 9F);
            guna2TextBox1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Location = new Point(96, 18);
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.PasswordChar = '\0';
            guna2TextBox1.PlaceholderText = "";
            guna2TextBox1.SelectedText = "";
            guna2TextBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2TextBox1.Size = new Size(200, 36);
            guna2TextBox1.TabIndex = 2;
            // 
            // Udettes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(guna2TextBox1);
            Controls.Add(button1);
            Controls.Add(DettesGrid);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Udettes";
            Size = new Size(1086, 676);
            Load += Udettes_Load;
            ((System.ComponentModel.ISupportInitialize)DettesGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView DettesGrid;
        private DataGridViewTextBoxColumn Nom;
        private DataGridViewTextBoxColumn Prenom;
        private DataGridViewTextBoxColumn Fonction;
        private DataGridViewTextBoxColumn TotaleDette;
        private DataGridViewTextBoxColumn MontantDeMois;
        private DataGridViewTextBoxColumn Remarque;
        private Button button1;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
    }
}
