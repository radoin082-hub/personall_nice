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
            string connectionString = ConfigurationManager.ConnectionStrings["local"].ConnectionString;
            //MessageBox.Show(connectionString); l3alamia
            Application.Run(new Mainpage(connectionString));
        }
    }
}