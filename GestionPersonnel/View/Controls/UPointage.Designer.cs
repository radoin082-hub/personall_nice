namespace GestionPersonnel.View.Controls
{
    partial class UPointage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UPointage));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            DateEntrerEmployes = new Guna.UI2.WinForms.Guna2DateTimePicker();
            Remarque = new DataGridViewTextBoxColumn();
            Pourcentage = new DataGridViewTextBoxColumn();
            Heur = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            Fonction = new DataGridViewTextBoxColumn();
            Prenom = new DataGridViewTextBoxColumn();
            Nom = new DataGridViewTextBoxColumn();
            tabPointage = new Guna.UI2.WinForms.Guna2DataGridView();
            searchBtn = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)tabPointage).BeginInit();
            SuspendLayout();
            // 
            // guna2TextBox1
            // 
            guna2TextBox1.BackColor = Color.White;
            guna2TextBox1.BorderRadius = 3;
            guna2TextBox1.CustomizableEdges = customizableEdges1;
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
            guna2TextBox1.IconLeft = (Image)resources.GetObject("guna2TextBox1.IconLeft");
            guna2TextBox1.Location = new Point(475, 90);
            guna2TextBox1.Margin = new Padding(3, 4, 3, 4);
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.PasswordChar = '\0';
            guna2TextBox1.PlaceholderText = "Search Here";
            guna2TextBox1.SelectedText = "";
            guna2TextBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2TextBox1.Size = new Size(338, 45);
            guna2TextBox1.TabIndex = 2;
            // 
            // DateEntrerEmployes
            // 
            DateEntrerEmployes.BackColor = SystemColors.Window;
            DateEntrerEmployes.BorderColor = Color.White;
            DateEntrerEmployes.BorderRadius = 3;
            DateEntrerEmployes.Checked = true;
            DateEntrerEmployes.CustomizableEdges = customizableEdges3;
            DateEntrerEmployes.FillColor = Color.FromArgb(45, 81, 210);
            DateEntrerEmployes.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DateEntrerEmployes.ForeColor = Color.White;
            DateEntrerEmployes.Format = DateTimePickerFormat.Long;
            DateEntrerEmployes.Location = new Point(819, 90);
            DateEntrerEmployes.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            DateEntrerEmployes.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            DateEntrerEmployes.Name = "DateEntrerEmployes";
            DateEntrerEmployes.ShadowDecoration.CustomizableEdges = customizableEdges4;
            DateEntrerEmployes.Size = new Size(278, 45);
            DateEntrerEmployes.TabIndex = 95;
            DateEntrerEmployes.Value = new DateTime(2024, 6, 6, 11, 37, 0, 603);
            DateEntrerEmployes.ValueChanged += DateEntrerEmployes_ValueChanged;
            // 
            // Remarque
            // 
            Remarque.HeaderText = "Remarque";
            Remarque.MinimumWidth = 6;
            Remarque.Name = "Remarque";
            // 
            // Pourcentage
            // 
            Pourcentage.HeaderText = "Pourcentage";
            Pourcentage.MinimumWidth = 6;
            Pourcentage.Name = "Pourcentage";
            // 
            // Heur
            // 
            Heur.HeaderText = "Heur";
            Heur.MinimumWidth = 6;
            Heur.Name = "Heur";
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            // 
            // Fonction
            // 
            Fonction.HeaderText = "Fonction";
            Fonction.MinimumWidth = 6;
            Fonction.Name = "Fonction";
            // 
            // Prenom
            // 
            Prenom.HeaderText = "Prenom";
            Prenom.MinimumWidth = 6;
            Prenom.Name = "Prenom";
            // 
            // Nom
            // 
            Nom.HeaderText = "Nom";
            Nom.MinimumWidth = 6;
            Nom.Name = "Nom";
            // 
            // tabPointage
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            tabPointage.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            tabPointage.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            tabPointage.ColumnHeadersHeight = 22;
            tabPointage.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            tabPointage.Columns.AddRange(new DataGridViewColumn[] { Nom, Prenom, Fonction, Status, Heur, Pourcentage, Remarque });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            tabPointage.DefaultCellStyle = dataGridViewCellStyle3;
            tabPointage.GridColor = Color.Black;
            tabPointage.Location = new Point(0, 153);
            tabPointage.Name = "tabPointage";
            tabPointage.RowHeadersVisible = false;
            tabPointage.RowHeadersWidth = 51;
            tabPointage.Size = new Size(1166, 411);
            tabPointage.TabIndex = 0;
            tabPointage.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            tabPointage.ThemeStyle.AlternatingRowsStyle.Font = null;
            tabPointage.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            tabPointage.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            tabPointage.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            tabPointage.ThemeStyle.BackColor = Color.White;
            tabPointage.ThemeStyle.GridColor = Color.Black;
            tabPointage.ThemeStyle.HeaderStyle.BackColor = Color.Maroon;
            tabPointage.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            tabPointage.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabPointage.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            tabPointage.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            tabPointage.ThemeStyle.HeaderStyle.Height = 22;
            tabPointage.ThemeStyle.ReadOnly = false;
            tabPointage.ThemeStyle.RowsStyle.BackColor = Color.White;
            tabPointage.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            tabPointage.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 10F);
            tabPointage.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            tabPointage.ThemeStyle.RowsStyle.Height = 29;
            tabPointage.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            tabPointage.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            tabPointage.CellContentClick += guna2DataGridView1_CellContentClick;
            // 
            // searchBtn
            // 
            searchBtn.BorderRadius = 3;
            searchBtn.CustomizableEdges = customizableEdges5;
            searchBtn.DisabledState.BorderColor = Color.DarkGray;
            searchBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            searchBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            searchBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            searchBtn.FillColor = Color.FromArgb(45, 81, 210);
            searchBtn.Font = new Font("Segoe UI", 1F);
            searchBtn.ForeColor = Color.White;
            searchBtn.Image = (Image)resources.GetObject("searchBtn.Image");
            searchBtn.Location = new Point(1103, 90);
            searchBtn.Name = "searchBtn";
            searchBtn.PressedColor = Color.White;
            searchBtn.ShadowDecoration.CustomizableEdges = customizableEdges6;
            searchBtn.Size = new Size(51, 45);
            searchBtn.TabIndex = 96;
            searchBtn.Click += searchBtn_Click;
            // 
            // UPointage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(searchBtn);
            Controls.Add(DateEntrerEmployes);
            Controls.Add(guna2TextBox1);
            Controls.Add(tabPointage);
            Name = "UPointage";
            Size = new Size(1166, 713);
            Load += UPointage_Load;
            ((System.ComponentModel.ISupportInitialize)tabPointage).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private Guna.UI2.WinForms.Guna2DateTimePicker DateEntrerEmployes;
        private DataGridViewTextBoxColumn Remarque;
        private DataGridViewTextBoxColumn Pourcentage;
        private DataGridViewTextBoxColumn Heur;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn Fonction;
        private DataGridViewTextBoxColumn Prenom;
        private DataGridViewTextBoxColumn Nom;
        private Guna.UI2.WinForms.Guna2DataGridView tabPointage;
        private Guna.UI2.WinForms.Guna2Button searchBtn;
    }
}
