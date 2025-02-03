using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Use_Rate_SNOS.DBCon;

namespace Use_Rate_SNOS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int nowyear = DateTime.Now.Year;
            Year.Items.Clear();
            for (int i = (nowyear - 10); i < (nowyear + 10); i++)
            {
                Year.Items.Add(i);
            }
            Year.SelectedIndex = 10;
            DS_Start.Items.Clear();
            DS_End.Items.Clear();
            NS_Start.Items.Clear();
            NS_End.Items.Clear();
            for (int i = 0; i < 24; i++)
            {
                DS_Start.Items.Add(i);
                DS_End.Items.Add(i);
                NS_Start.Items.Add(i);
                NS_End.Items.Add(i);
            }
            DatalistView.Columns.Clear();
            Mode.SelectedIndex = 0;
            DatalistView.Columns.Add("Month", 60);
            DatalistView.Columns.Add("Power On", 100);
            DatalistView.Columns.Add("Run", 100);
            DatalistView.Columns.Add("Stop", 100);
            DatalistView.Columns.Add("Rate (%)", 100);
            DS_Start.SelectedIndex = 8;
            DS_End.SelectedIndex = 20;
            NS_Start.SelectedIndex = 20;
            NS_End.SelectedIndex = 8;
            STMID.Text = "STM101";
            Line_Text.Text = "1";
        }

        private void bt_Search_Click(object sender, EventArgs e)
        {
            int year = Convert.ToInt32(Year.SelectedItem);
            string IP = "172.16.";
            int LINE = Convert.ToInt32(Line_Text.Text);
            if (STMID.Text.Length == 6)
            {

                IP += STMID.Text[3];
                IP += STMID.Text[4];
                IP += STMID.Text[5];
                IP += ".51";
                //Total
                DateTime TO_S = Convert.ToDateTime(year + "-01-01 00:00:00");
                DateTime TO_E = Convert.ToDateTime(year + "-12-31 23:59:59");
                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["UTLRATE_Entities"];
                UTLRATE_Entities.ConnectionString = String.Format(settings.ToString(), IP);
                using (var data = new UTLRATE_Entities())
                {

                    try
                    {
                        List<DPROCING> TO_UL = (from s in data.DPROCINGs
                                                where s.LINE == LINE && s.GET_TIME >= TO_S && s.GET_TIME <= TO_E
                                                select s).ToList();
                        TimeSpan tsd = new TimeSpan();

                        label4.Text = "Data of " + (from s in data.MLINE_INFO
                                                    where s.LINE == LINE
                                                    select s.LINE_NAME).FirstOrDefault();
                        tsd = TO_UL[1].GET_TIME - TO_UL[0].GET_TIME;


                        double secound_Pr = 70;//Convert.ToInt32(tsd.TotalSeconds);
                        double poweron = 0;
                        double run = 0;
                        double stop = 0;
                        int minmonth = ((TO_UL.Min(x => x.GET_TIME))).Month;
                        int maxmonth = ((TO_UL.Max(x => x.GET_TIME))).Month;
                        int month = minmonth;
                        DatalistView.Items.Clear();
                        switch (Mode.SelectedIndex)
                        {
                            case 0:
                                {
                                    foreach (DPROCING d in TO_UL)
                                    {

                                        if (month == d.GET_TIME.Month)
                                        {
                                            switch (d.LINE_STATUS)
                                            {
                                                case 1:
                                                    poweron += secound_Pr; break;
                                                case 4:
                                                    poweron += secound_Pr;
                                                    run += secound_Pr;
                                                    break;
                                                case 8:
                                                    poweron += secound_Pr;
                                                    stop += secound_Pr;
                                                    break;
                                            }

                                        }
                                        else if (month < maxmonth)
                                        {
                                            ListViewItem listViewItem = new ListViewItem(new string[] { month.ToString(), (poweron / 60).ToString("N0"), (run / 60).ToString("N0"), (stop / 60).ToString("N0"), ((run / poweron) * 100).ToString("N2"), }, -1);
                                            this.DatalistView.Items.AddRange(new ListViewItem[] { listViewItem });
                                            poweron = 0;
                                            run = 0;
                                            stop = 0;
                                            month = d.GET_TIME.Month;
                                            switch (d.LINE_STATUS)
                                            {
                                                case 1:
                                                    poweron += secound_Pr; break;
                                                case 4:
                                                    poweron += secound_Pr;
                                                    run += secound_Pr;
                                                    break;
                                                case 8:
                                                    poweron += secound_Pr;
                                                    stop += secound_Pr;
                                                    break;
                                            }
                                        }
                                    }
                                }
                                break;
                            case 1:
                                {
                                    foreach (DPROCING d in TO_UL)
                                    {

                                        if (d.GET_TIME.Hour >= DS_Start.SelectedIndex && d.GET_TIME.Hour < DS_End.SelectedIndex)
                                        {
                                            if (month == d.GET_TIME.Month)
                                            {
                                                switch (d.LINE_STATUS)
                                                {
                                                    case 1:
                                                        poweron += secound_Pr; break;
                                                    case 4:
                                                        poweron += secound_Pr;
                                                        run += secound_Pr;
                                                        break;
                                                    case 8:
                                                        poweron += secound_Pr;
                                                        stop += secound_Pr;
                                                        break;
                                                }

                                            }
                                            else if (month < maxmonth)
                                            {
                                                ListViewItem listViewItem = new ListViewItem(new string[] { month.ToString(), (poweron / 60).ToString("N0"), (run / 60).ToString("N0"), (stop / 60).ToString("N0"), ((run / poweron) * 100).ToString("N2"), }, -1);
                                                this.DatalistView.Items.AddRange(new ListViewItem[] { listViewItem });
                                                poweron = 0;
                                                run = 0;
                                                stop = 0;
                                                month = d.GET_TIME.Month;
                                                switch (d.LINE_STATUS)
                                                {
                                                    case 1:
                                                        poweron += secound_Pr; break;
                                                    case 4:
                                                        poweron += secound_Pr;
                                                        run += secound_Pr;
                                                        break;
                                                    case 8:
                                                        poweron += secound_Pr;
                                                        stop += secound_Pr;
                                                        break;
                                                }
                                            }
                                        }
                                    }
                                }
                                break;
                            case 2:
                                {
                                    foreach (DPROCING d in TO_UL)
                                    {

                                        if (d.GET_TIME.Hour >= NS_Start.SelectedIndex || d.GET_TIME.Hour < NS_End.SelectedIndex)
                                        {
                                            if (month == d.GET_TIME.Month)
                                            {
                                                switch (d.LINE_STATUS)
                                                {
                                                    case 1:
                                                        poweron += secound_Pr; break;
                                                    case 4:
                                                        poweron += secound_Pr;
                                                        run += secound_Pr;
                                                        break;
                                                    case 8:
                                                        poweron += secound_Pr;
                                                        stop += secound_Pr;
                                                        break;
                                                }

                                            }
                                            else if (month < maxmonth)
                                            {
                                                ListViewItem listViewItem = new ListViewItem(new string[] { month.ToString(), (poweron / 60).ToString("N0"), (run / 60).ToString("N0"), (stop / 60).ToString("N0"), ((run / poweron) * 100).ToString("N2"), }, -1);
                                                this.DatalistView.Items.AddRange(new ListViewItem[] { listViewItem });
                                                poweron = 0;
                                                run = 0;
                                                stop = 0;
                                                month = d.GET_TIME.Month;
                                                switch (d.LINE_STATUS)
                                                {
                                                    case 1:
                                                        poweron += secound_Pr; break;
                                                    case 4:
                                                        poweron += secound_Pr;
                                                        run += secound_Pr;
                                                        break;
                                                    case 8:
                                                        poweron += secound_Pr;
                                                        stop += secound_Pr;
                                                        break;
                                                }
                                            }
                                        }
                                    }
                                }
                                break;
                        }

                        if (month == maxmonth)
                        {
                            ListViewItem listViewItem = new ListViewItem(new string[] { month.ToString(), (poweron / 60).ToString("N0"), (run / 60).ToString("N0"), (stop / 60).ToString("N0"), ((run / poweron) * 100).ToString("N2") }, -1);
                            this.DatalistView.Items.AddRange(new ListViewItem[] { listViewItem });
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Not HaveData  " +ex.Message); }
                }
            }
            else
            {
                MessageBox.Show("STMID Not Correct");
            }


        }
    }
}
