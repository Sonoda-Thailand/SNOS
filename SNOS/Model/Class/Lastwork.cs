using SNOS.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SNOS.Model.Class
{
    internal class Lastwork
    {
        private string usedtime;
        private decimal size;
        public Lastwork(int line)
        {
            using (var data = new SND_SNOSEntities())
            {
                var s1 = (from s in data.Log_Work where s.LINE == line && s.RECOIL_expand == false orderby s.GET_TIME descending select s).FirstOrDefault();
                var s2 = (from s in data.Log_Work where s.LINE == line && s.RECOIL_expand == true && s.GET_TIME < s1.GET_TIME orderby s.GET_TIME descending select s).FirstOrDefault();
                var s3 = (from s in data.Log_Work where s.LINE == line && s.RECOIL_expand == false && s.GET_TIME < s2.GET_TIME orderby s.GET_TIME descending select s).FirstOrDefault();
                var s4 = (from s in data.Log_Work where s.LINE == line && s.RECOIL_expand == false && s.GET_TIME > s2.GET_TIME orderby s.GET_TIME ascending select s).FirstOrDefault();
                usedtime = (s4.GET_TIME - s3.GET_TIME).TotalMinutes.ToString("0 min.");
                size = s2.PLAN;
            }
        }
        public string get_usedtime() { return usedtime; }
        public decimal get_size() { return size; }
    }
}
