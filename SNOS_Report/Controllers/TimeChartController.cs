using SNOS_Report.Database;
using SNOS_Report.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SNOS_Report.Controllers
{
    public class TimeChartController : Controller
    {
        // GET: TimeChart
        public ActionResult Daily()
        {
            List<Mac_Spec> infor = new List<Mac_Spec>();
            using (var data = new SND_SNOSEntities())
            {
                infor = (from s in data.Mac_Spec
                         orderby s.Line_No ascending select s).ToList();
                ViewBag.linelist = infor;
                try
                {
                    int line = Convert.ToInt32(Request["line"]);
                    line = line == 0 ? 1 : line;
                    DateRange dataRange = new DateRange();
                    dataRange.Start = DateTime.Today;
                    dataRange.End = DateTime.Today.AddDays(1).AddSeconds(-1);
                    List<Log_Work> processlist = (from s in data.Log_Work
                                                  where s.LINE == line && s.GET_TIME >= dataRange.Start && s.GET_TIME <= dataRange.End
                                                  select s).ToList();
                    ViewBag.datalist = processlist;
                    ViewBag.Line = 1;
                    ViewBag.Line = line;
                }
                catch
                {
                    DateRange dataRange = new DateRange();
                    dataRange.Start = DateTime.Today;
                    dataRange.End = DateTime.Today.AddDays(1).AddSeconds(-1);
                    List<Log_Work> processlist = (from s in data.Log_Work
                                                  where s.LINE == 1 && s.GET_TIME >= dataRange.Start && s.GET_TIME <= dataRange.End
                                                  select s).ToList();
                    ViewBag.datalist = processlist;
                    ViewBag.Line = 1;
                }

            }
            return View();
        }
        
        public ActionResult Zone()
        {
            List<Mac_Spec> infor = new List<Mac_Spec>();
            using (var data = new SND_SNOSEntities())
            {
                infor = (from s in data.Mac_Spec
                         orderby s.Line_No ascending
                         select s).ToList();
                ViewBag.linelist = infor;
                try
                {
                    int line = Convert.ToInt32(Request["line"]);
                    var start = Request["start"];
                    var end = Request["end"];
                    line = line == 0 ? 1 : line;
                    if (start != null && end != null)
                    {

                        DateRange dataRange = new DateRange();
                        dataRange.Start = Convert.ToDateTime(start);
                        dataRange.End = Convert.ToDateTime(end).AddDays(1).AddSeconds(-1);
                        if (dataRange.End <= dataRange.Start.AddDays(7))
                        {
                            List<Log_Work> processlist = (from s in data.Log_Work
                                                          where s.LINE == line && s.GET_TIME >= dataRange.Start && s.GET_TIME <= dataRange.End
                                                          select s).ToList();
                            ViewBag.datalist = processlist;
                            ViewBag.start = dataRange.Start;
                            ViewBag.end = dataRange.End;
                            ViewBag.day = (dataRange.End.AddSeconds(1) - dataRange.Start).TotalDays;
                            ViewBag.Line = line;
                        }
                        else
                        {
                            dataRange.End = dataRange.Start.AddDays(7).AddSeconds(-1);
                            List<Log_Work> processlist = (from s in data.Log_Work
                                                          where s.LINE == line && s.GET_TIME >= dataRange.Start && s.GET_TIME <= dataRange.End
                                                          select s).ToList();
                            ViewBag.datalist = processlist;
                            ViewBag.start = dataRange.Start;
                            ViewBag.end = dataRange.End;
                            ViewBag.day = (dataRange.End.AddSeconds(1) - dataRange.Start).TotalDays;
                            ViewBag.Line = line;
                            ViewBag.Message = "Limit 7 day to display";
                        }
                    }
                    else
                    {
                        ViewBag.start = DateTime.Now;
                        ViewBag.end = DateTime.Now;
                        ViewBag.day = 0;
                        ViewBag.Line = 1;
                    }


                }
                catch
                {
                    ViewBag.start = DateTime.Now;
                    ViewBag.end = DateTime.Now;
                    ViewBag.Line = 1;
                    ViewBag.day = 0;
                }

            }
            return View();
        }
    }
    
}