using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VistaDM.Web.Models
{
    public class PracticeAssessment_P3  
    {
        public int ID { get; set; }
        public int PatientID { get; set; }
        
        [Required(ErrorMessage = "*")]
        public String SmokingHistory { get; set; }

        //[Required(ErrorMessage = "*")]
        public String CessationPlan { get; set; }

        [Required(ErrorMessage = "*")]
        public String AlcoholIntake { get; set; }

        public bool CoMorbid_eGFR4559 { get; set; }
        public bool CoMorbid_eGFR3044 { get; set; }
        public bool CoMorbid_eGFRlessthan30 { get; set; }
        public bool CoMorbid_Microalbuminuria { get; set; }
        public bool CoMorbid_Macroalbuminuria { get; set; }
        public bool CoMorbid_Retinopathy { get; set; }
        public bool CoMorbid_Neuropathy { get; set; }

        public bool CoMorbid_CoronaryArtery { get; set; }
        public bool CoMorbid_Cerebrovascular { get; set; }
        public bool CoMorbid_AbdominalAortic { get; set; }
        public bool CoMorbid_PeripheralArterial { get; set; }

        public bool CoMorbid_NonAlcoholicfattyliver { get; set; }
        public bool CoMorbid_NonAlcoholicSteatohepatitis { get; set; }
        public bool CoMorbid_Cirrhosis { get; set; }
        public bool CoMorbid_Other { get; set; }

        public bool CoMorbid_CVdisease { get; set; }
        public bool CoMorbid_ModifiedFramingham { get; set; }
        public bool CoMorbid_Overweight { get; set; }
        public bool CoMorbid_HighriskHypertension { get; set; }
        public bool CoMorbid_Dyslipidemia { get; set; }
        public bool CoMorbid_AtrialFibrillation { get; set; }
        public bool CoMorbid_CongestiveHeartFailure { get; set; }
        public bool CoMorbid_Depression { get; set; }
        public bool CoMorbid_CognitiveImpairment { get; set; }
        public bool CoMorbid_ErectileDysfunction { get; set; }
        public bool CoMorbid_PolycysticOvary { get; set; }
        public bool CoMorbid_Infertility { get; set; }
        public bool CoMorbid_SleepApnea { get; set; }
        public bool CoMorbid_ThyroidDisease { get; set; }
        public bool CoMorbid_Malignancy { get; set; }
        public bool CoMorbid_None { get; set; }

        public int? HeartRate { get; set; }
        public bool NA_HearRate { get; set; }

        public int? Height { get; set; }
        public bool HeightCM { get; set; }
        public bool HeightIn { get; set; }

        public int? Weight { get; set; }
        public bool WeightKg { get; set; }
        public bool WeightLB { get; set; }

        public int? Waist { get; set; }
        public bool WaistCM { get; set; }
        public bool WaistIn { get; set; }

        public bool NA_Waist { get; set; }

        public int PatientNum { get; set; }

        public bool IsReadOnly { get; set; }
    }
}