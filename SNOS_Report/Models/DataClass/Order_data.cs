using SNOS_Report.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNOS_Report.Models
{
    public class Order_data
    {

        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public double Length { get; set; }
        public decimal THICK { get; set; }
        public double workrate { get; set; }
        public int poweron { get; set; }
        public int stop { get; set; }
        public int auto { get; set; }
    }
}