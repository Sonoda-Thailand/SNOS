using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Report_Service.Models.Entity
{
    public class DPROCING_Entity
    {
        public int LINE { get; set; }

        public DateTime GET_TIME { get; set; }

        public short LINE_STATUS { get; set; }

        public short SPEED { get; set; }

        public decimal SIZE { get; set; }

        public decimal THICK { get; set; }

        public short SHEET_SCHED { get; set; }

        public short SHEET_RESULT { get; set; }

        public DateTime START_TIME { get; set; }
    }
}