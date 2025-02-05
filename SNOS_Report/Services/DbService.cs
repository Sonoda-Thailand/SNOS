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
                var getError = _context.Log_Error
                .Where(x => x.LINE == line && x.Error_Time.Month == month && x.Error_Time.Year == year)
                .GroupBy(x => x.Error_Number)
                .Select(x => new
                {
                    month = month,
                    year = year,
                    Error_Num = x.Key,
                    count = x.Count()
                });

                result = getError
                    .Join(
                        _context.Error_Mapping,                             
                        e => new { Error_No = e.Error_Num, Line_Type = line, Lang = lang }, 
                        m => new { Error_No = m.Error_No, Line_Type = m.LINE_TYPE, Lang = m.Language }, 
                        (e, m) => new Error_Total                           
                        {
                            month = e.month,
                            year = e.year,
                            Line = line,
                            Error_No = e.Error_Num,
                            Count = e.count,
                            Title = m.Title
                        }
                    )
                    .ToList();
            }

            return result;
        }
    }
}