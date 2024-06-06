using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPersonnel
{
    public partial class Employes : Form
    {
        public Employes()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void image1_Click(object sender, EventArgs e)
        {


            /* String imageLocation = "";
             try
             {
                 OpenFileDialog dialog = new OpenFileDialog();
                 dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*|";

                 if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                 {
                     imageLocation = dialog.FileName;

                     image1.ImageLocation = imageLocation;
                 }

             }
             catch (Exception ex)
             {
                 MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }*/





        }

        private void photoProfileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxEmployes.Image = new Bitmap(dialog.FileName);

            }

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}