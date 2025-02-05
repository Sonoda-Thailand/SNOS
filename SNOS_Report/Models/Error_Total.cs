using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNOS_Report.Models
{
    public class Error_Total
    {
        public int month { get; set; }
        public int year { get; set; }
        public int Line { get; set; }
        public int Error_No { get; set; }
        public string Title { get; set; }
        public int Count { get; set; }
    }
}