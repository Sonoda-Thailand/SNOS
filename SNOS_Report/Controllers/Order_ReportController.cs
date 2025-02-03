using SNOS_Report.Database;
using SNOS_Report.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SNOS_Report.Controllers
{
    public class Order_ReportController : Controller
    {
        public ActionResult Search()
        {
            try
            {
                var s = Request["start"];
                var e = Request["end"];
                int line = Convert.ToInt32(Request["line"]);
                Order order = new Order();
                using (var data = new SND_SNOSEntities())
                {
                    var infor = (from li in data.Mac_Spec
                                 orderby li.Line_No ascending
                                 select li).ToList();
                    ViewBag.linelist = infor;
                }
                if (s != null && e != null)
                {
                    DateTime start = Convert.ToDateTime(s);
                    DateTime end = Convert.ToDateTime(e);
                    end = end.AddDays(1).AddSeconds(-1);
                    ViewBag.start = start;
                    ViewBag.end = end;
                    ViewBag.Order = order.getorder(start, end, line);
                    ViewBag.Line = line;
                }
                else
                {
                    ViewBag.start = DateTime.Now;
                    ViewBag.end = DateTime.Now;
                    ViewBag.Order = order.getorder();
                    ViewBag.Line = 1;
                }
            }
            catch
            {
            }
            return View();
        }
        public ActionResult ThisWeek()
        {
            using (var data = new SND_SNOSEntities())
            {
                var infor = (from s in data.Mac_Spec
                             orderby s.Line_No ascending
                             select s).ToList();
                ViewBag.linelist = infor;
            }
            try
            {
                int line = Convert.ToInt32(Request["line"]);
                Order order = new Order();
                if (line != 0) { ViewBag.Order = order.getorderthisweek(line); } else { ViewBag.Order = order.getorderthisweek(1); }
                ViewBag.Line = line;
            }
            catch
            {
                Order order = new Order();
                ViewBag.Order = order.getorderthisweek(1);
                ViewBag.Line = 1;
            }

            return View();
        }
        public ActionResult ThisMonth()
        {
            using (var data = new SND_SNOSEntities())
            {
                var infor = (from s in data.Mac_Spec
                             orderby s.Line_No ascending
                             select s).ToList();
                ViewBag.linelist = infor;
            }
            try
            {
                int line = Convert.ToInt32(Request["line"]);
                Order order = new Order();
                if (line != 0) { ViewBag.Order = order.getorderthismonth(line); } else { ViewBag.Order = order.getorderthismonth(1); }
                ViewBag.Line = line;
            }
            catch
            {
                Order order = new Order();
                ViewBag.Order = order.getorderthismonth(1);
                ViewBag.Line = 1;
            }
            return View();
        }

    }

}