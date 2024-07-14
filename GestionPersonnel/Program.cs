


using GestionPersonnel.View;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace GestionPersonnel
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            string connectionStringLocal = ConfigurationManager.ConnectionStrings["local"].ConnectionString;
            string connectionStringOnline = ConfigurationManager.ConnectionStrings["online"].ConnectionString;

            // Show the connection selection form
            using (var selectionForm = new ConnectionSelectionForm(connectionStringLocal, connectionStringOnline))
            {
                if (selectionForm.ShowDialog() == DialogResult.OK)
                {
                    string selectedConnectionString = selectionForm.SelectedConnectionString;
                    Application.Run(new Mainpage(selectedConnectionString));
                }
                else
                {
                       MessageBox.Show("no connection selected");
                }
            }
        }
    }
}