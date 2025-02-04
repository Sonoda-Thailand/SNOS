using SNOS_Report.Database;
using SNOS_Report.Models;
using SNOS_Report.Models.DataClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SNOS_Report.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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
                if (line != 0)
                {
                    //test
                    ViewBag.topthickday = Dashboard_data.gettopthick_day(line);
                    ViewBag.topthickweek = Dashboard_data.gettopthick_week(line);
                    ViewBag.topthickmonth = Dashboard_data.gettopthick_month(line);
                    ViewBag.today_workrate = Dashboard_data.gettodayworkrate(line);
                    ViewBag.yesterday_workrate = Dashboard_data.getyesterdayworkrate(line);
                    ViewBag.thisweek_workrate = Dashboard_data.getthisweekworkrate(line);
                    ViewBag.lastweek_workrate = Dashboard_data.getlastweekworkrate(line);
                    ViewBag.thismonth_workrate = Dashboard_data.getthismonthworkrate(line);
                    ViewBag.lastmonth_workrate = Dashboard_data.getlastmonthworkrate(line);
                }
                else
                {

                    ViewBag.topthickday = Dashboard_data.gettopthick_day(0);
                    ViewBag.topthickweek = Dashboard_data.gettopthick_week(0);
                    ViewBag.topthickmonth = Dashboard_data.gettopthick_month(0);
                    ViewBag.today_workrate = Dashboard_data.gettodayworkrate(0);
                    ViewBag.yesterday_workrate = Dashboard_data.getyesterdayworkrate(0);
                    ViewBag.thisweek_workrate = Dashboard_data.getthisweekworkrate(0);
                    ViewBag.lastweek_workrate = Dashboard_data.getlastweekworkrate(0);
                    ViewBag.thismonth_workrate = Dashboard_data.getthismonthworkrate(0);
                    ViewBag.lastmonth_workrate = Dashboard_data.getlastmonthworkrate(0);

                }
                ViewBag.Line = line;
            }
            catch
            {
                ViewBag.topthickday = Dashboard_data.gettopthick_day(0);
                ViewBag.topthickweek = Dashboard_data.gettopthick_week(0);
                ViewBag.topthickmonth = Dashboard_data.gettopthick_month(0);
                ViewBag.today_workrate = Dashboard_data.gettodayworkrate(0);
                ViewBag.yesterday_workrate = Dashboard_data.getyesterdayworkrate(0);
                ViewBag.thisweek_workrate = Dashboard_data.getthisweekworkrate(0);
                ViewBag.lastweek_workrate = Dashboard_data.getlastweekworkrate(0);
                ViewBag.thismonth_workrate = Dashboard_data.getthismonthworkrate(0);
                ViewBag.lastmonth_workrate = Dashboard_data.getlastmonthworkrate(0);
                ViewBag.Line = 0;
            }
            return View();
        }
    }
}