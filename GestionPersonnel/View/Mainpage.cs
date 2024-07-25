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

namespace GestionPersonnel.View
{
    public partial class Mainpage : Form
    {
        private readonly string _connectionString;
        private readonly Udashboard ucdashboard;
        private readonly UEmployes ucemployes;
        private readonly UPointage ucpointage;
        private readonly UPaiement aa;
        private readonly Udettes ucdettes;


        public Mainpage(string connectionString)
        {
            _connectionString = connectionString;

            InitializeComponent();
            ucdashboard = new Udashboard(connectionString);
            ucemployes = new UEmployes(connectionString);
            ucdettes = new Udettes(connectionString);
            ucpointage = new UPointage(connectionString);
            aa = new UPaiement(connectionString);

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
            Mainpanel.Controls.Add(ucdettes);
            ucemployes.Dock = DockStyle.Fill;
            ucemployes.RefreshData();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Mainpanel.Controls.Clear();
            Mainpanel.Controls.Add(ucemployes);
            ucemployes.Dock = DockStyle.Fill;
            ucemployes.RefreshData();

        }

        private void ajouteremploye_Click(object sender, EventArgs e)
        {
            Mainpanel.Controls.Clear();
            Mainpanel.Controls.Add(ucdashboard);
            ucdashboard.Dock = DockStyle.Fill;

        }

        private void Mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
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
            Mainpanel.Controls.Add(ucpointage);
            ucpointage.Dock = DockStyle.Fill;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Mainpanel.Controls.Clear();
            Mainpanel.Controls.Add(aa);
            aa.Dock = DockStyle.Fill;
        }
    }
}