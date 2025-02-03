using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACTETHERLib;
using ActUtlTypeLib;

namespace PLC_Read
{
    public partial class Form1 : Form
    {
        public ActUtlType plc;
        public Form1()
        {
            InitializeComponent();
            try
            {
                plc = new ActUtlType();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            plc.ActLogicalStationNumber = 1;
            plc.Open();
            label3.Text = "Connected";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            plc.Close();
            label3.Text = "Disconnected";
        }

        private void bu(object sender, EventArgs e)
        {
            int result;
            plc.GetDevice(speed.Text, out result);
            thick.Text = result.ToString();
        }

        //private void bu(object sender, EventArgs e)
        //{
        //    plc.SetDevice(speed.Text, Convert.ToInt16(thick.Text));
        //}

        private void btn_Read_Click(object sender, EventArgs e)
        {
            int result;
            plc.GetDevice("W200", out result);
            Lenght.Text = result.ToString();
            plc.GetDevice("W202", out result);
            speed.Text = result.ToString();
            plc.GetDevice("W204", out result);
            thick.Text = result.ToString();
            plc.GetDevice("W206", out result);
            Result.Text = result.ToString();
            plc.GetDevice("W208", out result);
            plan.Text = result.ToString();
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int result;
            plc.GetDevice("W200", out result);
            Lenght.Text = result.ToString();
            plc.GetDevice("W202", out result);
            speed.Text = result.ToString();
            plc.GetDevice("W204", out result);
            thick.Text = result.ToString();
            plc.GetDevice("W206", out result);
            Result.Text = result.ToString();
            plc.GetDevice("W208", out result);
            plan.Text = result.ToString();
            timer1.Start();
        }
    }
}
