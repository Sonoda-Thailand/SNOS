using SNOS_Report.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Services.Description;


namespace SNOS_Report.Models
{

    public class Order
    {

        public List<Order_data> getorder()
        {
            try
            {
                List<Order_data> dataset = new List<Order_data>();
                List<Log_Work> log_work = null;
                DateRange timeset = DateRange.ThisYear(DateTime.Now);
                using (var data = new SND_SNOSEntities())
                {
                    log_work = (from s in data.Log_Work
                                where s.LINE == 1
                                && s.GET_TIME >= timeset.Start
                                && s.GET_TIME <= timeset.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                int powerontime = 0;
                int stoptime = 0;
                int autoruntime = 0;
                DateTime start = log_work[0].GET_TIME;
                DateTime lasttime = start;
                Order_data order_Data = new Order_data();
                bool flagstart = true;
                foreach (var item in log_work)
                {

                    if (item.RECOIL_expand)
                    {
                        if (flagstart)
                        {
                            start = item.GET_TIME;
                            order_Data = null;
                            order_Data = new Order_data();
                            stoptime = 0; autoruntime = 0; powerontime = 0;
                            flagstart = false;
                        }

                        if (item.LINE_STATUS == 4)
                        {
                            if ((item.GET_TIME - lasttime).TotalSeconds < 60)
                            {
                                int sumsec = (int)(item.GET_TIME - lasttime).TotalSeconds;
                                autoruntime += sumsec;
                                powerontime += sumsec;
                            }

                        }
                        else
                        {
                            if ((item.GET_TIME - lasttime).TotalSeconds < 60)
                            {
                                int sumsec = (int)(item.GET_TIME - lasttime).TotalSeconds;
                                powerontime += sumsec;
                            }
                        }
                        if (item.LINE_STATUS == 4 && item.RECOIL_expand)
                        {
                            order_Data.Length = (double)item.PLAN;
                            order_Data.THICK = item.THICK;
                        }
                    }
                    else if (flagstart == false && item.RECOIL_expand == false)
                    {

                        order_Data.start = start;
                        order_Data.end = lasttime;
                        stoptime = powerontime - autoruntime;
                        double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                        order_Data.workrate = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                        order_Data.stop = stoptime;
                        order_Data.auto = autoruntime;
                        order_Data.poweron = powerontime;
                        //reset
                        flagstart = true;

                        dataset.Add(order_Data);
                    }

                    lasttime = item.GET_TIME;
                }
                return dataset.Take(20).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new List<Order_data>();
            }

        }
        public List<Order_data> getorder(DateTime start_para, DateTime end_para, int line)
        {
            try
            {
                List<Order_data> dataset = new List<Order_data>();
                List<Log_Work> log_work = null;
                using (var data = new SND_SNOSEntities())
                {
                    log_work = (from s in data.Log_Work
                                where s.LINE == line
                                            && s.GET_TIME >= start_para
                                            && s.GET_TIME <= end_para
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                int powerontime = 0;
                int stoptime = 0;
                int autoruntime = 0;
                DateTime start = log_work[0].GET_TIME;
                DateTime lasttime = start;
                Order_data order_Data = new Order_data();
                bool flagstart = true;
                foreach (var item in log_work)
                {

                    if (item.RECOIL_expand)
                    {
                        if (flagstart)
                        {
                            start = item.GET_TIME;
                            order_Data = null;
                            order_Data = new Order_data();
                            stoptime = 0; autoruntime = 0; powerontime = 0;
                            flagstart = false;
                        }

                        if (item.LINE_STATUS == 4)
                        {
                            if ((item.GET_TIME - lasttime).TotalSeconds < 60)
                            {
                                int sumsec = (int)(item.GET_TIME - lasttime).TotalSeconds;
                                autoruntime += sumsec;
                                powerontime += sumsec;
                            }

                        }
                        else
                        {
                            if ((item.GET_TIME - lasttime).TotalSeconds < 60)
                            {
                                int sumsec = (int)(item.GET_TIME - lasttime).TotalSeconds;
                                powerontime += sumsec;
                            }
                        }
                        if (item.LINE_STATUS == 4 && item.RECOIL_expand)
                        {
                            order_Data.Length = (double)item.PLAN;
                            order_Data.THICK = item.THICK;
                        }
                    }
                    else if (flagstart == false && item.RECOIL_expand == false)
                    {

                        order_Data.start = start;
                        order_Data.end = lasttime;
                        stoptime = powerontime - autoruntime;
                        double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                        order_Data.workrate = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                        order_Data.stop = stoptime;
                        order_Data.auto = autoruntime;
                        order_Data.poweron = powerontime;
                        //reset
                        flagstart = true;

                        dataset.Add(order_Data);
                    }

                    lasttime = item.GET_TIME;
                }
                return dataset;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new List<Order_data>();
            }

        }
        public List<Order_data> getorderallline(DateTime start_para, DateTime end_para)
        {
            try
            {
                List<Order_data> dataset = new List<Order_data>();
                List<Log_Work> log_work = null;
                using (var data = new SND_SNOSEntities())
                {
                    var mac_spec = (from s in data.Mac_Spec select s).ToList();

                    foreach (var mac in mac_spec)
                    {
                        log_work = null;

                        log_work = data.Log_Work.Where(x => x.GET_TIME >= start_para && x.LINE == mac.Line_No).OrderByDescending(x => x.GET_TIME).ToList();
                        //log_work = (from s in data.Log_Work
                        //            where s.GET_TIME >= start_para
                        //                    && s.GET_TIME <= end_para
                        //                    && s.LINE == mac.Line_No
                        //            orderby s.GET_TIME ascending
                        //            select s).ToList();

                        

                        int powerontime = 0;
                        int stoptime = 0;
                        int autoruntime = 0;
                        DateTime start = log_work[0].GET_TIME;
                        DateTime lasttime = start;
                        Order_data order_Data = new Order_data();
                        bool flagstart = true;
                        foreach (var item in log_work)
                        {
                            if (item.RECOIL_expand)
                            {
                                if (flagstart)
                                {
                                    start = item.GET_TIME;
                                    order_Data = null;
                                    order_Data = new Order_data();
                                    stoptime = 0; autoruntime = 0; powerontime = 0;
                                    flagstart = false;
                                }

                                if (item.LINE_STATUS == 4)
                                {
                                    if ((item.GET_TIME - lasttime).TotalSeconds < 60)
                                    {
                                        int sumsec = (int)(item.GET_TIME - lasttime).TotalSeconds;
                                        autoruntime += sumsec;
                                        powerontime += sumsec;
                                    }

                                }
                                else
                                {
                                    if ((item.GET_TIME - lasttime).TotalSeconds < 60)
                                    {
                                        int sumsec = (int)(item.GET_TIME - lasttime).TotalSeconds;
                                        powerontime += sumsec;
                                    }
                                }
                                if (item.LINE_STATUS == 4 && item.RECOIL_expand)
                                {
                                    order_Data.Length = (double)item.PLAN;
                                    order_Data.THICK = item.THICK;
                                }
                            }
                            else if (flagstart == false && item.RECOIL_expand == false)
                            {

                                order_Data.start = start;
                                order_Data.end = lasttime;
                                stoptime = powerontime - autoruntime;
                                double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                                order_Data.workrate = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                                order_Data.stop = stoptime;
                                order_Data.auto = autoruntime;
                                order_Data.poweron = powerontime;
                                //reset
                                flagstart = true;

                                dataset.Add(order_Data);
                            }

                            lasttime = item.GET_TIME;
                        }

                    }
                }

                return dataset;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new List<Order_data>();
            }

        }

        public List<Order_data> getorderthisweek(int line)
        {
            try
            {
                List<Order_data> dataset = new List<Order_data>();
                List<Log_Work> log_work = null;
                DateRange timeset = DateRange.ThisWeek(DateTime.Now);
                using (var data = new SND_SNOSEntities())
                {
                    log_work = (from s in data.Log_Work
                                where s.LINE == line
                                && s.GET_TIME >= timeset.Start
                                && s.GET_TIME <= timeset.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                int powerontime = 0;
                int stoptime = 0;
                int autoruntime = 0;
                DateTime start = log_work[0].GET_TIME;
                DateTime lasttime = start;
                Order_data order_Data = new Order_data();
                bool flagstart = true;
                foreach (var item in log_work)
                {

                    if (item.RECOIL_expand)
                    {
                        if (flagstart)
                        {
                            start = item.GET_TIME;
                            order_Data = null;
                            order_Data = new Order_data();
                            stoptime = 0; autoruntime = 0; powerontime = 0;
                            flagstart = false;
                        }

                        if (item.LINE_STATUS == 4)
                        {
                            if ((item.GET_TIME - lasttime).TotalSeconds < 60)
                            {
                                int sumsec = (int)(item.GET_TIME - lasttime).TotalSeconds;
                                autoruntime += sumsec;
                                powerontime += sumsec;
                            }

                        }
                        else
                        {
                            if ((item.GET_TIME - lasttime).TotalSeconds < 60)
                            {
                                int sumsec = (int)(item.GET_TIME - lasttime).TotalSeconds;
                                powerontime += sumsec;
                            }
                        }
                        if (item.LINE_STATUS == 4 && item.RECOIL_expand)
                        {
                            order_Data.Length = (double)item.PLAN;
                            order_Data.THICK = item.THICK;
                        }
                    }
                    else if (flagstart == false && item.RECOIL_expand == false)
                    {

                        order_Data.start = start;
                        order_Data.end = lasttime;
                        stoptime = powerontime - autoruntime;
                        double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                        order_Data.workrate = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                        order_Data.stop = stoptime;
                        order_Data.auto = autoruntime;
                        order_Data.poweron = powerontime;
                        //reset
                        flagstart = true;

                        dataset.Add(order_Data);
                    }

                    lasttime = item.GET_TIME;
                }
                return dataset;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new List<Order_data>();
            }

        }

        public List<Order_data> getorderthismonth(int line)
        {
            try
            {
                List<Order_data> dataset = new List<Order_data>();
                List<Log_Work> log_work = null;
                DateRange timeset = DateRange.ThisMonth(DateTime.Now);
                using (var data = new SND_SNOSEntities())
                {
                    log_work = (from s in data.Log_Work
                                where s.LINE == line
                                && s.GET_TIME >= timeset.Start
                                && s.GET_TIME <= timeset.End
                                orderby s.GET_TIME ascending
                                select s).ToList();
                }
                int powerontime = 0;
                int stoptime = 0;
                int autoruntime = 0;
                DateTime start = log_work[0].GET_TIME;
                DateTime lasttime = start;
                Order_data order_Data = new Order_data();
                bool flagstart = true;
                foreach (var item in log_work)
                {

                    if (item.RECOIL_expand)
                    {
                        if (flagstart)
                        {
                            start = item.GET_TIME;
                            order_Data = null;
                            order_Data = new Order_data();
                            stoptime = 0; autoruntime = 0; powerontime = 0;
                            flagstart = false;
                        }

                        if (item.LINE_STATUS == 4)
                        {
                            if ((item.GET_TIME - lasttime).TotalSeconds < 60)
                            {
                                int sumsec = (int)(item.GET_TIME - lasttime).TotalSeconds;
                                autoruntime += sumsec;
                                powerontime += sumsec;
                            }

                        }
                        else
                        {
                            if ((item.GET_TIME - lasttime).TotalSeconds < 60)
                            {
                                int sumsec = (int)(item.GET_TIME - lasttime).TotalSeconds;
                                powerontime += sumsec;
                            }
                        }
                        if (item.LINE_STATUS == 4 && item.RECOIL_expand)
                        {
                            order_Data.Length = (double)item.PLAN;
                            order_Data.THICK = item.THICK;
                        }
                    }
                    else if (flagstart == false && item.RECOIL_expand == false)
                    {

                        order_Data.start = start;
                        order_Data.end = lasttime;
                        stoptime = powerontime - autoruntime;
                        double workrate_s = ((double)autoruntime / (double)powerontime) * 100.00;
                        order_Data.workrate = Double.IsNaN(Math.Round(workrate_s, 2)) ? 0 : Math.Round(workrate_s, 2);
                        order_Data.stop = stoptime;
                        order_Data.auto = autoruntime;
                        order_Data.poweron = powerontime;
                        //reset
                        flagstart = true;

                        dataset.Add(order_Data);
                    }

                    lasttime = item.GET_TIME;
                }
                return dataset;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new List<Order_data>();
            }

        }


    }
}