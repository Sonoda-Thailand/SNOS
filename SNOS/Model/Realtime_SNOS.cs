using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SNOS.Database;
using SNOS.Model.Class;

namespace SNOS.Model
{
    internal class Realtime_SNOS
    {
        Mac_Spec linedata;
        public Realtime_SNOS(string line)
        {
            using (var data = new SND_SNOSEntities())
            {
                linedata = (from s in data.Mac_Spec where s.Line_Name == line select s).FirstOrDefault();
            }
        }
        public Log_Work getlaststatus()
        {
            DateTime dateTime = DateTime.Now;
            DateTime timeset = dateTime.Date;

            using (var data = new SND_SNOSEntities())
            {
                if (gettimescope() == 1)
                {
                    DateTime starttime = timeset.AddHours(8);
                    DateTime endtime = timeset.AddHours(20);
                    return (from s in data.Log_Work where s.LINE == linedata.Line_No && s.GET_TIME > starttime && s.GET_TIME < endtime orderby s.GET_TIME descending select s).FirstOrDefault();
                }
                else
                {
                    DateTime starttime = timeset.AddHours(20);
                    starttime = starttime.AddDays(-1);
                    return (from s in data.Log_Work where s.LINE == linedata.Line_No && s.GET_TIME > starttime orderby s.GET_TIME descending select s).FirstOrDefault();
                }
            }
        }
        public int getlinetype()
        {
            return linedata.LINE_TYPE;
            /*
              LINE_TYPE	ENNAME	JPNAME	SHEET_COUNT
            1	SLITTER	スリッター	0
            2	LEVELLER	レベラー	1
            3	BLANKING	ブランキング	1
            4	OTHERS	その他	1
             */
        }
        public int gettimescope()
        {
            DateTime dateTime = DateTime.Now;
            DateTime timeset = dateTime.Date;
            timeset = timeset.AddHours(8);
            if (dateTime > timeset)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
        public Lastwork getlastwork()
        {
            Lastwork lastwork = new Lastwork(linedata.Line_No);
            return lastwork;
        }
        public List<Log_Work> getlistpros()
        {
            DateTime dateTime = DateTime.Now;
            DateTime timeset = dateTime.Date;

            using (var data = new SND_SNOSEntities())
            {
                if (gettimescope() == 1)
                {
                    DateTime starttime = timeset.AddHours(8);
                    DateTime endtime = timeset.AddHours(20);
                    return (from s in data.Log_Work where s.LINE_STATUS != 2 && s.LINE_STATUS != 0 && s.LINE == linedata.Line_No && s.GET_TIME > starttime && s.GET_TIME < endtime orderby s.GET_TIME ascending select s).ToList();
                }
                else
                {
                    DateTime starttime = timeset.AddHours(20);
                    starttime = starttime.AddDays(-1);
                    return (from s in data.Log_Work where s.LINE_STATUS != 2 && s.LINE_STATUS != 0 && s.LINE == linedata.Line_No && s.GET_TIME > starttime orderby s.GET_TIME ascending select s).ToList();
                }
            }
        }
        public Mac_Spec GetMac_Spec()
        {
            return linedata;
        }
    }
}
