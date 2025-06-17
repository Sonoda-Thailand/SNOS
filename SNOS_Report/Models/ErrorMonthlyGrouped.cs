using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNOS_Report.Models
{
    public class ErrorMonthlyGrouped
    {
        public int Month { get; set; }
        public string Error_No { get; set; }
        public string Title { get; set; }  // ใช้สำหรับแสดงชื่อในตาราง
        public int Count { get; set; }
    }


}