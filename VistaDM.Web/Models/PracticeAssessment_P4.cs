using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VistaDM.Web.Models
{
    public class PracticeAssessment_P4
    {
        
        public int ID { get; set; }
        public int PatientID { get; set; }
        
        [Required(ErrorMessage = "*")]
        public String TragetSystolicBP { get; set; }
        
        [Required(ErrorMessage = "*")]
        public String TragetDiastolicBP { get; set; }

        [Required(ErrorMessage = "*")]
        public int? SystolicBP_lastVist { get; set; }

        [Required(ErrorMessage = "*")]
        public int? DiastolicBP_lastVist { get; set; }
         
        public bool BPTherapy_Alphablocker { get; set; }
        public bool BPTherapy_ACEInhibitor { get; set; }        
        public bool BPTherapy_ARB { get; set; }
        public bool BPTherapy_BetaBlocker { get; set; }
        public bool BPTherapy_CCB { get; set; }
        public bool BPTherapy_Diuretic { get; set; }
        //Combination Therapy       
        public bool ACE_Diuretic { get; set; }
        public bool ARB_Diuretic { get; set; }
        public bool BB_Diuretic { get; set; }     
        public bool CCB_ARB { get; set; }
        public bool NoneofAbove { get; set; }

        public int PatientNum { get; set; }

        public bool IsReadOnly { get; set; }

    }
}