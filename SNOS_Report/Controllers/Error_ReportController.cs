using Newtonsoft.Json;
using SNOS_Report.Database;
using SNOS_Report.Models;
using SNOS_Report.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SNOS_Report.Controllers
{
    public class Error_ReportController : Controller
    {
        ErrorService errorService = new ErrorService();
        public ActionResult Search()
        {
            List<Mac_Spec> infor = new List<Mac_Spec>();
            using (var data = new SND_SNOSEntities())
            {
                infor = (from s in data.Mac_Spec
                         orderby s.Line_No ascending
                         select s).ToList();
                ViewBag.linelist = infor;
            }
            try
            {
                var s = Request["start"];
                var e = Request["end"];
                int line = Convert.ToInt32(Request["line"]);
                if (s != null && e != null)
                {
                    DateTime start = Convert.ToDateTime(s);
                    DateTime end = Convert.ToDateTime(e);
                    end = end.AddDays(1).AddSeconds(-1);
                    Error error = new Error();
                    ViewBag.Error = error.geterror(start, end, line, "en", (infor.Find(x => x.Line_No == line).LINE_TYPE));
                    ViewBag.Line = line;
                    ViewBag.start = start;
                    ViewBag.end = end;
                }
                else
                {
                    ViewBag.start = DateTime.Now;
                    ViewBag.end = DateTime.Now;
                    Error error = new Error();
                    ViewBag.Error = error.geterror();
                    ViewBag.Line = 1;
                }
            }
            catch
            {
                ViewBag.start = DateTime.Now;
                ViewBag.end = DateTime.Now;
            }
            return View();
        }
        public ActionResult ThisWeek()
        {
            List<Mac_Spec> infor = new List<Mac_Spec>();
            using (var data = new SND_SNOSEntities())
            {
                infor = (from s in data.Mac_Spec
                         orderby s.Line_No ascending
                         select s).ToList();
                ViewBag.linelist = infor;
            }
            try
            {
                int line = Convert.ToInt32(Request["line"]);
                Error error = new Error();
                if (line != 0) { ViewBag.Error = error.geterrorthisweek(line, "EN", (infor.Find(s => s.Line_No == line).LINE_TYPE)); }
                else { ViewBag.Error = error.geterrorthisweek(1, "EN", (infor.Find(s => s.Line_No == 1).LINE_TYPE)); }
                ViewBag.Line = line;
            }
            catch
            {
                Error error = new Error();
                ViewBag.Error = error.geterrorthisweek(1, "EN", (infor.Find(s => s.Line_No == 1).LINE_TYPE));
                ViewBag.Line = 1;
            }

            return View();
        }
        public ActionResult ThisMonth()
        {
            List<Mac_Spec> infor = new List<Mac_Spec>();
            using (var data = new SND_SNOSEntities())
            {
                infor = (from s in data.Mac_Spec
                         orderby s.Line_No ascending
                         select s).ToList();
                ViewBag.linelist = infor;
            }
            try
            {
                int line = Convert.ToInt32(Request["line"]);
                Error error = new Error();
                if (line != 0) { ViewBag.Error = error.geterrorthismonth(line, "en", (infor.Find(s => s.Line_No == line).LINE_TYPE)); }
                else { ViewBag.Error = error.geterrorthismonth(1, "en", (infor.Find(s => s.Line_No == 1).LINE_TYPE)); }
                ViewBag.Line = line;
            }
            catch
            {
                Error error = new Error();
                ViewBag.Error = error.geterrorthismonth(1, "en", (infor.Find(s => s.Line_No == 1).LINE_TYPE));
                ViewBag.Line = 1;
            }

            return View();
        }

        public ActionResult CompareError()
        {
            List<Mac_Spec> infor = new List<Mac_Spec>();
            using (var data = new SND_SNOSEntities())
            {
                infor = (from s in data.Mac_Spec
                         orderby s.Line_No ascending
                         select s).ToList();
                ViewBag.linelist = infor;
            }
            var month = Convert.ToInt32(Request["month"]);
            var year = Convert.ToInt32(Request["year"]);
            int line = Convert.ToInt32(Request["line"]);
            var dataCahrt = errorService.GetErrorMonthlyCompair(line, "EN", month, year);
            var check = JsonConvert.SerializeObject(dataCahrt);
            ViewBag.Errordata = dataCahrt;
            return View();
        }
    }

}