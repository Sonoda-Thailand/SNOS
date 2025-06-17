using SNOS_Report.Database;
using SNOS_Report.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
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
                Last_Count = x.Count(t => t.month != month) != 0 ? x.FirstOrDefault(t => t.month != month).Count : 0

            }).ToList();

            return result;
        }

        public List<Error_Compair> GetErrorYearly(int line, string lang, int year)
        {
            var totalData = new List<Error_Total>();
            var lastYear_Data = db.GetErrorByYear(line, lang, year - 1);
            var thisYear_Data = db.GetErrorByYear(line, lang, year);
            totalData.AddRange(lastYear_Data);
            totalData.AddRange(thisYear_Data);

            var result = totalData.GroupBy(x => x.Error_No).Select(x => new Error_Compair
            {
                Error_No = x.Key,
                Line = x.FirstOrDefault().Line,
                Title = x.FirstOrDefault().Title,
                This_Count = x.Count(t => t.year == year && t.year == year) != 0 ? x.FirstOrDefault(t => t.year == year && t.year == year).Count : 0,
                Last_Count = x.Count(t => t.year != year) != 0 ? x.FirstOrDefault(t => t.year != year).Count : 0
            }).ToList();

            return result;
        }

        public List<ErrorMonthlyGrouped> GetErrorYearlyGrouped(int line, string lang, int year)
        {
            // ดึงข้อมูลที่รวมทั้งเวลาและ title มาให้แล้ว
            var rawData = db.GetErrorByYear(line, lang, year);

            var grouped = rawData
                .GroupBy(e => new { e.month, e.Error_No })
                .Select(g => new ErrorMonthlyGrouped
                {
                    Month = g.Key.month == 0 ? 1 : g.Key.month, // กันไว้เผื่อเดือน = 0
                    Error_No = "E" + g.Key.Error_No.ToString("D3"),
                    Title = g.FirstOrDefault()?.Title ?? "Error " + g.Key.Error_No,
                    Count = g.Sum(x => x.Count)
                })
                .OrderBy(x => x.Month)
                .ThenBy(x => x.Error_No)
                .ToList();

            return grouped;
        }
    }
}