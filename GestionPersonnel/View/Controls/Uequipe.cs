using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPersonnel.View.Controls
{
    public partial class Uequipe : UserControl
    {
        public Uequipe()
        {
            InitializeComponent();
        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            paneladdpost.Visible = false;
        }

        private void paneladdpost_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            panelAddEquipe.Visible = true;
            panelUpdateEquipe.Visible = false;

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            panelUpdateEquipe.Visible = true;
            panelAddEquipe.Visible = false;


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panelAddEquipe.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panelUpdateEquipe.Visible = false;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}