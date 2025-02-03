using SNOS_Report.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNOS_Report.Models.DataClass
{
    public class Error_item
    {
        public DateTime start;
        public DateTime end;
        public Log_Error error { set; get; }
        public Error_Mapping mapping { set; get; }
        public Error_item(Log_Error item, int type, string lang)
        {
            error = item;
            using (var data = new SND_SNOSEntities())
            {
                mapping = (from s in data.Error_Mapping where s.Error_No == error.Error_Number && s.LINE_TYPE == type && s.Language == lang select s).FirstOrDefault();
            }
        }
    }

}