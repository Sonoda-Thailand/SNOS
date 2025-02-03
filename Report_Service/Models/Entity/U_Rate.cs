using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Report_Service.Models.Entity
{
    public class U_Rate
    {
        public TimeSpan PowerOn { get; set; }
        public TimeSpan StopTime { get; set; }
        public TimeSpan Runtime { get; set; }
        public double U_rate { get; set; }
        public double AV_LineSpeed { get; set; }
    }
}