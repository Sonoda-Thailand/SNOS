using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Report_Service.Enum
{
    public enum M_EVENT
    {
        Power_On = 1,
        Power_Off = 2,
        Drive = 4,
        Stop = 8,
        Error = 16
    }
}