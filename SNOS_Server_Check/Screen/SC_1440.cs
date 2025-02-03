using SNOS_Server_Check.DB;
using SNOS_Server_Check.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNOS_Server_Check.Screen
{
    public partial class SC_1440 : Form
    {
        int nowset = 1;
        int nowpage = 1;
        int maxset = 1;
        int total = 0;
        bool mode = true;
        List<SNOS_IP_Checklist> list = new List<SNOS_IP_Checklist>();
        List<Machine_Status> Showlist = new List<Machine_Status>();
        public SC_1440()
        {
            InitializeComponent();
            using (var data = new SND_SystemEntities())
            {
                list = (from s in data.SNOS_IP_Checklist where s.Contact_status == true orderby s.STM_ID select s).ToList();
            }
            setmaxset();
            timer1.Start();
            timer2.Start();
            genlist(nowpage);
            setdata();
            btn_Back.Enabled = false;
            btn_Next.Enabled = false;
            btn_Back.Visible = false;
            btn_Next.Visible = false;
            setbutton();
        }
        private void setmaxset()
        {
            total = list.Count();
            double ck = total / 20.00;
            maxset = total / 20;
            if (ck > maxset)
            {
                maxset += 1;
            }
        }
        private void setbutton()
        {
            if (maxset == nowset)
            {

                if (total > ((nowset - 1) * 20) + 15) { MC4.Visible = true; } else { MC4.Visible = false; }
                if (total > ((nowset - 1) * 20) + 10) { MC3.Visible = true; } else { MC3.Visible = false; }
                if (total > ((nowset - 1) * 20) + 5) { MC2.Visible = true; } else { MC2.Visible = false; }
                if (total > ((nowset - 1) * 20) + 0) { MC1.Visible = true; } else { MC1.Visible = false; }
            }
            else
            {
                MC4.Visible = true;
                MC3.Visible = true;
                MC2.Visible = true;
                MC1.Visible = true;
            }
        }
        private void genlist(int page)
        {
            Showlist.Clear();

            int max = (page * 5 + ((nowset - 1) * 20)) <= total ? page * 5 + ((nowset - 1) * 20) : total;
            for (int i = ((page * 5) - 5) + ((nowset - 1) * 20); i < max; i++)
            {
                Machine_Status item = new Machine_Status(list[i].IP_Address_SND);
                Showlist.Add(item);
            }


        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Now_Time.Text = DateTime.Now.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            if (mode)
            {

                if (nowpage < 4)
                {
                    nowpage++;
                    genlist(nowpage);
                    if (Showlist.Count() > 0) { setdata(); }
                    else
                    {
                        nowset = 1;
                        nowpage = 1;
                        genlist(nowpage);
                        setdata();
                    }

                }
                else if (nowset < maxset)
                {
                    nowset = nowset < maxset ? (nowset + 1) : maxset;

                    nowpage = 1;
                    genlist(nowpage);
                    setdata();
                }
                else if (nowset == maxset)
                {
                    nowset = 1;
                    nowpage = 1;
                    genlist(nowpage);
                    setdata();
                }
                setbutton();
            }

        }
        private void setdata()
        {

            int ct = 0;
            for (int i = 1; i <= 5; i++)
            {
                showdata(i);
            }
            switch (Showlist.Count())

            {
                case 0: { for (int i = 1; i <= 5; i++) { hidedata(i); } } break;
                case 1: { for (int i = 2; i <= 5; i++) { hidedata(i); } } break;
                case 2: { for (int i = 3; i <= 5; i++) { hidedata(i); } } break;
                case 3: { for (int i = 4; i <= 5; i++) { hidedata(i); } } break;
                case 4: { for (int i = 5; i <= 5; i++) { hidedata(i); } } break;
            }
            foreach (var item in Showlist)
            {
                switch (ct)
                {
                    case 0:
                        {
                            STMID1.Text = Showlist[ct].customer.STM_ID.ToString();
                            CS_Name1.Text = Showlist[ct].customer.Cus_Name.ToString();
                            IP1.Text = Showlist[ct].customer.IP_Address_SND.ToString();
                            if (Showlist[ct].status) { Status1.Image = Properties.Resources.ON_status; } else { Status1.Image = Properties.Resources.Off_Status; }
                        }
                        break;
                    case 1:
                        {
                            STMID2.Text = Showlist[ct].customer.STM_ID.ToString();
                            CS_Name2.Text = Showlist[ct].customer.Cus_Name.ToString();
                            IP2.Text = Showlist[ct].customer.IP_Address_SND.ToString();
                            if (Showlist[ct].status) { Status2.Image = Properties.Resources.ON_status; } else { Status2.Image = Properties.Resources.Off_Status; }
                        }
                        break;
                    case 2:
                        {
                            STMID3.Text = Showlist[ct].customer.STM_ID.ToString();
                            CS_Name3.Text = Showlist[ct].customer.Cus_Name.ToString();
                            IP3.Text = Showlist[ct].customer.IP_Address_SND.ToString();
                            if (Showlist[ct].status) { Status3.Image = Properties.Resources.ON_status; } else { Status3.Image = Properties.Resources.Off_Status; }
                        }
                        break;
                    case 3:
                        {
                            STMID4.Text = Showlist[ct].customer.STM_ID.ToString();
                            CS_Name4.Text = Showlist[ct].customer.Cus_Name.ToString();
                            IP4.Text = Showlist[ct].customer.IP_Address_SND.ToString();
                            if (Showlist[ct].status) { Status4.Image = Properties.Resources.ON_status; } else { Status4.Image = Properties.Resources.Off_Status; }
                        }
                        break;
                    case 4:
                        {
                            STMID5.Text = Showlist[ct].customer.STM_ID.ToString();
                            CS_Name5.Text = Showlist[ct].customer.Cus_Name.ToString();
                            IP5.Text = Showlist[ct].customer.IP_Address_SND.ToString();
                            if (Showlist[ct].status) { Status5.Image = Properties.Resources.ON_status; } else { Status5.Image = Properties.Resources.Off_Status; }
                        }
                        break;
                }
                ct++;
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Menu meun = new Menu();
            meun.Show();
            this.Close();
        }

        private void Mode_Click(object sender, EventArgs e)
        {
            if (mode)
            {
                mode = false;
                Auto.Text = "Manual";
                btn_Back.Enabled = true;
                btn_Next.Enabled = true;
                btn_Back.Visible = true;
                btn_Next.Visible = true;
            }
            else
            {
                mode = true;
                Auto.Text = "Auto";
                btn_Back.Enabled = false;
                btn_Next.Enabled = false;
                btn_Back.Visible = false;
                btn_Next.Visible = false;
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            nowset = nowset > 1 ? (nowset - 1) : 1;
            nowpage = 1;
            setbutton();
            genlist(nowpage);
            setdata();
        }

        private void MC1_Click(object sender, EventArgs e)
        {
            if (!mode)
            {
                nowpage = 1;
                genlist(nowpage);
                setdata();
            }
        }

        private void MC2_Click(object sender, EventArgs e)
        {
            if (!mode)
            {
                nowpage = 2;
                genlist(nowpage);
                setdata();
            }
        }

        private void MC3_Click(object sender, EventArgs e)
        {
            if (!mode)
            {
                nowpage = 3;
                genlist(nowpage);
                setdata();
            }
        }

        private void MC4_Click(object sender, EventArgs e)
        {
            if (!mode)
            {
                nowpage = 4;
                genlist(nowpage);
                setdata();
            }
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            nowset = nowset < maxset ? (nowset + 1) : maxset;
            nowpage = 1;
            setbutton();
            genlist(nowpage);
            setdata();
        }
        private void hidedata(int taget)
        {
            switch (taget)
            {
                case 1:
                    {
                        STMID1.Visible = false;
                        CS_Name1.Visible = false;
                        IP1.Visible = false;
                        Status1.Visible = false;
                    }
                    break;
                case 2:
                    {
                        STMID2.Visible = false;
                        CS_Name2.Visible = false;
                        IP2.Visible = false;
                        Status2.Visible = false;
                    }
                    break;
                case 3:
                    {
                        STMID3.Visible = false;
                        CS_Name3.Visible = false;
                        IP3.Visible = false;
                        Status3.Visible = false;
                    }
                    break;
                case 4:
                    {
                        STMID4.Visible = false;
                        CS_Name4.Visible = false;
                        IP4.Visible = false;
                        Status4.Visible = false;
                    }
                    break;
                case 5:
                    {
                        STMID5.Visible = false;
                        CS_Name5.Visible = false;
                        IP5.Visible = false;
                        Status5.Visible = false;
                    }
                    break;
            }

        }
        private void showdata(int taget)
        {
            switch (taget)
            {
                case 1:
                    {
                        STMID1.Visible = true;
                        CS_Name1.Visible = true;
                        IP1.Visible = true;
                        Status1.Visible = true;
                    }
                    break;
                case 2:
                    {
                        STMID2.Visible = true;
                        CS_Name2.Visible = true;
                        IP2.Visible = true;
                        Status2.Visible = true;
                    }
                    break;
                case 3:
                    {
                        STMID3.Visible = true;
                        CS_Name3.Visible = true;
                        IP3.Visible = true;
                        Status3.Visible = true;
                    }
                    break;
                case 4:
                    {
                        STMID4.Visible = true;
                        CS_Name4.Visible = true;
                        IP4.Visible = true;
                        Status4.Visible = true;
                    }
                    break;
                case 5:
                    {
                        STMID5.Visible = true;
                        CS_Name5.Visible = true;
                        IP5.Visible = true;
                        Status5.Visible = true;
                    }
                    break;
            }
        }

        private void IP1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://" + IP1.Text);
        }

        private void IP2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://" + IP2.Text);
        }

        private void IP3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://" + IP3.Text);
        }

        private void IP4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://" + IP4.Text);
        }

        private void IP5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://" + IP5.Text);
        }
    }
}
