using SNOS_Report.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.UI.WebControls;

namespace SNOS_Report.Models.DataClass
{
    public class Dashboard_data
    {
        public static List<Top5list> gettopthick_day(int line)
        {
            using (var data = new SND_SNOSEntities())
            {
                DateTime datetime = DateTime.Today;
                //day
                DateRange datarange = new DateRange();
                datarange.Start = datetime;
                datarange.End = datetime.AddDays(1).AddSeconds(-1);
                List<Order_data> topthickday;
                Order order = new Order();
                if (line != 0)
                {

                    topthickday = order.getorder(datarange.Start, datarange.End, line);
                }
                else
                {

                    topthickday = order.getorderallline(datarange.Start, datarange.End);
                }

                var groupedCustomerList = topthickday.GroupBy(u => u.THICK)
                    .Select(g => new { THICK = g.Key, count = g.Count() }).OrderByDescending(d => d.count).Take(5).ToList();
                List<Top5list> list = new List<Top5list>();
                foreach (var d in groupedCustomerList)
                {

                    Top5list x = new Top5list();
                    if (d.THICK != 0)
                    {
                        x.Total = d.count;
                        x.THICK = d.THICK;
                    }
                    else
                    {
                        x.Total = 0;
                        x.THICK = 0;
                    }

                    list.Add(x);
                }
                int miss = 5 - list.Count;
                if (miss > 0)
                {
                    for (int i = 0; i < miss; i++)
                    {
                        Top5list x = new Top5list();
                        x.Total = 0;
                        x.THICK = 0;
                        list.Add(x);
                    }
                }
                list = list.OrderByDescending(s => s.Total).ToList();
                return list;
            }

        }

        public static List<Top5list> gettopthick_week(int line)
        {
            using (var data = new SND_SNOSEntities())
            {
                DateTime datetime = DateTime.Today;
                //week
                DateRange datarange = new DateRange();
                datarange = DateRange.ThisWeek(datetime);
                List<Order_data> topthickday;
                Order order = new Order();
                if (line != 0)
                {

                    topthickday = order.getorder(datarange.Start, datarange.End, line);
                }
                else
                {

                    topthickday = order.getorderallline(datarange.Start, datarange.End);
                }

                var groupedCustomerList = topthickday.GroupBy(u => u.THICK)
                    .Select(g => new { THICK = g.Key, count = g.Count() }).OrderByDescending(d => d.count).Take(5).ToList();
                List<Top5list> list = new List<Top5list>();
                foreach (var d in groupedCustomerList)
                {

                    Top5list x = new Top5list();
                    if (d.THICK != 0)
                    {
                        x.Total = d.count;
                        x.THICK = d.THICK;
                    }
                    else
                    {
                        x.Total = 0;
                        x.THICK = 0;
                    }

                    list.Add(x);
                }
                int miss = 5 - list.Count;
                if (miss > 0)
                {
                    for (int i = 0; i < miss; i++)
                    {
                        Top5list x = new Top5list();
                        x.Total = 0;
                        x.THICK = 0;
                        list.Add(x);
                    }
                }
                list = list.OrderByDescending(s => s.Total).ToList();
                return list;
            }
        }
        public static List<Top5list> gettopthick_month(int line)
        {
            using (var data = new SND_SNOSEntities())
            {
                DateTime datetime = DateTime.Today;
                DateRange datarange = new DateRange();
                //month
                datarange = DateRange.ThisMonth(datetime);
                List<Order_data> topthickday;
                Order order = new Order();
                if (line != 0)
                {

                    topthickday = order.getorder(datarange.Start, datarange.End, line);
                }
                else
                {

                    topthickday = order.getorderallline(datarange.Start, datarange.End);
                }

                var groupedCustomerList = topthickday.GroupBy(u => u.THICK)
                    .Select(g => new { THICK = g.Key, count = g.Count() }).OrderByDescending(d => d.count).Take(5).ToList();
                List<Top5list> list = new List<Top5list>();
                foreach (var d in groupedCustomerList)
                {

                    Top5list x = new Top5list();
                    if (d.THICK != 0)
                    {
                        x.Total = d.count;
                        x.THICK = d.THICK;
                    }
                    else
                    {
                        x.Total = 0;
                        x.THICK = 0;
                    }

                    list.Add(x);
                }
                int miss = 5 - list.Count;
                if (miss > 0)
                {
                    for (int i = 0; i < miss; i++)
                    {
                        Top5list x = new Top5list();
                        x.Total = 0;
                        x.THICK = 0;
                        list.Add(x);
                    }
                }
                list = list.OrderByDescending(s => s.Total).ToList();
                return list;
            }
        }

