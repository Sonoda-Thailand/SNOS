using SNOS.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNOS
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            Size.SelectedIndex = 2;
            using (var data = new SND_SNOSEntities())
            {
                var context = from d in data.Versionchecks
                              orderby d.UpdateDate descending
                              select d.Version;

                Version_label.Text = "Ver. " + context.FirstOrDefault().ToString();
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            switch (Size.SelectedIndex)
            {
                case 0:
                    {
                        SC_1080.Monitor.Monitor monitor = new SC_1080.Monitor.Monitor();
                        monitor.Show();
                        this.Close();
                    }
                    break;
                case 1:
                    {
                        SC_1440.Monitor.Monitor monitor = new SC_1440.Monitor.Monitor();
                        monitor.Show();
                        this.Close();
                    }
                    break;
                case 2:
                    {
                        SC_2160.Monitor.Monitor monitor = new SC_2160.Monitor.Monitor();
                        monitor.Show();
                        this.Close();
                    }
                    break;
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
