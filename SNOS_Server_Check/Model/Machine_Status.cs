using SNOS_Server_Check.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SNOS_Server_Check.Model
{
    public class Machine_Status
    {
        //Para
        public bool status = false;
        public SNOS_IP_Checklist customer;
        public Machine_Status(string IP) {
            using (var data = new SND_SystemEntities())
            {
                customer = (from s in data.SNOS_IP_Checklist where s.IP_Address_SND == IP && s.Contact_status == true select s).FirstOrDefault();
            }
            status = PingHost(customer.IP_Address_SND);
        }
        //Function
        public bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress, 1000);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }
    }
    
}
