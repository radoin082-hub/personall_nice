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

namespace GestionPersonnel.View.Controls
{
    public partial class UPointage : UserControl
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public UPointage(string connectionString)
        {
            _connectionString = connectionString;

            InitializeComponent();
        }

        private void TabPointage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DateEntrerEmployes_ValueChanged(object sender, EventArgs e)
        {

        }

        private void UPointage_Load(object sender, EventArgs e)
        {

        }

        private void searchBtn_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
