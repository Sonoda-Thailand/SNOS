using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNOS_Report.Models
{
    public class Error_Compair
    {
        public int Line { get; set; }
        public int Error_No { get; set; }
        public string Title { get; set; }
        public int Last_Count { get; set; }
        public int This_Count { get; set; }
    }
}