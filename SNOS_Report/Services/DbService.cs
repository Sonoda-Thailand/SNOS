using SNOS_Report.Database;
using SNOS_Report.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNOS_Report.Services
{
    public class DbService 
    {
        public List<Error_Total> GetErrorByMonth(int line, string lang, int month, int year)
        {
            var result = new List<Error_Total>();

            using (var _context = new SND_SNOSEntities())
            {
                var data = _context.Log_Error
                .Where(x => x.LINE == line && x.Error_Time.Month == month && x.Error_Time.Year == year)
                .GroupBy(x => x.Error_Number).Select(x => new
                {
                    month = month,
                    year = year,
                    Error_Num = x.Key,
                    LstTime = x.Select(t => t.Error_Time).ToList()
                }).ToList();

                var getError = data.Select(x => new
                {
                    month = x.month,
                    year = x.year,
                    Error_Num = x.Error_Num,
                    count = FilterErrorTime(x.LstTime)
                }).ToList();

                var type = _context.Mac_Spec.FirstOrDefault(x => x.Line_No == line).LINE_TYPE;

                var errorMap = _context.Error_Mapping.Where(x => x.LINE_TYPE == type && x.Language == lang).ToList();

                //result = getError
                //    .Join(
                //        _context.Error_Mapping,                             
                //        e => new { Error_No = e.Error_Num, Line_Type = type, Lang = lang }, 
                //        m => new { Error_No = m.Error_No, Line_Type = m.LINE_TYPE, Lang = m.Language }, 
                //        (e, m) => new Error_Total                           
                //        {
                //            month = e.month,
                //            year = e.year,
                //            Line = line,
                //            Error_No = e.Error_Num,
                //            Count = e.count,
                //            Title = m.Title
                //        }
                //    )
                //    .ToList();

                result = getError.Select(x => new Error_Total
                {
                    month = x.month,
                    year = x.year,
                    Line = line,
                    Error_No = x.Error_Num,
                    Count = x.count,
                    Title = errorMap.FirstOrDefault(e => e.Error_No == x.Error_Num).Title

                }).ToList();
            }

            return result;
        }

        private int FilterErrorTime(List<DateTime> logs)
        {
            logs = logs.OrderBy(x => x).ToList();
            int groupCount = 1;
            DateTime? bufferTime = null;

            foreach (var log in logs)
            {
                if (bufferTime != null)
                {
                    var diff = (log - bufferTime.Value).TotalMinutes;

                    if (diff > 1.30) 
                    {
                        groupCount++; 
                    }
                }

                bufferTime = log;
            }

            return groupCount;
        }
    }
}