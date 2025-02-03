using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNOS_Report.Models.DataClass
{
    public class Daliy_workrate
    {
        public double time_00_04 { get; set; }
        public double time_04_08 { get; set; }
        public double time_08_12 { get; set; }
        public double time_12_16 { get; set; }
        public double time_16_20 { get; set; }
        public double time_20_24_Last { get; set; }
        public double time_20_24_Now { get; set; }
    }
}