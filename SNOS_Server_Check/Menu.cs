using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNOS_Server_Check
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            Size.SelectedIndex = 0;
        }
        private void Start_Click(object sender, EventArgs e)
        {
            switch (Size.SelectedIndex)
            {
                case 0:
                    {
                        Screen.SC_1080 monitor = new Screen.SC_1080();
                        monitor.Show();
                        this.Close();
                    }
                    break;
                case 1:
                    {
                        Screen.SC_1440 monitor = new Screen.SC_1440();
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
    }
}
