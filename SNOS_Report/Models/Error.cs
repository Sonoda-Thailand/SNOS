using SNOS_Report.Database;
using SNOS_Report.Models.DataClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Services.Description;

namespace SNOS_Report.Models
{
    public class Error
    {
        public List<Error_item> geterror()
        {
            List<Error_item> listerror = new List<Error_item>();
            try
            {
                List<Log_Error> Log_Errors = new List<Log_Error>();
                using (var data = new SND_SNOSEntities())
                {
                    int type = (from l in data.Mac_Spec where l.Line_No == 1 select l.LINE_TYPE).FirstOrDefault();
                    return geterrorthismonth(1, "EN", type).Take(20).ToList();
                }
            }
            catch
            {
                return new List<Error_item>();
            }

        }
        public List<Error_item> geterror(DateTime startinput, DateTime endinpint, int line, string lang, int type)
        {
            try
            {
                List<Log_Error> temp = new List<Log_Error>();
                using (var data = new SND_SNOSEntities())
                {
                    var x = (from s in data.Log_Error
                             where s.LINE == line
                             && s.Error_Time >= startinput
                             && s.Error_Time <= endinpint
                             orderby s.Error_Time ascending
                             select s).ToList();
                    if (x != null) { temp = x; }

                }
                List<Error_item> listerror = new List<Error_item>();
                DateTime start = temp[0].Error_Time;
                DateTime end = temp[0].Error_Time;
                DateTime lasttime = start;
                int nowerror = temp[0].Error_Number;
                bool endrec = false;
                int ct = 1;
                foreach (var i in temp)
                {
                    endrec = false;
                    if (((i.Error_Time - lasttime).TotalSeconds < 60) && nowerror == i.Error_Number)
                    {
                        lasttime = i.Error_Time;

                    }
                    else if ((i.Error_Time - lasttime).TotalSeconds > 60)
                    {
                        endrec = true;
                        end = lasttime;
                    }

                    else
                    {
                        endrec = true;
                        end = lasttime;
                    }
                    if (ct == temp.Count)
                    {
                        endrec = true;
                        end = lasttime;
                    }
                    if (endrec)
                    {

                        Error_item item = new Error_item(i, type, "EN");
                        item.start = start;
                        item.end = end;
                        listerror.Add(item);
                        start = i.Error_Time;
                    }
                    nowerror = i.Error_Number;
                    lasttime = i.Error_Time;
                    ct++;
                }
                return listerror;
            }
            catch
            {
                return new List<Error_item>();
            }

        }
        public List<Error_item> geterrorthisweek(int line, string lang, int type)
        {
            try
            {
                List<Log_Error> temp = new List<Log_Error>();
                DateRange timeset = DateRange.ThisWeek(DateTime.Now);
                using (var data = new SND_SNOSEntities())
                {
                    var x = (from s in data.Log_Error
                             where s.LINE == line
                             && s.Error_Time >= timeset.Start
                             && s.Error_Time <= timeset.End
                             orderby s.Error_Time ascending
                             select s).ToList();
                    if (x != null) { temp = x; }

                }
                List<Error_item> listerror = new List<Error_item>();
                DateTime start = temp[0].Error_Time;
                DateTime end = temp[0].Error_Time;
                DateTime lasttime = start;
                int nowerror = temp[0].Error_Number;
                bool endrec = false;
                int ct = 1;
                foreach (var i in temp)
                {
                    endrec = false;
                    if (((i.Error_Time - lasttime).TotalSeconds < 60) && nowerror == i.Error_Number)
                    {
                        lasttime = i.Error_Time;

                    }
                    else if ((i.Error_Time - lasttime).TotalSeconds > 60)
                    {
                        endrec = true;
                        end = lasttime;
                    }

                    else
                    {
                        endrec = true;
                        end = lasttime;
                    }
                    if (ct == temp.Count)
                    {
                        endrec = true;
                        end = lasttime;
                    }
                    if (endrec)
                    {

                        Error_item item = new Error_item(i, type, "EN");
                        item.start = start;
                        item.end = end;
                        listerror.Add(item);
                        start = i.Error_Time;
                    }
                    nowerror = i.Error_Number;
                    lasttime = i.Error_Time;
                    ct++;
                }
                return listerror;
            }
            catch
            {
                return new List<Error_item>();
            }

        }
        public List<Error_item> geterrorthismonth(int line, string lang, int type)
        {
            try
            {

                List<Log_Error> temp = new List<Log_Error>();
                DateRange timeset = DateRange.ThisMonth(DateTime.Now);
                using (var data = new SND_SNOSEntities())
                {
                    var x = (from s in data.Log_Error
                             where s.LINE == line
                             && s.Error_Time >= timeset.Start
                             && s.Error_Time <= timeset.End
                             orderby s.Error_Time ascending
                             select s).ToList();
                    if (x != null) { temp = x; }

                }
                List<Error_item> listerror = new List<Error_item>();
                DateTime start = temp[0].Error_Time;
                DateTime end = temp[0].Error_Time;
                DateTime lasttime = start;
                int nowerror = temp[0].Error_Number;
                bool endrec = false;
                int ct = 1;
                foreach (var i in temp)
                {
                    endrec = false;
                    if (((i.Error_Time - lasttime).TotalSeconds < 60) && nowerror == i.Error_Number)
                    {
                        lasttime = i.Error_Time;

                    }
                    else if ((i.Error_Time - lasttime).TotalSeconds > 60)
                    {
                        endrec = true;
                        end = lasttime;
                    }

                    else
                    {
                        endrec = true;
                        end = lasttime;
                    }
                    if (ct == temp.Count)
                    {
                        endrec = true;
                        end = lasttime;
                    }
                    if (endrec)
                    {

                        Error_item item = new Error_item(i, type, "EN");
                        item.start = start;
                        item.end = end;
                        listerror.Add(item);
                        start = i.Error_Time;
                    }
                    nowerror = i.Error_Number;
                    lasttime = i.Error_Time;
                    ct++;
                }
                return listerror;
            }
            catch
            {
                return new List<Error_item>();
            }

        }
    }

}