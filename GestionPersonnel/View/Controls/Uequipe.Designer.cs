namespace GestionPersonnel.View.Controls
{
    partial class Uequipe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Uequipe));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            tabequipe = new Guna.UI2.WinForms.Guna2DataGridView();
            N = new DataGridViewTextBoxColumn();
            Nom_Equipe = new DataGridViewTextBoxColumn();
            Chef_Equipe = new DataGridViewTextBoxColumn();
            Number_Post = new DataGridViewTextBoxColumn();
            Option = new DataGridViewButtonColumn();
            guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)tabequipe).BeginInit();
            SuspendLayout();
            // 
            // tabequipe
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            tabequipe.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(26, 101, 158);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            tabequipe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            tabequipe.ColumnHeadersHeight = 22;
            tabequipe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            tabequipe.Columns.AddRange(new DataGridViewColumn[] { N, Nom_Equipe, Chef_Equipe, Number_Post, Option });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            tabequipe.DefaultCellStyle = dataGridViewCellStyle3;
            tabequipe.GridColor = Color.FromArgb(231, 229, 255);
            tabequipe.Location = new Point(14, 84);
            tabequipe.Name = "tabequipe";
            tabequipe.RowHeadersVisible = false;
            tabequipe.RowHeadersWidth = 51;
            tabequipe.Size = new Size(1377, 188);
            tabequipe.TabIndex = 1;
            tabequipe.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            tabequipe.ThemeStyle.AlternatingRowsStyle.Font = null;
            tabequipe.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            tabequipe.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            tabequipe.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            tabequipe.ThemeStyle.BackColor = Color.White;
            tabequipe.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            tabequipe.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            tabequipe.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            tabequipe.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            tabequipe.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            tabequipe.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            tabequipe.ThemeStyle.HeaderStyle.Height = 22;
            tabequipe.ThemeStyle.ReadOnly = false;
            tabequipe.ThemeStyle.RowsStyle.BackColor = Color.White;
            tabequipe.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            tabequipe.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            tabequipe.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            tabequipe.ThemeStyle.RowsStyle.Height = 29;
            tabequipe.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            tabequipe.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            tabequipe.CellContentClick += guna2DataGridView2_CellContentClick;
            // 
            // N
            // 
            N.HeaderText = "N°";
            N.MinimumWidth = 6;
            N.Name = "N";
            // 
            // Nom_Equipe
            // 
            Nom_Equipe.HeaderText = "Nom_Equipe";
            Nom_Equipe.MinimumWidth = 6;
            Nom_Equipe.Name = "Nom_Equipe";
            // 
            // Chef_Equipe
            // 
            Chef_Equipe.HeaderText = "Chef_Equipe";
            Chef_Equipe.MinimumWidth = 6;
            Chef_Equipe.Name = "Chef_Equipe";
            // 
            // Number_Post
            // 
            Number_Post.HeaderText = "Number_Post";
            Number_Post.MinimumWidth = 6;
            Number_Post.Name = "Number_Post";
            // 
            // Option
            // 
            Option.HeaderText = "Option";
            Option.MinimumWidth = 6;
            Option.Name = "Option";
            // 
            // guna2TextBox1
            // 
            guna2TextBox1.BackColor = Color.White;
            guna2TextBox1.BorderRadius = 10;
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
            guna2TextBox1.Location = new Point(1053, 32);
            guna2TextBox1.Margin = new Padding(3, 4, 3, 4);
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.PasswordChar = '\0';
            guna2TextBox1.PlaceholderText = "Search Here";
            guna2TextBox1.SelectedText = "";
            guna2TextBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2TextBox1.Size = new Size(338, 45);
            guna2TextBox1.TabIndex = 3;
            // 
            // Uequipe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(guna2TextBox1);
            Controls.Add(tabequipe);
            Name = "Uequipe";
            Size = new Size(1417, 901);
            ((System.ComponentModel.ISupportInitialize)tabequipe).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2DataGridView tabequipe;
        private DataGridViewTextBoxColumn N;
        private DataGridViewTextBoxColumn Nom_Equipe;
        private DataGridViewTextBoxColumn Chef_Equipe;
        private DataGridViewTextBoxColumn Number_Post;
        private DataGridViewButtonColumn Option;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
    }
}
