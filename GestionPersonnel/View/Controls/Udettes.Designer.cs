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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Udettes));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            AddButton = new Button();
            DettesSearch = new Guna.UI2.WinForms.Guna2TextBox();
            DettesGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            panelDetteAvance = new Guna.UI2.WinForms.Guna2ShadowPanel();
            label1 = new Label();
            guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            label3 = new Label();
            guna2ComboBox2 = new Guna.UI2.WinForms.Guna2ComboBox();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            Phuer = new Label();
            guna2TextBox2 = new Guna.UI2.WinForms.Guna2TextBox();
            label2 = new Label();
            guna2ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            pictureBox2 = new PictureBox();
            N = new DataGridViewTextBoxColumn();
            Nom = new DataGridViewTextBoxColumn();
            Prenom = new DataGridViewTextBoxColumn();
            Fonction = new DataGridViewTextBoxColumn();
            TotaleDette = new DataGridViewTextBoxColumn();
            MontantRetiree = new DataGridViewTextBoxColumn();
            TotalAvances = new DataGridViewTextBoxColumn();
            Modifier = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)DettesGrid).BeginInit();
            panelDetteAvance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // AddButton
            // 
            AddButton.Anchor = AnchorStyles.None;
            AddButton.BackColor = Color.Green;
            AddButton.ForeColor = Color.White;
            AddButton.Location = new Point(1095, 26);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(227, 46);
            AddButton.TabIndex = 1;
            AddButton.Text = "Ajouter Dette ou Avance";
            AddButton.UseVisualStyleBackColor = false;
            AddButton.Click += AddButton_Click;
            // 
            // DettesSearch
            // 
            DettesSearch.Anchor = AnchorStyles.None;
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
            DettesSearch.Location = new Point(106, 26);
            DettesSearch.Margin = new Padding(3, 4, 3, 4);
            DettesSearch.Name = "DettesSearch";
            DettesSearch.PasswordChar = '\0';
            DettesSearch.PlaceholderText = "Search Here";
            DettesSearch.SelectedText = "";
            DettesSearch.ShadowDecoration.CustomizableEdges = customizableEdges2;
            DettesSearch.Size = new Size(295, 34);
            DettesSearch.TabIndex = 2;
            // 
            // DettesGrid
            // 
            DettesGrid.AllowUserToAddRows = false;
            DettesGrid.AllowUserToDeleteRows = false;
            DettesGrid.AllowUserToResizeColumns = false;
            DettesGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            DettesGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DettesGrid.Anchor = AnchorStyles.None;
            DettesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DettesGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DettesGrid.ColumnHeadersHeight = 28;
            DettesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            DettesGrid.Columns.AddRange(new DataGridViewColumn[] { N, Nom, Prenom, Fonction, TotaleDette, MontantRetiree, TotalAvances, Modifier });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DettesGrid.DefaultCellStyle = dataGridViewCellStyle3;
            DettesGrid.GridColor = Color.White;
            DettesGrid.Location = new Point(106, 78);
            DettesGrid.Name = "DettesGrid";
            DettesGrid.RowHeadersVisible = false;
            DettesGrid.RowHeadersWidth = 51;
            DettesGrid.RowTemplate.Height = 25;
            DettesGrid.Size = new Size(1216, 741);
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
            DettesGrid.ThemeStyle.HeaderStyle.Height = 28;
            DettesGrid.ThemeStyle.ReadOnly = false;
            DettesGrid.ThemeStyle.RowsStyle.BackColor = Color.White;
            DettesGrid.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DettesGrid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            DettesGrid.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            DettesGrid.ThemeStyle.RowsStyle.Height = 25;
            DettesGrid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            DettesGrid.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // panelDetteAvance
            // 
            panelDetteAvance.Anchor = AnchorStyles.None;
            panelDetteAvance.BackColor = Color.Transparent;
            panelDetteAvance.Controls.Add(label1);
            panelDetteAvance.Controls.Add(guna2TextBox1);
            panelDetteAvance.Controls.Add(label3);
            panelDetteAvance.Controls.Add(guna2ComboBox2);
            panelDetteAvance.Controls.Add(guna2HtmlLabel2);
            panelDetteAvance.Controls.Add(Phuer);
            panelDetteAvance.Controls.Add(guna2TextBox2);
            panelDetteAvance.Controls.Add(label2);
            panelDetteAvance.Controls.Add(guna2ComboBox1);
            panelDetteAvance.Controls.Add(guna2HtmlLabel1);
            panelDetteAvance.Controls.Add(guna2Button4);
            panelDetteAvance.Controls.Add(pictureBox2);
            panelDetteAvance.FillColor = Color.White;
            panelDetteAvance.Location = new Point(721, 107);
            panelDetteAvance.Name = "panelDetteAvance";
            panelDetteAvance.Radius = 14;
            panelDetteAvance.ShadowColor = Color.Black;
            panelDetteAvance.Size = new Size(601, 669);
            panelDetteAvance.TabIndex = 101;
            panelDetteAvance.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(72, 473);
            label1.Name = "label1";
            label1.Size = new Size(129, 20);
            label1.TabIndex = 110;
            label1.Text = "Valuer de Avance";
            // 
            // guna2TextBox1
            // 
            guna2TextBox1.BorderRadius = 10;
            guna2TextBox1.CustomizableEdges = customizableEdges3;
            guna2TextBox1.DefaultText = "";
            guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.FillColor = Color.FromArgb(232, 251, 253);
            guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2TextBox1.ForeColor = Color.Black;
            guna2TextBox1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Location = new Point(63, 483);
            guna2TextBox1.Margin = new Padding(3, 5, 3, 5);
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.PasswordChar = '\0';
            guna2TextBox1.PlaceholderText = "";
            guna2TextBox1.SelectedText = "";
            guna2TextBox1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2TextBox1.Size = new Size(504, 36);
            guna2TextBox1.TabIndex = 111;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(72, 404);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 109;
            label3.Text = "Employes";
            // 
            // guna2ComboBox2
            // 
            guna2ComboBox2.AccessibleDescription = "";
            guna2ComboBox2.BackColor = Color.White;
            guna2ComboBox2.BorderColor = Color.FromArgb(213, 218, 223);
            guna2ComboBox2.BorderRadius = 10;
            guna2ComboBox2.CustomizableEdges = customizableEdges5;
            guna2ComboBox2.DrawMode = DrawMode.OwnerDrawFixed;
            guna2ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            guna2ComboBox2.FillColor = Color.FromArgb(232, 251, 253);
            guna2ComboBox2.FocusedColor = Color.FromArgb(94, 148, 255);
            guna2ComboBox2.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2ComboBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2ComboBox2.ForeColor = Color.FromArgb(20, 157, 213);
            guna2ComboBox2.ItemHeight = 30;
            guna2ComboBox2.Location = new Point(59, 416);
            guna2ComboBox2.Name = "guna2ComboBox2";
            guna2ComboBox2.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2ComboBox2.Size = new Size(508, 36);
            guna2ComboBox2.TabIndex = 108;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            guna2HtmlLabel2.Location = new Point(72, 340);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(161, 32);
            guna2HtmlLabel2.TabIndex = 107;
            guna2HtmlLabel2.Text = "Ajouter Avance";
            // 
            // Phuer
            // 
            Phuer.AutoSize = true;
            Phuer.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Phuer.ForeColor = Color.Black;
            Phuer.Location = new Point(72, 222);
            Phuer.Name = "Phuer";
            Phuer.Size = new Size(117, 20);
            Phuer.TabIndex = 105;
            Phuer.Text = "Valuer de Dette";
            // 
            // guna2TextBox2
            // 
            guna2TextBox2.BorderRadius = 10;
            guna2TextBox2.CustomizableEdges = customizableEdges7;
            guna2TextBox2.DefaultText = "";
            guna2TextBox2.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox2.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox2.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox2.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox2.FillColor = Color.FromArgb(232, 251, 253);
            guna2TextBox2.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2TextBox2.ForeColor = Color.Black;
            guna2TextBox2.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox2.Location = new Point(63, 232);
            guna2TextBox2.Margin = new Padding(3, 5, 3, 5);
            guna2TextBox2.Name = "guna2TextBox2";
            guna2TextBox2.PasswordChar = '\0';
            guna2TextBox2.PlaceholderText = "";
            guna2TextBox2.SelectedText = "";
            guna2TextBox2.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2TextBox2.Size = new Size(504, 36);
            guna2TextBox2.TabIndex = 106;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(72, 153);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 104;
            label2.Text = "Employes";
            // 
            // guna2ComboBox1
            // 
            guna2ComboBox1.AccessibleDescription = "";
            guna2ComboBox1.BackColor = Color.White;
            guna2ComboBox1.BorderColor = Color.FromArgb(213, 218, 223);
            guna2ComboBox1.BorderRadius = 10;
            guna2ComboBox1.CustomizableEdges = customizableEdges9;
            guna2ComboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            guna2ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            guna2ComboBox1.FillColor = Color.FromArgb(232, 251, 253);
            guna2ComboBox1.FocusedColor = Color.FromArgb(94, 148, 255);
            guna2ComboBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2ComboBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2ComboBox1.ForeColor = Color.FromArgb(20, 157, 213);
            guna2ComboBox1.ItemHeight = 30;
            guna2ComboBox1.Location = new Point(59, 165);
            guna2ComboBox1.Name = "guna2ComboBox1";
            guna2ComboBox1.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2ComboBox1.Size = new Size(508, 36);
            guna2ComboBox1.TabIndex = 103;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            guna2HtmlLabel1.Location = new Point(72, 90);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(144, 32);
            guna2HtmlLabel1.TabIndex = 94;
            guna2HtmlLabel1.Text = "Ajouter Dette";
            guna2HtmlLabel1.Click += guna2HtmlLabel1_Click;
            // 
            // guna2Button4
            // 
            guna2Button4.BorderRadius = 10;
            guna2Button4.CustomizableEdges = customizableEdges11;
            guna2Button4.DisabledState.BorderColor = Color.DarkGray;
            guna2Button4.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button4.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button4.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button4.FillColor = Color.FromArgb(45, 81, 210);
            guna2Button4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button4.ForeColor = Color.White;
            guna2Button4.Location = new Point(417, 588);
            guna2Button4.Name = "guna2Button4";
            guna2Button4.ShadowDecoration.CustomizableEdges = customizableEdges12;
            guna2Button4.Size = new Size(150, 37);
            guna2Button4.TabIndex = 93;
            guna2Button4.Text = "Confirmation";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.pictureBox1_Image;
            pictureBox2.Location = new Point(34, 28);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(43, 45);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 92;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // N
            // 
            N.HeaderText = "N°";
            N.MinimumWidth = 6;
            N.Name = "N";
            N.Width = 75;
            // 
            // Nom
            // 
            Nom.HeaderText = "Nom";
            Nom.MinimumWidth = 6;
            Nom.Name = "Nom";
            Nom.Width = 178;
            // 
            // Prenom
            // 
            Prenom.HeaderText = "Prenom";
            Prenom.MinimumWidth = 6;
            Prenom.Name = "Prenom";
            Prenom.Width = 177;
            // 
            // Fonction
            // 
            Fonction.HeaderText = "Fonction";
            Fonction.MinimumWidth = 6;
            Fonction.Name = "Fonction";
            Fonction.Width = 178;
            // 
            // TotaleDette
            // 
            TotaleDette.HeaderText = "Totale Dette";
            TotaleDette.MinimumWidth = 6;
            TotaleDette.Name = "TotaleDette";
            TotaleDette.Width = 178;
            // 
            // MontantRetiree
            // 
            MontantRetiree.HeaderText = "Montant Retiree";
            MontantRetiree.MinimumWidth = 6;
            MontantRetiree.Name = "MontantRetiree";
            MontantRetiree.Width = 178;
            // 
            // TotalAvances
            // 
            TotalAvances.HeaderText = "Totale Avances";
            TotalAvances.MinimumWidth = 6;
            TotalAvances.Name = "TotalAvances";
            TotalAvances.Width = 177;
            // 
            // Modifier
            // 
            Modifier.HeaderText = "Modifier";
            Modifier.MinimumWidth = 6;
            Modifier.Name = "Modifier";
            Modifier.Resizable = DataGridViewTriState.True;
            Modifier.SortMode = DataGridViewColumnSortMode.Automatic;
            Modifier.Width = 178;
            // 
            // Udettes
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            Controls.Add(panelDetteAvance);
            Controls.Add(DettesSearch);
            Controls.Add(AddButton);
            Controls.Add(DettesGrid);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Udettes";
            Size = new Size(1423, 853);
            Load += Udettes_Load;
            ((System.ComponentModel.ISupportInitialize)DettesGrid).EndInit();
            panelDetteAvance.ResumeLayout(false);
            panelDetteAvance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridViewTextBoxColumn MontantDeMois;
        private Button AddButton;
        private Guna.UI2.WinForms.Guna2TextBox DettesSearch;
        private Guna.UI2.WinForms.Guna2DataGridView DettesGrid;
        private Guna.UI2.WinForms.Guna2ShadowPanel panelDetteAvance;
        private Guna.UI2.WinForms.Guna2Button guna2Button4;
        private PictureBox pictureBox2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1;
        private Label Phuer;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox2;
        private Label label1;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private DataGridViewTextBoxColumn N;
        private DataGridViewTextBoxColumn Nom;
        private DataGridViewTextBoxColumn Prenom;
        private DataGridViewTextBoxColumn Fonction;
        private DataGridViewTextBoxColumn TotaleDette;
        private DataGridViewTextBoxColumn MontantRetiree;
        private DataGridViewTextBoxColumn TotalAvances;
        private DataGridViewButtonColumn Modifier;
    }
}