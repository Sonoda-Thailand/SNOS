using SNOS_Server_Check.DB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNOS_Server_Check
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        private static void BuildConnectionString()
        {
            //DEV
            //ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["SND_SystemEntities"];
            //SND_SystemEntities.ConnectionString = String.Format(settings.ToString(), "euro_admin", "Sonoda@it");
            //PRD
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["SND_SystemEntities"];
            SND_SystemEntities.ConnectionString = String.Format(settings.ToString(), "SND_ReadOnly", "Sonodathai@2023");
        }
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BuildConnectionString();
            Menu menu = new Menu();
            menu.Show();
            Application.Run();
        }
    }
}
