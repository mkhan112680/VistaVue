using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VistaDM.Web.Models
{
    public class PracticeAssessment_P1 
    {
    
        public int ID { get; set; }
        
        [Required(ErrorMessage = "*")]
        public int PatientID { get; set; }
        
        [Required(ErrorMessage = "*")]
        public string InternalRefNum { get; set; }
        
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/mm/dd}", ApplyFormatInEditMode = false)]
        public DateTime? ScheduledAppointment { get; set; }

        public int PatientNum { get; set; }

        public bool IsReadOnly { get; set; }
    }
}