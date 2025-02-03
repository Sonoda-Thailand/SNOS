using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Report_Service.Models.Entity
{
    public class DPROC_Entity
    {
        public int LINE { get; set; }

        public decimal SIZE { get; set; }

        public decimal THICK { get; set; }

        public short SHEET_SCHED { get; set; }

        public short SHEET_RESULT { get; set; }

        public DateTime START_TIME { get; set; }

        public DateTime END_TIME { get; set; }

        public short SPEED { get; set; }
    }
}