        public static Daliy_workrate gettodayworkrate(int line)
        {
            Daliy_workrate workrate = new Daliy_workrate();
            using (var data = new SND_SNOSEntities())
            {
                DateTime datetime = DateTime.Today;
                //20.00-24.00(Last)
                DateRange datarange = new DateRange();
                int powerontime = 0;
                int stoptime = 0;
                int autoruntime = 0;
                DateTime startrec;
                DateTime lastrec;
                datarange.Start = datetime.AddHours(-4);
                datarange.End = datetime;
                List<Log_Work> datalist;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0 && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.time_20_24_Last = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }

                //00.00-04.00
                datarange = new DateRange();
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datetime;
                datarange.End = datetime.AddHours(4);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.time_00_04 = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }

                //04.00-08.00
                datarange = new DateRange();
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datetime.AddHours(4);
                datarange.End = datetime.AddHours(8);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.time_04_08 = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }

                //08.00-12.00
                datarange = new DateRange();
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datetime.AddHours(8);
                datarange.End = datetime.AddHours(12);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.time_08_12 = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }

                //12.00-16.00
                datarange = new DateRange();
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datetime.AddHours(12);
                datarange.End = datetime.AddHours(16);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.time_12_16 = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }

                //16.00-20.00
                datarange = new DateRange();
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datetime.AddHours(16);
                datarange.End = datetime.AddHours(20);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.time_16_20 = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }

                //20.00-24.00
                datarange = new DateRange();
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datetime.AddHours(20);
                datarange.End = datetime.AddHours(24);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.time_20_24_Now = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }
            }
            return workrate;
        }
        public static Daliy_workrate getyesterdayworkrate(int line)
        {
            Daliy_workrate workrate = new Daliy_workrate();
            using (var data = new SND_SNOSEntities())
            {
                DateTime datetime = DateTime.Today.AddDays(-1);
                DateRange datarange = new DateRange();
                int powerontime = 0;
                int stoptime = 0;
                int autoruntime = 0;
                DateTime startrec;
                DateTime lastrec;
                datarange.Start = datetime.AddHours(-4);
                datarange.End = datetime;
                List<Log_Work> datalist;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.time_20_24_Last = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }

                //00.00-04.00
                datarange = new DateRange();
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datetime;
                datarange.End = datetime.AddHours(4);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.time_00_04 = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }

                //04.00-08.00
                datarange = new DateRange();
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datetime.AddHours(4);
                datarange.End = datetime.AddHours(8);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.time_04_08 = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }

                //08.00-12.00
                datarange = new DateRange();
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datetime.AddHours(8);
                datarange.End = datetime.AddHours(12);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.time_08_12 = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }

                //12.00-16.00
                datarange = new DateRange();
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datetime.AddHours(12);
                datarange.End = datetime.AddHours(16);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.time_12_16 = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }

                //16.00-20.00
                datarange = new DateRange();
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datetime.AddHours(16);
                datarange.End = datetime.AddHours(20);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.time_16_20 = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }

                //20.00-24.00
                datarange = new DateRange();
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datetime.AddHours(20);
                datarange.End = datetime.AddHours(24);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.time_20_24_Now = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }
            }
            return workrate;
        }

        public static weekly_workrate getthisweekworkrate(int line)
        {
            weekly_workrate workrate = new weekly_workrate();
            using (var data = new SND_SNOSEntities())
            {
                DateTime datetime = DateTime.Today;

                //sunday
                DateRange datarange = DateRange.ThisWeek(datetime);
                int powerontime = 0;
                int stoptime = 0;
                int autoruntime = 0;
                DateTime startrec;
                DateTime lastrec;
                datarange.Start = datarange.Start;
                datarange.End = datarange.Start.AddDays(1).AddSeconds(-1);
                List<Log_Work> datalist;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.sunday = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }



                //monday
                datarange = DateRange.ThisWeek(datetime);
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datarange.Start.AddDays(1);
                datarange.End = datarange.Start.AddDays(1).AddSeconds(-1);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.monday = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }

                //tuesday
                datarange = DateRange.ThisWeek(datetime);
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datarange.Start.AddDays(2);
                datarange.End = datarange.Start.AddDays(1).AddSeconds(-1);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.tuesday = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }


                //wednesday
                datarange = DateRange.ThisWeek(datetime);
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datarange.Start.AddDays(3);
                datarange.End = datarange.Start.AddDays(1).AddSeconds(-1);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.wednesday = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }

                //thursday
                datarange = DateRange.ThisWeek(datetime);
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datarange.Start.AddDays(4);
                datarange.End = datarange.Start.AddDays(1).AddSeconds(-1);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.thursday = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }

                //Friday
                datarange = DateRange.ThisWeek(datetime);
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datarange.Start.AddDays(5);
                datarange.End = datarange.Start.AddDays(1).AddSeconds(-1);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }

                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.friday = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }

                //saturday
                datarange = DateRange.ThisWeek(datetime);
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datarange.Start.AddDays(6);
                datarange.End = datarange.Start.AddDays(1).AddSeconds(-1);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }

                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.saturday = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }
            }
            return workrate;
        }

        public static weekly_workrate getlastweekworkrate(int line)
        {
            weekly_workrate workrate = new weekly_workrate();
            using (var data = new SND_SNOSEntities())
            {
                DateTime datetime = DateTime.Today;
                //sunday
                DateRange datarange = DateRange.LastWeek(datetime);
                int powerontime = 0;
                int stoptime = 0;
                int autoruntime = 0;
                DateTime startrec;
                DateTime lastrec;
                datarange.Start = datarange.Start;
                datarange.End = datarange.Start.AddDays(1).AddSeconds(-1);
                List<Log_Work> datalist;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }

                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.sunday = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }



                //monday
                datarange = DateRange.LastWeek(datetime);
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datarange.Start.AddDays(1);
                datarange.End = datarange.Start.AddDays(1).AddSeconds(-1);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }

                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.monday = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }

                //tuesday
                datarange = DateRange.LastWeek(datetime);
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datarange.Start.AddDays(2);
                datarange.End = datarange.Start.AddDays(1).AddSeconds(-1);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.tuesday = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }


                //wednesday
                datarange = DateRange.LastWeek(datetime);
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datarange.Start.AddDays(3);
                datarange.End = datarange.Start.AddDays(1).AddSeconds(-1);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.wednesday = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }

                //thursday
                datarange = DateRange.LastWeek(datetime);
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datarange.Start.AddDays(4);
                datarange.End = datarange.Start.AddDays(1).AddSeconds(-1);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.thursday = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }

                //Friday
                datarange = DateRange.LastWeek(datetime);
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datarange.Start.AddDays(5);
                datarange.End = datarange.Start.AddDays(1).AddSeconds(-1);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.friday = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }

                //saturday
                datarange = DateRange.LastWeek(datetime);
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datarange.Start.AddDays(6);
                datarange.End = datarange.Start.AddDays(1).AddSeconds(-1);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.saturday = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }
            }
            return workrate;
        }
        public static monthly_workrate getthismonthworkrate(int line)
        {
            monthly_workrate workrate = new monthly_workrate();
            using (var data = new SND_SNOSEntities())
            {
                DateTime datetime = DateTime.Today;
                //week1
                DateRange datarange = DateRange.ThisMonth(datetime);
                int powerontime = 0;
                int stoptime = 0;
                int autoruntime = 0;
                DateTime startrec;
                DateTime lastrec;
                datarange.Start = datarange.Start;
                datarange.End = datarange.Start.AddDays(7).AddSeconds(-1);
                List<Log_Work> datalist;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.week1 = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }

                //week2
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datarange.End.AddSeconds(1);
                datarange.End = datarange.Start.AddDays(7).AddSeconds(-1);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.week2 = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }
                //week3
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datarange.End.AddSeconds(1);
                datarange.End = datarange.Start.AddDays(7).AddSeconds(-1);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.week3 = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }

                //week4
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datarange.End.AddSeconds(1);
                datarange.End = datarange.Start.AddDays(7).AddSeconds(-1);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.week4 = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }

                //week5
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datarange.End.AddSeconds(1);
                DateRange week5end = DateRange.ThisMonth(datetime);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.week5 = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }
            }
            return workrate;
        }

        public static monthly_workrate getlastmonthworkrate(int line)
        {
            monthly_workrate workrate = new monthly_workrate();
            using (var data = new SND_SNOSEntities())
            {
                DateTime datetime = DateTime.Today;
                //week1
                DateRange datarange = DateRange.LastMonth(datetime);
                int powerontime = 0;
                int stoptime = 0;
                int autoruntime = 0;
                DateTime startrec;
                DateTime lastrec;
                datarange.Start = datarange.Start;
                datarange.End = datarange.Start.AddDays(7).AddSeconds(-1);
                List<Log_Work> datalist;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.week1 = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }

                //week2
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datarange.End.AddSeconds(1);
                datarange.End = datarange.Start.AddDays(7).AddSeconds(-1);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.week2 = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }
                //week3
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datarange.End.AddSeconds(1);
                datarange.End = datarange.Start.AddDays(7).AddSeconds(-1);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.week3 = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }

                //week4
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datarange.End.AddSeconds(1);
                datarange.End = datarange.Start.AddDays(7).AddSeconds(-1);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.week4 = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }

                //week5
                powerontime = 0;
                stoptime = 0;
                autoruntime = 0;
                datarange.Start = datarange.End.AddSeconds(1);
                DateRange week5end = DateRange.ThisMonth(datetime);
                datalist = null;
                if (line != 0)
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End && s.LINE == line
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                else
                {

                    datalist = (from s in data.Log_Work
                                where s.GET_TIME > datarange.Start && s.GET_TIME <= datarange.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                if (datalist != null && datalist.Count > 0)
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
                    stoptime = powerontime - autoruntime;
                    double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                    workrate.week5 = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                }
            }
            return workrate;
        }

    }
}