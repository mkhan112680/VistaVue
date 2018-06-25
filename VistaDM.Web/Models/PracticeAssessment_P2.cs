using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VistaDM.Web.Models
{
    public class PracticeAssessment_P2  
    {
        public int ID { get; set; }
        public int PatientID {get; set;}

        [Required(ErrorMessage = "*")]
        public int? Age { get; set; }
        
        [Required(ErrorMessage = "*")]
        public String Gender { get; set; }

        [Required(ErrorMessage = "*")]
        public String DurationDiabetes { get; set; }

        [Required(ErrorMessage = "*")]
        public String Ethnicity { get; set; }

        [Required(ErrorMessage = "*")]
        public String MedicationCoverage { get; set; }

        [Required(ErrorMessage = "*")]
        public String EmploymentStatus { get; set; }

        public bool CoManagedCardiologist { get; set; }
        public bool CoManagedEducator { get; set; }
        public bool CoManagedEndocrinologist { get; set; }
        public bool CoManagedInternist { get; set; }
        public bool CoManagedNephrologist { get; set; }
        public bool CoManagedOphthalmologist { get; set; }

        public bool CoManagedNone { get; set; }

        [Required(ErrorMessage = "*")]
        public String HowManyMeds { get; set; }

        [Required(ErrorMessage = "*")]
        public String MedsAntihyperglycemic { get; set; }

        [Required(ErrorMessage = "*")]
        public String HowAdherent { get; set; }

        public bool MedicationAdherance1 { get; set; }
        public bool MedicationAdherance2 { get; set; }
        public bool MedicationAdherance3 { get; set; }
        public bool MedicationAdherance4 { get; set; }
        public bool MedicationAdherance5 { get; set; }

        [Required(ErrorMessage = "*")]
        public string LanguageBarriers { get; set; }

        public int PatientNum { get; set; }

        public bool IsReadOnly { get; set; }

      
    }
}