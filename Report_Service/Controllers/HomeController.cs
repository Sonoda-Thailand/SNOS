using Report_Service.Models;
using Report_Service.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Report_Service.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult today_Report()
        {
            try
            {
                int LINE = Convert.ToInt32(Request.QueryString["LINE"]);
                DateTime start = DateTime.Today;
                DateTime end = DateTime.Today.AddDays(1).AddSeconds(-1);
                Report_DB report = new Report_DB();
                ViewBag.Linename = report.getLinename(LINE);
                ViewBag.Datalog = report.get_Product_List(start, end, LINE);
                ViewBag.Urate = report.get_List_U_Rate();
                ViewBag.timechart = report.get_DPROCING_time_chart();
                ViewBag.NowTime = DateTime.Now;
                return View();
            }
            catch
            {
                DateTime start = DateTime.Today;
                DateTime end = DateTime.Today.AddDays(1).AddSeconds(-1);
                Report_DB report = new Report_DB();
                ViewBag.Datalog = new List<DPROC_Entity>();
                ViewBag.Urate = new List<U_Rate>();
                ViewBag.Linename = "Error";
                ViewBag.timechart = new List<DPROCING_Entity>();
                ViewBag.NowTime = DateTime.Now;
                return View();
            }

        }

        public ActionResult yesterday_Report()
        {
            //ViewBag.NowTime = (DateTime.Now.AddDays(-1));
            return View();
        }
    }
}