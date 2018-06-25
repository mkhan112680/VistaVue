using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaDM.Web.Models
{
    
    public enum  PracticeAssesmentStatus
    {
        
        Incomplete  = 1,
        Complete    = 2,
        Closed      = 3,
        NotSet      = 4
    }
    
    public class PracticeAssesmentEntry
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int PatientID { get; set; }
        public int PatientNum { get; set; }
        public PracticeAssesmentStatus Status { get; set; }
        public PracticeAssesmentStatus PAF_Status { get; set; }
        public PracticeAssesmentStatus FF_Status { get; set; }
        public DateTime? ScheduledAppDate { get; set; }
    }
}