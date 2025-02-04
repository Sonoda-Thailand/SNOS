using SNOS_Report.Database;
using SNOS_Report.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNOS_Report.Services
{
    public class ErrorService
    {
        DbService db = new DbService();

        public List<Error_Compair> GetErrorMonthlyCompair(int line, string lang, int month, int year)
        {
            var totalData = new List<Error_Total>();
            var lastMonth_Data = db.GetErrorByMonth(line, lang, month == 1 ? 12 : (month - 1), month == 1 ? year - 1 : year);
            var thisMonth_Data = db.GetErrorByMonth(line, lang, month, year);

            totalData.AddRange(lastMonth_Data);
            totalData.AddRange(thisMonth_Data);

            var result = totalData.GroupBy(x => x.Error_No).Select(x => new Error_Compair
            {
                Error_No = x.Key,
                Line = x.FirstOrDefault().Line,
                Title = x.FirstOrDefault().Title,
                This_Count = x.Count(t => t.month == month && t.year == year) != 0 ? x.FirstOrDefault(t => t.month == month && t.year == year).Count : 0,
                Last_Count = x.Count(t => t.month != month && t.year != year) != 0 ? x.FirstOrDefault(t => t.month != month && t.year != year).Count : 0

            }).ToList();

            //totalData.AddRange(lastMonth_Data);
            //totalData.AddRange(thisMonth_Data);

            return result;
        }
    }
}