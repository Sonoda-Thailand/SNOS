using SNOS.Database;
using SNOS.MessForm;
using SNOS.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNOS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /*public SND_SNOSEntities()
            : base(ConnectionString)
        {
        }
    public static string ConnectionString { get; set; } = "name=SND_SNOSEntities";*/
        /// </summary>
        /// 
        private static void BuildConnectionString()
        {
            //DEV
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["SND_SNOSEntities"];
            SND_SNOSEntities.ConnectionString = String.Format(settings.ToString(), "sa", "Abcd1234");
            //PRD
            //ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["SND_SNOSEntities"];
            //SND_SNOSEntities.ConnectionString = String.Format(settings.ToString(), "SNOS", "SNOS@coilline");
        }
        public static string version;
        public static string customer_name;
        [STAThread]


        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BuildConnectionString();

            try
            {
                Versionmodel ver = new Versionmodel();
                version = ver.getversion();
                customer_name = ver.getname();
                if (version != "3.0.0")
                {
                    SNOS_Message message = new SNOS_Message(
                    "The software is too old and no more supported\n"
                    + "Please update to version :  " + version + "\n"
                    + "Please contact Sonoda Support"
                    , 1, "Error"); ;
                    message.Show();
                }
                else
                {
                    string id = ver.getid();
                    if (id == "3F2504E0-4F89-11D3-9A0C-0305E82C3301")
                    //if (id == "7D6ECC3E-3D54-4EF9-9ABD-10674BC5E85C")
                    {
                        MainMenu menu = new MainMenu();
                        menu.Show();

                        //SC_1080.Monitor.Menu menu1 = new SC_1080.Monitor.Menu();
                        //menu1.Show();
                    }
                    else
                    {
                        SNOS_Message message = new SNOS_Message(
                        "Software key incorrect", 1, "Error"); ;
                        message.Show();
                    }

                }
            }
            catch
            {
                SNOS_Message message = new SNOS_Message(
                   "Network Error\n"
                   + "Please Check network connection or Contact IT Support"
                   , 1, "Error"); ;
                message.Show();
            }
            Application.Run();
        }
    }
}
