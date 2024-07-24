namespace GestionPersonnel.View
{
    partial class Mainpage
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainpage));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
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
            panel2 = new Panel();
            label6 = new Label();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            sidebar = new FlowLayoutPanel();
            menubutton = new Guna.UI2.WinForms.Guna2Button();
            ajouteremploye = new Guna.UI2.WinForms.Guna2Button();
            guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            Mainpanel = new Panel();
            sidebarTimer = new System.Windows.Forms.Timer(components);
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            sidebar.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(232, 251, 253);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1598, 84);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.DimGray;
            label6.Location = new Point(91, 41);
            label6.Name = "label6";
            label6.Size = new Size(70, 20);
            label6.TabIndex = 81;
            label6.Text = "FABELEC";
            label6.Click += label6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.DimGray;
            label5.Location = new Point(572, 41);
            label5.Name = "label5";
            label5.Size = new Size(213, 20);
            label5.TabIndex = 80;
            label5.Text = "welcom to Gestion Personnel";
            label5.Click += label5_Click_1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(85, 81);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // sidebar
            // 
            sidebar.BackColor = Color.FromArgb(232, 251, 253);
            sidebar.Controls.Add(menubutton);
            sidebar.Controls.Add(ajouteremploye);
            sidebar.Controls.Add(guna2Button4);
            sidebar.Controls.Add(guna2Button1);
            sidebar.Controls.Add(guna2Button2);
            sidebar.Controls.Add(guna2Button3);
            sidebar.Location = new Point(0, 84);
            sidebar.MaximumSize = new Size(176, 817);
            sidebar.MinimumSize = new Size(62, 817);
            sidebar.Name = "sidebar";
            sidebar.Size = new Size(176, 817);
            sidebar.TabIndex = 0;
            sidebar.Paint += sidebar_Paint;
            // 
            // menubutton
            // 
            menubutton.BackColor = Color.FromArgb(232, 251, 253);
            menubutton.BorderColor = Color.FromArgb(26, 178, 255);
            menubutton.BorderRadius = 5;
            menubutton.CustomizableEdges = customizableEdges1;
            menubutton.DisabledState.BorderColor = Color.FromArgb(26, 178, 255);
            menubutton.DisabledState.CustomBorderColor = Color.FromArgb(26, 178, 255);
            menubutton.DisabledState.FillColor = Color.FromArgb(26, 178, 255);
            menubutton.DisabledState.ForeColor = Color.FromArgb(26, 178, 255);
            menubutton.FillColor = Color.FromArgb(232, 251, 253);
            menubutton.FocusedColor = Color.FromArgb(26, 178, 255);
            menubutton.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menubutton.ForeColor = Color.Gray;
            menubutton.Image = (Image)resources.GetObject("menubutton.Image");
            menubutton.ImageAlign = HorizontalAlignment.Left;
            menubutton.ImageSize = new Size(30, 30);
            menubutton.Location = new Point(3, 3);
            menubutton.Name = "menubutton";
            menubutton.PressedColor = Color.FromArgb(26, 178, 255);
            menubutton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            menubutton.Size = new Size(173, 68);
            menubutton.TabIndex = 99;
            menubutton.Text = "Menu";
            menubutton.TextAlign = HorizontalAlignment.Left;
            menubutton.TextOffset = new Point(10, 0);
            menubutton.Click += guna2Button5_Click;
            // 
            // ajouteremploye
            // 
            ajouteremploye.BackColor = Color.FromArgb(232, 251, 253);
            ajouteremploye.BorderColor = Color.FromArgb(26, 178, 255);
            ajouteremploye.BorderRadius = 5;
            ajouteremploye.CustomizableEdges = customizableEdges3;
            ajouteremploye.DisabledState.BorderColor = Color.FromArgb(26, 178, 255);
            ajouteremploye.DisabledState.CustomBorderColor = Color.FromArgb(26, 178, 255);
            ajouteremploye.DisabledState.FillColor = Color.FromArgb(26, 178, 255);
            ajouteremploye.DisabledState.ForeColor = Color.FromArgb(26, 178, 255);
            ajouteremploye.FillColor = Color.FromArgb(232, 251, 253);
            ajouteremploye.FocusedColor = Color.FromArgb(26, 178, 255);
            ajouteremploye.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ajouteremploye.ForeColor = Color.Gray;
            ajouteremploye.Image = (Image)resources.GetObject("ajouteremploye.Image");
            ajouteremploye.ImageAlign = HorizontalAlignment.Left;
            ajouteremploye.ImageSize = new Size(30, 30);
            ajouteremploye.Location = new Point(3, 77);
            ajouteremploye.Name = "ajouteremploye";
            ajouteremploye.PressedColor = Color.FromArgb(26, 178, 255);
            ajouteremploye.ShadowDecoration.CustomizableEdges = customizableEdges4;
            ajouteremploye.Size = new Size(173, 68);
            ajouteremploye.TabIndex = 94;
            ajouteremploye.Text = "Dashboard";
            ajouteremploye.TextAlign = HorizontalAlignment.Left;
            ajouteremploye.TextOffset = new Point(10, 0);
            ajouteremploye.Click += ajouteremploye_Click;
            // 
            // guna2Button4
            // 
            guna2Button4.BackColor = Color.FromArgb(232, 251, 253);
            guna2Button4.BorderRadius = 5;
            guna2Button4.CustomizableEdges = customizableEdges5;
            guna2Button4.DisabledState.BorderColor = Color.DarkGray;
            guna2Button4.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button4.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button4.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button4.FillColor = Color.FromArgb(232, 251, 253);
            guna2Button4.FocusedColor = Color.FromArgb(26, 178, 255);
            guna2Button4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button4.ForeColor = Color.Gray;
            guna2Button4.Image = (Image)resources.GetObject("guna2Button4.Image");
            guna2Button4.ImageAlign = HorizontalAlignment.Left;
            guna2Button4.ImageSize = new Size(30, 30);
            guna2Button4.Location = new Point(3, 151);
            guna2Button4.Name = "guna2Button4";
            guna2Button4.PressedColor = Color.FromArgb(26, 178, 255);
            guna2Button4.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Button4.Size = new Size(173, 68);
            guna2Button4.TabIndex = 98;
            guna2Button4.Text = "Employees";
            guna2Button4.TextAlign = HorizontalAlignment.Left;
            guna2Button4.TextOffset = new Point(10, 0);
            guna2Button4.Click += guna2Button4_Click;
            guna2Button4.DragDrop += guna2Button4_DragDrop;
            // 
            // guna2Button1
            // 
            guna2Button1.BackColor = Color.FromArgb(232, 251, 253);
            guna2Button1.BorderRadius = 5;
            guna2Button1.CustomizableEdges = customizableEdges7;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.FromArgb(232, 251, 253);
            guna2Button1.FocusedColor = Color.FromArgb(26, 178, 255);
            guna2Button1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button1.ForeColor = Color.Gray;
            guna2Button1.Image = (Image)resources.GetObject("guna2Button1.Image");
            guna2Button1.ImageAlign = HorizontalAlignment.Left;
            guna2Button1.ImageSize = new Size(33, 33);
            guna2Button1.Location = new Point(3, 225);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Button1.Size = new Size(173, 68);
            guna2Button1.TabIndex = 95;
            guna2Button1.Text = "Pointage";
            guna2Button1.TextAlign = HorizontalAlignment.Left;
            guna2Button1.TextOffset = new Point(10, 0);
            guna2Button1.Click += guna2Button1_Click;
            // 
            // guna2Button2
            // 
            guna2Button2.BackColor = Color.FromArgb(232, 251, 253);
            guna2Button2.BorderRadius = 5;
            guna2Button2.CustomizableEdges = customizableEdges9;
            guna2Button2.DisabledState.BorderColor = Color.DarkGray;
            guna2Button2.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button2.FillColor = Color.FromArgb(232, 251, 253);
            guna2Button2.FocusedColor = Color.FromArgb(26, 178, 255);
            guna2Button2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button2.ForeColor = Color.Gray;
            guna2Button2.Image = (Image)resources.GetObject("guna2Button2.Image");
            guna2Button2.ImageAlign = HorizontalAlignment.Left;
            guna2Button2.ImageSize = new Size(34, 34);
            guna2Button2.Location = new Point(3, 299);
            guna2Button2.Name = "guna2Button2";
            guna2Button2.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2Button2.Size = new Size(173, 68);
            guna2Button2.TabIndex = 96;
            guna2Button2.Text = "Payment";
            guna2Button2.TextAlign = HorizontalAlignment.Left;
            guna2Button2.TextOffset = new Point(10, 0);
            guna2Button2.Click += guna2Button2_Click;
            // 
            // guna2Button3
            // 
            guna2Button3.BackColor = Color.FromArgb(232, 251, 253);
            guna2Button3.BorderRadius = 5;
            guna2Button3.CustomizableEdges = customizableEdges11;
            guna2Button3.DisabledState.BorderColor = Color.DarkGray;
            guna2Button3.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button3.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button3.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button3.FillColor = Color.FromArgb(232, 251, 253);
            guna2Button3.FocusedColor = Color.FromArgb(26, 178, 255);
            guna2Button3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button3.ForeColor = Color.Gray;
            guna2Button3.Image = (Image)resources.GetObject("guna2Button3.Image");
            guna2Button3.ImageAlign = HorizontalAlignment.Left;
            guna2Button3.ImageSize = new Size(30, 30);
            guna2Button3.Location = new Point(3, 373);
            guna2Button3.Name = "guna2Button3";
            guna2Button3.ShadowDecoration.CustomizableEdges = customizableEdges12;
            guna2Button3.Size = new Size(166, 68);
            guna2Button3.TabIndex = 97;
            guna2Button3.Text = "Dette";
            guna2Button3.TextAlign = HorizontalAlignment.Left;
            guna2Button3.TextOffset = new Point(10, 0);
            guna2Button3.Click += guna2Button3_Click;
            // 
            // Mainpanel
            // 
            Mainpanel.BackColor = SystemColors.WindowFrame;
            Mainpanel.Location = new Point(175, 84);
            Mainpanel.Name = "Mainpanel";
            Mainpanel.Size = new Size(1423, 817);
            Mainpanel.TabIndex = 2;
            Mainpanel.Paint += Mainpanel_Paint;
            // 
            // sidebarTimer
            // 
            sidebarTimer.Tick += sidebartiker;
            // 
            // Mainpage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1598, 903);
            Controls.Add(Mainpanel);
            Controls.Add(sidebar);
            Controls.Add(panel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1450, 950);
            Name = "Mainpage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestion Personnel";
            Load += Mainpage_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            sidebar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label label5;
        private Label label6;
        private FlowLayoutPanel sidebar;
        private Panel Mainpanel;
        private Guna.UI2.WinForms.Guna2Button guna2Button4;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button ajouteremploye;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button menubutton;
        private System.Windows.Forms.Timer sidebarTimer;
    }
}