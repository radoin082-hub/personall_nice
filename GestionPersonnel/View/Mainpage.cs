using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using GestionPersonnel.View.Controls;
using GestionPersonnel.Properties;
using Bunifu.UI.WinForms.Helpers.Transitions;


namespace GestionPersonnel.View
{
    public partial class Mainpage : Form
    {
        private readonly string _connectionString;
        private readonly Udashboard ucdashboard;
        private readonly UEmployes ucemployes;
        private readonly UPointage ucpointage;
        private readonly UPaiement ucpaiement;
        private readonly Udettes ucdettes;
        private readonly Uequipe ucequipe;
        private readonly Resources s;




        public Mainpage(string connectionString)
        {
            _connectionString = connectionString;

            InitializeComponent();
            ucdashboard = new Udashboard(connectionString);
            ucemployes = new UEmployes(connectionString);
            ucdettes = new Udettes(connectionString);
            ucpointage = new UPointage(connectionString);
            ucpaiement = new UPaiement(connectionString);
            ucequipe = new Uequipe();
            // resources = new Resources(typeof(Mainpage());

        }

        private void reset_color_button()
        {

            btnDashboard.Checked = false;
            btnDashboard.FillColor = Color.FromArgb(26, 101, 158);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Image = Properties.Resources.home__1_;

            btnEmploye.FillColor = Color.FromArgb(26, 101, 158);
            btnEmploye.ForeColor = Color.White;
            btnEmploye.Image = Properties.Resources.engineer;

            btnEquipe.FillColor = Color.FromArgb(26, 101, 158);
            btnEquipe.ForeColor = Color.White;
            btnEquipe.Image = Properties.Resources.engineers;

            btnPointage.FillColor = Color.FromArgb(26, 101, 158);
            btnPointage.ForeColor = Color.White;
            btnPointage.Image = Properties.Resources.to_do_list;

            btnPay.FillColor = Color.FromArgb(26, 101, 158);
            btnPay.ForeColor = Color.White;
            btnPay.Image = Properties.Resources.pay;


            btnDette.FillColor = Color.FromArgb(26, 101, 158);
            btnDette.ForeColor = Color.White;
            btnDette.Image = Properties.Resources.debt;


        }

        private void udashboard1_Load(object sender, EventArgs e)
        {

        }

        private void udashboard1_Load_1(object sender, EventArgs e)
        {

        }

        private void uEmployes1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

            Mainpanel.Controls.Clear();
            Mainpanel.Controls.Add(ucdashboard);
            ucdashboard.Dock = DockStyle.Fill;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            Mainpanel.Controls.Clear();
            Mainpanel.Controls.Add(ucdashboard);
            ucdashboard.Dock = DockStyle.Fill;
        }

        private void label5_Click(object sender, EventArgs e)
        {

            Mainpanel.Controls.Clear();
            Mainpanel.Controls.Add(ucemployes);
            ucemployes.Dock = DockStyle.Fill;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

            Mainpanel.Controls.Clear();
            Mainpanel.Controls.Add(ucemployes);
            ucemployes.Dock = DockStyle.Fill;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelunderlineAvanceetDette_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Mainpage_Load(object sender, EventArgs e)
        {
            Mainpanel.Controls.Clear();
            Mainpanel.Controls.Add(ucdashboard);
            ucdashboard.Dock = DockStyle.Fill;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void underlineemployes_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBoxAvanceetDette_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxAvanceetDette_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void labelNom_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

            Mainpanel.Controls.Clear();
            Mainpanel.Controls.Add(ucpointage);
            ucpointage.Dock = DockStyle.Fill;

            reset_color_button();

            btnPointage.FillColor = Color.White;
            btnPointage.ForeColor = Color.FromArgb(26, 101, 158);
            btnPointage.Image = Properties.Resources.to_do_listB;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Mainpanel.Controls.Clear();
            Mainpanel.Controls.Add(ucdashboard);
            ucdashboard.Dock = DockStyle.Fill;

            reset_color_button();

            btnDashboard.FillColor = Color.White;
            btnDashboard.ForeColor = Color.FromArgb(26, 101, 158);
            btnDashboard.Image = Properties.Resources.homeB;



        }

        private void ajouteremploye_Click(object sender, EventArgs e)
        {

            sidebarTimer.Start();
        }

        private void Mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        bool a;
        private void sidebartiker(object sender, EventArgs e)
        {
            if (a)
            {
                sidebar.Width += 70;
                if (sidebar.Width >= sidebar.MaximumSize.Width)
                {
                    sidebar.Width = sidebar.MaximumSize.Width;
                    a = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width -= 70;
                if (sidebar.Width <= sidebar.MinimumSize.Width)
                {
                    sidebar.Width = sidebar.MinimumSize.Width;
                    a = true;
                    sidebarTimer.Stop();
                }
            }
        }


        private void sidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button4_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            Mainpanel.Controls.Clear();
            Mainpanel.Controls.Add(ucemployes);
            ucemployes.Dock = DockStyle.Fill;
            ucemployes.RefreshData();

            reset_color_button();

           btnEmploye.FillColor = Color.White;
            btnEmploye.ForeColor = Color.FromArgb(26, 101, 158);
            btnEmploye.Image = Properties.Resources.engineerB;

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Mainpanel.Controls.Clear();
            Mainpanel.Controls.Add(ucequipe);
            ucequipe.Dock = DockStyle.Fill;

            reset_color_button();

            btnEquipe.FillColor = Color.White;
            btnEquipe.ForeColor = Color.FromArgb(26, 101, 158);
            btnEquipe.Image = Properties.Resources.engineersB;

        }



        private void guna2Button5_Click_2(object sender, EventArgs e)
        {


            Mainpanel.Controls.Clear();
            Mainpanel.Controls.Add(ucpaiement);
            ucpaiement.Dock = DockStyle.Fill;

            reset_color_button();

            btnPay.FillColor = Color.White;
            btnPay.ForeColor = Color.FromArgb(26, 101, 158);
            btnPay.Image = Properties.Resources.payB;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Mainpanel.Controls.Clear();
            Mainpanel.Controls.Add(ucdettes);
            ucemployes.Dock = DockStyle.Fill;
            ucemployes.RefreshData();

            reset_color_button();

            btnDette.FillColor = Color.White;
            btnDette.ForeColor = Color.FromArgb(26, 101, 158);
            btnDette.Image = Properties.Resources.debtB;
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {

           
        }
    }
}