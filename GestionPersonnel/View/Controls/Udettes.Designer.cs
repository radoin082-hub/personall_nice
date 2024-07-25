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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Udettes));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DettesGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            Nom = new DataGridViewTextBoxColumn();
            Prenom = new DataGridViewTextBoxColumn();
            Fonction = new DataGridViewTextBoxColumn();
            TotaleDette = new DataGridViewTextBoxColumn();
            MontantRetiree = new DataGridViewTextBoxColumn();
            TotalAvances = new DataGridViewTextBoxColumn();
            AddButton = new Button();
            DettesSearch = new Guna.UI2.WinForms.Guna2TextBox();
            RemoveButton = new Button();
            Modifier = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)DettesGrid).BeginInit();
            SuspendLayout();
            // 
            // DettesGrid
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            DettesGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DettesGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DettesGrid.ColumnHeadersHeight = 17;
            DettesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            DettesGrid.Columns.AddRange(new DataGridViewColumn[] { Nom, Prenom, Fonction, TotaleDette, MontantRetiree, TotalAvances, Modifier });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DettesGrid.DefaultCellStyle = dataGridViewCellStyle3;
            DettesGrid.GridColor = Color.White;
            DettesGrid.Location = new Point(3, 98);
            DettesGrid.Name = "DettesGrid";
            DettesGrid.RowHeadersVisible = false;
            DettesGrid.Size = new Size(1244, 578);
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
            DettesGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            DettesGrid.ThemeStyle.HeaderStyle.Height = 17;
            DettesGrid.ThemeStyle.ReadOnly = false;
            DettesGrid.ThemeStyle.RowsStyle.BackColor = Color.White;
            DettesGrid.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DettesGrid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            DettesGrid.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            DettesGrid.ThemeStyle.RowsStyle.Height = 25;
            DettesGrid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            DettesGrid.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
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
            TotaleDette.HeaderText = "Totale Dette";
            TotaleDette.Name = "TotaleDette";
            // 
            // MontantRetiree
            // 
            MontantRetiree.HeaderText = "Montant Retiree";
            MontantRetiree.Name = "MontantRetiree";
            // 
            // TotalAvances
            // 
            TotalAvances.HeaderText = "Totale Avances";
            TotalAvances.Name = "TotalAvances";
            // 
            // AddButton
            // 
            AddButton.BackColor = Color.Green;
            AddButton.ForeColor = Color.White;
            AddButton.Location = new Point(934, 26);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(227, 46);
            AddButton.TabIndex = 1;
            AddButton.Text = "Ajouter Dette ou Avance";
            AddButton.UseVisualStyleBackColor = false;
            // 
            // DettesSearch
            // 
            DettesSearch.BackColor = Color.White;
            DettesSearch.BorderRadius = 10;
            DettesSearch.CustomizableEdges = customizableEdges1;
            DettesSearch.DefaultText = "";
            DettesSearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            DettesSearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            DettesSearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            DettesSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            DettesSearch.FillColor = Color.FromArgb(232, 251, 253);
            DettesSearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            DettesSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DettesSearch.ForeColor = Color.Black;
            DettesSearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            DettesSearch.IconLeft = (Image)resources.GetObject("DettesSearch.IconLeft");
            DettesSearch.Location = new Point(22, 26);
            DettesSearch.Margin = new Padding(3, 4, 3, 4);
            DettesSearch.Name = "DettesSearch";
            DettesSearch.PasswordChar = '\0';
            DettesSearch.PlaceholderText = "Search Here";
            DettesSearch.SelectedText = "";
            DettesSearch.ShadowDecoration.CustomizableEdges = customizableEdges2;
            DettesSearch.Size = new Size(296, 34);
            DettesSearch.TabIndex = 2;
            // 
            // RemoveButton
            // 
            RemoveButton.BackColor = Color.Red;
            RemoveButton.ForeColor = SystemColors.Window;
            RemoveButton.Location = new Point(656, 26);
            RemoveButton.Name = "RemoveButton";
            RemoveButton.Size = new Size(227, 46);
            RemoveButton.TabIndex = 4;
            RemoveButton.Text = "Retrait Mensuel";
            RemoveButton.UseVisualStyleBackColor = false;
            // 
            // Modifier
            // 
            Modifier.HeaderText = "Modifier";
            Modifier.Name = "Modifier";
            // 
            // Udettes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            Controls.Add(RemoveButton);
            Controls.Add(DettesSearch);
            Controls.Add(AddButton);
            Controls.Add(DettesGrid);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Udettes";
            Size = new Size(1250, 679);
            Load += Udettes_Load;
            ((System.ComponentModel.ISupportInitialize)DettesGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView DettesGrid;
        private DataGridViewTextBoxColumn MontantDeMois;
        private Button AddButton;
        private Guna.UI2.WinForms.Guna2TextBox DettesSearch;
        private Button RemoveButton;
        private DataGridViewTextBoxColumn Nom;
        private DataGridViewTextBoxColumn Prenom;
        private DataGridViewTextBoxColumn Fonction;
        private DataGridViewTextBoxColumn TotaleDette;
        private DataGridViewTextBoxColumn MontantRetiree;
        private DataGridViewTextBoxColumn TotalAvances;
        private DataGridViewTextBoxColumn Modifier;
    }
}
