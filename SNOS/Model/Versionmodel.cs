using SNOS.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNOS.Model
{
    class Versionmodel
    {
        public string getversion()
        {
            string version = "";
            using (var data = new SND_SNOSEntities())
            {
                var context = from d in data.Versionchecks
                              orderby d.UpdateDate descending
                              select d.Version;
                version = context.FirstOrDefault().ToString();
            }
            return version;
        }
        public string getid()
        {
            string id = null;
            using (var data = new SND_SNOSEntities())
            {
                var context = from d in data.Versionchecks
                              orderby d.UpdateDate descending
                              select d.SNTM_Key;
                id = context.FirstOrDefault().ToString().ToUpper();
            }
            return id;
        }
        public string getname()
        {
            string name = null;
            using (var data = new SND_SNOSEntities())
            {
                var context = from d in data.Versionchecks
                              orderby d.UpdateDate descending
                              select d.Customer_Name;
                name = context.FirstOrDefault().ToString().ToUpper();
            }
            return name;
        }
    }
}
