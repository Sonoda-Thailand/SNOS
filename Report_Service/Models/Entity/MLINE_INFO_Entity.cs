using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Report_Service.Models.Entity
{
    public class MLINE_INFO_Entity
    {
        public int LINE { get; set; }

        public string LINE_NAME { get; set; }

        public short LINE_TYPE { get; set; }

        public string IP { get; set; }

        public int PORT_TCP { get; set; }

        public int PORT_UDP { get; set; }

        public short ENABLE { get; set; }
    }
}