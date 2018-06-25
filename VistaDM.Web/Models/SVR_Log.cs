using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaDM.Web.Models
{
    public class SVR_Log
    {
        public int PatientNum { get; set; }
        public int PatientID { get; set; }
        public string InternalRefNum { get; set; }
        public DateTime? NextAppointment { get; set; }

    }

}