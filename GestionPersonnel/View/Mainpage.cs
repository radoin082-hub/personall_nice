using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPersonnel.View
{
    public partial class Mainpage : Form
    {
        View.Udashboard ucdashboard = new View.Udashboard();
        View.UEmployes ucemployes = new View.UEmployes();


        public Mainpage()
        {

            InitializeComponent();



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
            //show & hide underlines

            //hide lines of text




            //show & hide palens
            Mainpanel.Controls.Clear();
            Mainpanel.Controls.Add(ucdashboard);
            ucdashboard.Dock = DockStyle.Fill;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //show & hide underlines

            //hide lines of text



            //show & hide palens
            Mainpanel.Controls.Clear();
            Mainpanel.Controls.Add(ucdashboard);
            ucdashboard.Dock = DockStyle.Fill;
        }

        private void label5_Click(object sender, EventArgs e)
        {

            //show & hide underlines

            //hide lines of text



            //show & hide palens
            Mainpanel.Controls.Clear();
            Mainpanel.Controls.Add(ucemployes);
            ucemployes.Dock = DockStyle.Fill;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //show & hide underlines

            //hide lines of text




            //show & hide palens

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

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Mainpanel.Controls.Remove(ucdashboard);
            Mainpanel.Controls.Add(ucemployes);
            ucemployes.Dock = DockStyle.Fill;


        }

        private void ajouteremploye_Click(object sender, EventArgs e)
        {
            Mainpanel.Controls.Remove(ucemployes);
            Mainpanel.Controls.Add(ucdashboard);
            ucdashboard.Dock = DockStyle.Fill;

        }

        private void Mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }
        bool a;  // This indicates if the sidebar is expanding or collapsing
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void sidebartiker(object sender, EventArgs e)
        {
            if (a) // If expanding
            {
                sidebar.Width += 300;
                if (sidebar.Width >= sidebar.MaximumSize.Width)
                {
                    sidebar.Width = sidebar.MaximumSize.Width; // Ensure exact size match
                    a = false; // Switch to collapsing
                    sidebarTimer.Stop();
                }
            }
            else // If collapsing
            {
                sidebar.Width -= 300;
                if (sidebar.Width <= sidebar.MinimumSize.Width)
                {
                    sidebar.Width = sidebar.MinimumSize.Width; // Ensure exact size match
                    a = true; // Switch to expanding
                    sidebarTimer.Stop();
                }
            }
        }


        private void sidebar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
