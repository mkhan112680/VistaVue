using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VistaDM.Web.Models
{
    public class PracticeAssessment_P5
    {

        public int ID { get; set; }
        public int PatientID { get; set; }

        [Required(ErrorMessage = "*")]
        public String LDLC_Target { get; set; }

        [Required(ErrorMessage = "*")]
        public bool? LipidLevelsChecked { get; set; }

        [Required(ErrorMessage = "*")]
        public decimal? TotalCholesterol { get; set; }

        [Required(ErrorMessage = "*")]
        public decimal? LDLC { get; set; }

        [Required(ErrorMessage = "*")]
        public decimal? HDLC { get; set; }

        [Required(ErrorMessage = "*")]
        public decimal? NonHDLC { get; set; }

        [Required(ErrorMessage = "*")]
        public decimal? Triglycerides { get; set; }

        public bool Statin { get; set; }
        public bool BileAcid { get; set; }
        public bool Ezetimibe { get; set; }
        public bool Fibrate { get; set; }
        public bool Niacin { get; set; }
        public bool PCSK9Inhibitor  { get; set; }
        public bool NoneofAbove { get; set; }

        public int PatientNum { get; set; }

        public bool IsReadOnly { get; set; }

  }
}