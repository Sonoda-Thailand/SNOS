using CodeArtEng.Gauge;
using SNOS.Database;
using SNOS.Model;
using SNOS.Model.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNOS.SC_1440.Monitor
{
    public partial class Monitor : Form
    {
        int nowpage = 1;
        int nowmc = 1;
        int maxpage = 1;
        bool mode = true;
        private List<Mac_Spec> linelist = new List<Mac_Spec>();
        public Monitor()
        {
            InitializeComponent();
            using (var data = new SND_SNOSEntities())
            {
                linelist = (from s in data.Mac_Spec orderby s.Line_No ascending select s).ToList();
            }
            setdefault();
            setcsname();
            setmacbtn(nowpage);
            setmaxpage();
            setdata(MC1.Text);
            btn_Back.Enabled = false;
            btn_Next.Enabled = false;
            btn_Back.Visible = false;
            btn_Next.Visible = false;
            timer1.Start();
            timer2.Start();
        }
        private void setcsname()
        {
            CS_name.Text = Program.customer_name;
        }
        private void setdefault()
        {
            Length.Value = 0;
            Plan.Value = 0;
            Results.Value = 0;
            Thick.Value = 0;
            Linespeed.Value = 0;
            Line_Sp.Text = 0.ToString();
            StatusLabel.Text = format_Status(0);
            StatusLabel.BackColor = Color.Black;
            StatusLabel.ForeColor = Color.White;
            AlertLabel.Visible = false;
            Error_Message.Visible = false;
            Length.Maximum = 99999999;
            Plan.Maximum = 99999999;
            Results.Maximum = 1;
        }
        private void setmaxpage()
        {
            int total = linelist.Count();
            double ck = total / 4.00;
            maxpage = total / 4;
            if (ck > maxpage)
            {
                maxpage += 1;
            }
        }
        private void setmacbtn(int page)
        {
            int from = (4 * page) - 1;
            if (page < maxpage)
            {

                MC1.Text = linelist[from - 3].Line_Name;
                MC2.Text = linelist[from - 2].Line_Name;
                MC3.Text = linelist[from - 1].Line_Name;
                MC4.Text = linelist[from].Line_Name;
                MC1.Visible = true;
                MC2.Visible = true;
                MC3.Visible = true;
                MC4.Visible = true;
            }
            else
            {
                try { MC1.Text = linelist[from - 3] != null ? linelist[from - 3].Line_Name : ""; } catch { MC1.Visible = false; }
                try { MC2.Text = linelist[from - 2] != null ? linelist[from - 2].Line_Name : ""; } catch { MC2.Visible = false; }
                try { MC3.Text = linelist[from - 1] != null ? linelist[from - 1].Line_Name : ""; } catch { MC3.Visible = false; }
                try { MC4.Text = linelist[from] != null ? linelist[from].Line_Name : ""; } catch { MC4.Visible = false; }

            }
        }
        private void setlastwork(Realtime_SNOS realtime)
        {
            try
            {
                Lastwork data = realtime.getlastwork();
                if (realtime.getlinetype() == 2)
                {
                    last_size.Text = data.get_size().ToString("F0") + "(PCS)";
                }
                else
                {
                    last_size.Text = data.get_size().ToString("F0") + "(m)";
                }
                Latest_worktimeLabel.Text = data.get_usedtime();
            }
            catch
            {
                last_size.Text = "0 (m)";
                Latest_worktimeLabel.Text = "0 min.";
            }

        }
        private void updatedata(string linename)
        {

            Realtime_SNOS realtime = new Realtime_SNOS(linename);
            MC_Name.Text = linename;
            DateTime today = DateTime.Now.Date;
            setlastwork(realtime);
            setworkrate(realtime);
            Log_Work nowstatus = realtime.getlaststatus();
            if (nowstatus != null)
            {
                switch (nowstatus.LINE_STATUS)
                {
                    case 1:
                        {
                            StatusLabel.BackColor = Color.Yellow;
                            StatusLabel.ForeColor = Color.Red;
                        }
                        break;
                    case 2:
                        {
                            StatusLabel.BackColor = Color.Red;
                            StatusLabel.ForeColor = Color.White;
                            Length.Value = 0;
                            Plan.Value = 0;
                            Results.Value = 0;
                            Thick.Value = 0;
                            Linespeed.Value = 0;
                            Line_Sp.Text = 0.ToString();
                            StatusLabel.Text = format_Status(2);
                        }
                        break;
                    case 4:
                        {
                            StatusLabel.BackColor = Color.Green;
                            StatusLabel.ForeColor = Color.White;
                        }
                        break;
                    case 8:
                        {
                            StatusLabel.BackColor = Color.Yellow;
                            StatusLabel.ForeColor = Color.Red;
                        }
                        break;
                    case 16:
                        {
                            StatusLabel.BackColor = Color.Red;
                            StatusLabel.ForeColor = Color.White;
                        }
                        break;
                    default:
                        {
                            StatusLabel.BackColor = Color.Black;
                            StatusLabel.ForeColor = Color.White;
                            //PowOnMinLabel.Text = (0 / 60).ToString() + " min.";
                            //PowOnDateLabel.Text = gettimeformat(0);
                            //RunMinLabel.Text = (0 / 60).ToString() + " min."; ;
                            //RunDayLabel.Text = gettimeformat(0);
                            //StopMinLabel.Text = (0 / 60).ToString() + " min."; ;
                            //StopDayLabel.Text = gettimeformat(0);
                            //Workrate.Value = 0;
                        }
                        break;
                }
                if (realtime.getlinetype() == 2)
                {
                    if (nowstatus.PILER_NO1 == true)
                    {
                        Rest_PLst.Text = "Piler No.1";
                        Recoiler_Status.Image = Properties.Resources.ON_status;
                    }
                    else if (nowstatus.PILER_NO2 == true)
                    {
                        Rest_PLst.Text = "Piler No.2";
                        Recoiler_Status.Image = Properties.Resources.ON_status;
                    }
                    else
                    {
                        Rest_PLst.Text = "Piler Off";
                        Recoiler_Status.Image = Properties.Resources.Off_Status;
                    }
                }
                else {
                    Rest_PLst.Text = "Recoiler Status";
                    if (nowstatus.RECOIL_expand)
                    {
                        Recoiler_Status.Image = Properties.Resources.ON_status;
                    }
                    else
                    {
                        Recoiler_Status.Image = Properties.Resources.Off_Status;
                    }
                }
                if (nowstatus.LINE_STATUS != 2)
                {
                    Length.Value = (double)nowstatus.SIZE;
                    Plan.Value = (double)nowstatus.PLAN;
                    Results.Value = (double)nowstatus.RESULT;
                    Thick.Value = (double)nowstatus.THICK;
                    Linespeed.Value = (double)nowstatus.SPEED;
                    Line_Sp.Text = nowstatus.SPEED.ToString();
                    StatusLabel.Text = format_Status(nowstatus.LINE_STATUS);
                    if (nowstatus.LINE_STATUS == 16)
                    {
                        AlertLabel.Visible = true;
                        Error_Message.Visible = true;
                        Error_Message.Text = geterror(nowstatus.LINE, realtime);
                    }
                    else
                    {
                        AlertLabel.Visible = false;
                        Error_Message.Visible = false;
                    }
                    if (nowstatus.SIZE == 0) { Length.Maximum = 99999999; }
                    if (nowstatus.PLAN == 0) { Plan.Maximum = 99999999; }
                    if (nowstatus.RESULT == 0) { Results.Maximum = 1; }
                }
                if (nowstatus.LINE_STATUS == 0)
                {
                    Length.Value = 0;
                    Plan.Value = 0;
                    Results.Value = 0;
                    Thick.Value = 0;
                    Linespeed.Value = 0;
                    Line_Sp.Text = 0.ToString();
                    StatusLabel.Text = format_Status(0);
                    StatusLabel.BackColor = Color.Black;
                    StatusLabel.ForeColor = Color.White;
                    AlertLabel.Visible = false;
                    Error_Message.Visible = false;
                    Recoiler_Status.Image = Properties.Resources.Off_Status;
                }
            }
            else
            {
                Length.Value = 0;
                Plan.Value = 0;
                Results.Value = 0;
                Thick.Value = 0;
                Linespeed.Value = 0;
                Line_Sp.Text = 0.ToString();
                StatusLabel.Text = format_Status(2);
                StatusLabel.BackColor = Color.Red;
                StatusLabel.ForeColor = Color.White;
                AlertLabel.Visible = false;
                Error_Message.Visible = false;
                Recoiler_Status.Image = Properties.Resources.Off_Status;
            }
        }

        private void setdata(string linename)
        {
            setdefault();
            Realtime_SNOS realtime = new Realtime_SNOS(linename);
            MC_Name.Text = linename;
            DateTime today = DateTime.Now.Date;
            setlastwork(realtime);
            setworkrate(realtime);
            set_Spec(realtime);
            Log_Work nowstatus = realtime.getlaststatus();
            if (realtime.getlinetype() == 2)
            {
                Coiltype.Text = "Cutting Order";
                result_lable.Text = "Number Of Cut";
                Plan.Unit = "Plan\n(PCS)";
                Results.Unit = "Results\n(PCS)";
                Length.Unit = "Order size\n(mm)";
                Length.Maximum = 99999999;
                Length.InfoPage = 0;
                Length.InfoMode = 0;
                Plan.Maximum = 99999999;
                Plan.InfoMode = 0;
                Plan.InfoPage = 0;
                Results.Maximum = 1;
                Rest_PLst.Text = "Piler Off";
                Recoiler_Status.Image = Properties.Resources.Off_Status;
            }
            else
            {
                Plan.Maximum = 1;
                Results.Maximum = 1;
                Length.InfoPage = GaugeInfoType.Range | GaugeInfoType.Limits;
                Length.InfoMode = GaugeInfoMode.MouseOver;
                Plan.InfoMode = GaugeInfoMode.MouseOver;
                Plan.InfoPage = GaugeInfoType.Range | GaugeInfoType.Limits;
                Coiltype.Text = "Master Coil";
                result_lable.Text = "Coil range";
                Plan.Unit = "Plan\n(m)";
                Results.Unit = "Results\n(m)";
                Length.Unit = "Length\n(m)";
                Rest_PLst.Text = "Recoiler Status";
                Recoiler_Status.Image = Properties.Resources.Off_Status;
            }
            if (nowstatus != null)
            {


                switch (nowstatus.LINE_STATUS)
                {
                    case 1:
                        {
                            StatusLabel.BackColor = Color.Yellow;
                            StatusLabel.ForeColor = Color.Red;
                        }
                        break;
                    case 2:
                        {
                            StatusLabel.BackColor = Color.Red;
                            StatusLabel.ForeColor = Color.White;
                            Length.Value = 0;
                            Plan.Value = 0;
                            Results.Value = 0;
                            Thick.Value = 0;
                            Linespeed.Value = 0;
                            Line_Sp.Text = 0.ToString();
                            StatusLabel.Text = format_Status(2);
                        }
                        break;
                    case 4:
                        {
                            StatusLabel.BackColor = Color.Green;
                            StatusLabel.ForeColor = Color.White;
                        }
                        break;
                    case 8:
                        {
                            StatusLabel.BackColor = Color.Yellow;
                            StatusLabel.ForeColor = Color.Red;
                        }
                        break;
                    case 16:
                        {
                            StatusLabel.BackColor = Color.Red;
                            StatusLabel.ForeColor = Color.White;
                        }
                        break;
                    default:
                        {
                            StatusLabel.BackColor = Color.Black;
                            StatusLabel.ForeColor = Color.White;
                            //PowOnMinLabel.Text = (0 / 60).ToString() + " min.";
                            //PowOnDateLabel.Text = gettimeformat(0);
                            //RunMinLabel.Text = (0 / 60).ToString() + " min."; ;
                            //RunDayLabel.Text = gettimeformat(0);
                            //StopMinLabel.Text = (0 / 60).ToString() + " min."; ;
                            //StopDayLabel.Text = gettimeformat(0);
                            //Workrate.Value = 0;
                        }
                        break;
                }

                if (realtime.getlinetype() == 2)
                {
                    Coiltype.Text = "Cutting Order";
                    result_lable.Text = "Number Of Cut";
                    Plan.Unit = "Plan\n(PCS)";
                    Results.Unit = "Results\n(PCS)";
                    Length.Unit = "Order size\n(mm)";
                    Length.Maximum = 99999999;
                    Length.InfoPage = 0;
                    Length.InfoMode = 0;
                    Plan.Maximum = 99999999;
                    Plan.InfoMode = 0;
                    Plan.InfoPage = 0;
                    Results.Maximum = (double)nowstatus.PLAN;
                    if (nowstatus.PILER_NO1 == true)
                    {
                        Rest_PLst.Text = "Piler No.1";
                        Recoiler_Status.Image = Properties.Resources.ON_status;
                    }
                    else if (nowstatus.PILER_NO2 == true)
                    {
                        Rest_PLst.Text = "Piler No.2";
                        Recoiler_Status.Image = Properties.Resources.ON_status;
                    }
                    else
                    {
                        Rest_PLst.Text = "Piler Off";
                        Recoiler_Status.Image = Properties.Resources.Off_Status;
                    }

                }
                else
                {
                    Plan.Maximum = (double)nowstatus.SIZE;
                    Results.Maximum = (double)nowstatus.RESULT;
                    Length.InfoPage = GaugeInfoType.Range | GaugeInfoType.Limits;
                    Length.InfoMode = GaugeInfoMode.MouseOver;
                    Plan.InfoMode = GaugeInfoMode.MouseOver;
                    Plan.InfoPage = GaugeInfoType.Range | GaugeInfoType.Limits;
                    Coiltype.Text = "Master Coil";
                    result_lable.Text = "Coil range";
                    Plan.Unit = "Plan\n(m)";
                    Results.Unit = "Results\n(m)";
                    Length.Unit = "Length\n(m)";
                    Rest_PLst.Text = "Recoiler Status";
                    if (nowstatus.RECOIL_expand)
                    {
                        Recoiler_Status.Image = Properties.Resources.ON_status;
                    }
                    else
                    {
                        Recoiler_Status.Image = Properties.Resources.Off_Status;
                    }
                }
                if (nowstatus.LINE_STATUS != 2)
                {
                    Length.Value = (double)nowstatus.SIZE;
                    Length.Maximum = (double)nowstatus.SIZE;
                    if (realtime.getlinetype() == 2)
                    {
                        Plan.Value = (double)nowstatus.PLAN;
                        Plan.Maximum = (double)nowstatus.PLAN;
                    }
                    else
                    {
                        Plan.Value = (double)nowstatus.PLAN;
                        Plan.Maximum = (double)nowstatus.SIZE;
                    }
                    Results.Value = (double)nowstatus.RESULT;
                    Results.Maximum = (double)nowstatus.PLAN;
                    Thick.Value = (double)nowstatus.THICK;
                    Linespeed.Value = (double)nowstatus.SPEED;
                    Line_Sp.Text = nowstatus.SPEED.ToString();
                    StatusLabel.Text = format_Status(nowstatus.LINE_STATUS);
                    if (nowstatus.LINE_STATUS == 16)
                    {
                        AlertLabel.Visible = true;
                        Error_Message.Visible = true;
                        Error_Message.Text = geterror(nowstatus.LINE, realtime);
                    }
                    else
                    {
                        AlertLabel.Visible = false;
                        Error_Message.Visible = false;
                    }
                    if (nowstatus.SIZE == 0) { Length.Maximum = 99999999; }
                    if (nowstatus.PLAN == 0) { Plan.Maximum = 99999999; }
                    if (nowstatus.RESULT == 0) { Results.Maximum = 1; }
                }
                else if (nowstatus.LINE_STATUS == 2)
                {
                    Length.Value = 0;
                    Plan.Value = 0;
                    Results.Value = 0;
                    Thick.Value = 0;
                    Linespeed.Value = 0;
                    Line_Sp.Text = 0.ToString();
                    StatusLabel.Text = format_Status(2);
                    StatusLabel.BackColor = Color.Red;
                    StatusLabel.ForeColor = Color.White;
                    AlertLabel.Visible = false;
                    Error_Message.Visible = false;
                    Length.Maximum = 99999999;
                    Plan.Maximum = 99999999;
                    Results.Maximum = 1;
                    Recoiler_Status.Image = Properties.Resources.Off_Status;
                }
                if (nowstatus.LINE_STATUS == 0)
                {
                    Length.Value = 0;
                    Plan.Value = 0;
                    Results.Value = 0;
                    Thick.Value = 0;
                    Linespeed.Value = 0;
                    Line_Sp.Text = 0.ToString();
                    StatusLabel.Text = format_Status(0);
                    StatusLabel.BackColor = Color.Black;
                    StatusLabel.ForeColor = Color.White;
                    AlertLabel.Visible = false;
                    Error_Message.Visible = false;
                }
            }
            else
            {
                Length.Value = 0;
                Plan.Value = 0;
                Results.Value = 0;
                Thick.Value = 0;
                Linespeed.Value = 0;
                Line_Sp.Text = 0.ToString();
                StatusLabel.Text = format_Status(2);
                StatusLabel.BackColor = Color.Red;
                StatusLabel.ForeColor = Color.White;
                AlertLabel.Visible = false;
                Error_Message.Visible = false;
                Recoiler_Status.Image = Properties.Resources.Off_Status;
            }

        }
        private string geterror(int Line, Realtime_SNOS realtime)
        {
            string text = "";
            using (var data = new SND_SNOSEntities())
            {
                var log_Error = (from s in data.Log_Error where s.LINE == Line orderby s.Error_Time descending select s).FirstOrDefault();
                int linetype = realtime.getlinetype();
                text = (from s in data.Error_Mapping where s.LINE_TYPE == linetype && s.Error_No == log_Error.Error_Number && s.Language == "en" select s).FirstOrDefault().Title;
            }
            return text;
        }
        private string format_Status(int data)
        {
            string text = "";
            switch (data)
            {
                case 1:
                    text = "Power On";
                    break;
                case 2:
                    text = "Power Off";
                    break;
                case 4:
                    text = "Auto Run";
                    break;
                case 8:
                    text = "Stop";
                    break;
                case 16:
                    text = "Error";
                    break;
                default:
                    text = "Offline";
                    break;
            }
            return text;
        }
        private void set_Spec(Realtime_SNOS realtime)
        {
            Mac_Spec spec = realtime.GetMac_Spec();
            Thick.Maximum = (double)spec.Think_M;
            Thick.ErrorLimit = (double)spec.Think_A;
            Thick.WarningLimit = (double)spec.Think_W;

            //Length.Maximum = (double)spec.Uncoil_M;
            Length.ErrorLimit = double.NaN;
            Length.WarningLimit = double.NaN;

            Plan.ErrorLimit = double.NaN;
            Plan.WarningLimit = double.NaN;

            Results.ErrorLimit = double.NaN;
            Results.WarningLimit = double.NaN;

            Linespeed.Maximum = (double)spec.Speed_M;
            Linespeed.ErrorLimit = double.NaN;
            Linespeed.WarningLimit = (double)spec.Speed_W;

            Workrate.Maximum = (double)spec.Work_rate_M;
            Workrate.ErrorLimit = (double)spec.Work_rate_A;
            Workrate.WarningLimit = (double)spec.Work_rate_W;

        }
        private void Close_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Close();
        }
        private void setworkrate(Realtime_SNOS realtime)
        {
            List<Log_Work> datalist = realtime.getlistpros();
            DateTime startrec;
            DateTime lastrec;
            int powerontime = 0;
            int stoptime = 0;
            int autoruntime = 0;
            using (var data = new SND_SNOSEntities())
            {
                try
                {
                    //AlertLabel.Visible = false;
                    //Error_Message.Text = "";
                    //Error_Message.Visible = false;
                    if (datalist != null)
                    {
                        Log_Work startlog = datalist.OrderBy(x => x.GET_TIME).FirstOrDefault();
                        startrec = startlog.GET_TIME;
                        lastrec = startrec;
                        foreach (Log_Work log in datalist)
                        {

                            DateTime nowrec = log.GET_TIME;
                            if (log != null)
                            {
                                if (log.LINE_STATUS == 4)
                                {
                                    if ((nowrec - lastrec).TotalSeconds < 60)
                                    {
                                        int sumsec = (int)(nowrec - lastrec).TotalSeconds;
                                        autoruntime += sumsec;
                                        powerontime += sumsec;
                                    }

                                }
                                else
                                {
                                    if ((nowrec - lastrec).TotalSeconds < 60)
                                    {
                                        int sumsec = (int)(nowrec - lastrec).TotalSeconds;
                                        powerontime += sumsec;
                                    }
                                }
                                lastrec = nowrec;
                            }

                        }

                        PowOnMinLabel.Text = (powerontime / 60).ToString() + " min.";
                        PowOnDateLabel.Text = gettimeformat(powerontime);
                        RunMinLabel.Text = (autoruntime / 60).ToString() + " min."; ;
                        RunDayLabel.Text = gettimeformat(autoruntime);
                        stoptime = powerontime - autoruntime;
                        StopMinLabel.Text = (stoptime / 60).ToString() + " min."; ;
                        StopDayLabel.Text = gettimeformat(stoptime);
                        double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                        Workrate.Value = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                    }
                }
                catch (Exception ex)
                {
                    //AlertLabel.Visible = true;
                    //Error_Message.Text = ex.Message;
                    //Error_Message.Visible = true;
                    PowOnMinLabel.Text = (0 / 60).ToString() + " min.";
                    PowOnDateLabel.Text = gettimeformat(0);
                    RunMinLabel.Text = (0 / 60).ToString() + " min."; ;
                    RunDayLabel.Text = gettimeformat(0);
                    StopMinLabel.Text = (0 / 60).ToString() + " min."; ;
                    StopDayLabel.Text = gettimeformat(0);
                    Workrate.Value = 0;
                }

            }
        }
        private string gettimeformat(int secs)
        {
            TimeSpan t = TimeSpan.FromSeconds(secs);

            string answer = string.Format("{0:D2}h {1:D2}m {2:D2}s",
                            t.Hours,
                            t.Minutes,
                            t.Seconds,
                            t.Milliseconds);
            return answer;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Now_Time.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            switch (nowmc)
            {
                case 1: if (MC1.Visible == true) { updatedata(MC1.Text); } break;
                case 2: if (MC2.Visible == true) { updatedata(MC2.Text); } break;
                case 3: if (MC3.Visible == true) { updatedata(MC3.Text); } break;
                case 4: if (MC4.Visible == true) { updatedata(MC4.Text); } break;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (mode)
            {
                if (nowmc < 4)
                {
                    nowmc++;
                    switch (nowmc)
                    {
                        case 1: if (MC1.Visible == true) { setdata(MC1.Text); } else { nowmc = 4; timer2_Tick(sender, e); }; break;
                        case 2: if (MC2.Visible == true) { setdata(MC2.Text); } else { nowmc = 4; timer2_Tick(sender, e); }; break;
                        case 3: if (MC3.Visible == true) { setdata(MC3.Text); } else { nowmc = 4; timer2_Tick(sender, e); }; break;
                        case 4: if (MC4.Visible == true) { setdata(MC4.Text); } else { nowmc = 4; timer2_Tick(sender, e); }; break;
                    }
                }
                else if (nowpage < maxpage)
                {
                    nowpage = nowpage < maxpage ? (nowpage + 1) : maxpage;
                    setmacbtn(nowpage);
                    nowmc = 1;
                    setdata(MC1.Text);
                }
                else if (nowpage == maxpage)
                {
                    nowpage = 1;
                    setmacbtn(nowpage);
                    nowmc = 1;
                    setdata(MC1.Text);
                }
            }
            else
            {
                switch (nowmc)
                {
                    case 1: if (MC1.Visible == true) { setdata(MC1.Text); } break;
                    case 2: if (MC2.Visible == true) { setdata(MC2.Text); } break;
                    case 3: if (MC3.Visible == true) { setdata(MC3.Text); } break;
                    case 4: if (MC4.Visible == true) { setdata(MC4.Text); } break;
                }
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            nowpage = nowpage > 1 ? (nowpage - 1) : 1;
            nowmc = 1;
            setmacbtn(nowpage);
            setdata(MC1.Text);
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            nowpage = nowpage < maxpage ? (nowpage + 1) : maxpage;
            nowmc = 1;
            setmacbtn(nowpage);
            setdata(MC1.Text);
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

        private void MC1_Click(object sender, EventArgs e)
        {
            if (!mode) { setdata(MC1.Text); nowmc = 1; }
        }

        private void MC2_Click(object sender, EventArgs e)
        {
            if (!mode) { setdata(MC2.Text); nowmc = 2; }
        }

        private void MC3_Click(object sender, EventArgs e)
        {
            if (!mode) { setdata(MC3.Text); nowmc = 3; }
        }

        private void MC4_Click(object sender, EventArgs e)
        {
            if (!mode) { setdata(MC4.Text); nowmc = 4; }
        }
    }
}
