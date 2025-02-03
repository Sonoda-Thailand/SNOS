using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNOS.MessForm
{
    public partial class SNOS_Message : Form
    {
        public SNOS_Message(string text, int lang, string type)
        {
            InitializeComponent();
            Mes_type.Text = type;
            Message_Text.Text = text;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
