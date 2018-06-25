using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaDM.Web.Models
{

    public class PracticeAssessment_P7
    {
        public int ID { get; set; }
        public int PatientID { get; set; }
        
        public decimal? Creatinine { get; set; }
        public bool Creatinine_NA { get; set; }

        public decimal? eGFR { get; set; }
        public bool eGFR_NA { get; set; }

        public decimal? ACR { get; set; }
        public bool ACR_NA { get; set; }
        public bool Normal_AC { get; set; }

        public bool OtherMedications_Antidepressant { get; set; }
        public bool OtherMedications_ASA { get; set; }
        public bool OtherMedications_Antiplatelet { get; set; }
        public bool OtherMedications_Erectile { get; set; }
        public bool OtherMedications_NSAID { get; set; }
        public bool OtherMedications_PPI { get; set; }
        public bool OtherMedications_Cessation { get; set; }
        public bool OtherMedications_Vitamins { get; set; }
        public bool OtherMedications_Warfarin { get; set; }
        public bool OtherMedications_Anticoagulant { get; set; }
        public bool OtherMedications_NONE { get; set; }

        public int PatientNum { get; set; }

        public bool Completed { get; set; }
        public bool IsReadOnly { get; set; }

    }
}