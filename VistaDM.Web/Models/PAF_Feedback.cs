using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaDM.Web.Models
{

    public enum FeedbackType
    {
        TARGET_CARE_OBJECTIVE_MET = 1,
        TARGET_CARE_OBJECTIVE_NOT_MET = 2,
        TARGET_CARE_OBJECTIVE_PARTIALLY_MET = 3,
        NOT_APPLICABLE = 4,
        NOT_RECORDED = 5,
        NULL = 6,
    }

    public class PAF_Feedback
    {

        public int PatientId { get; set; }
        public int PatientNum { get; set; }
        
        public string Blood_Glucose { get; set; }

        public string A1C { get; set; }

        public string Hypoglycemia { get; set; }

        public string Hypertension { get; set; }

        public string WaistCircumference { get; set; }

        public string BodyMassIndex { get; set; }

        public string Nutrition { get; set; }

        public string PhysicalActivity { get; set; }

        public string Smoking { get; set; }

        public string CKD_ACR { get; set; }
        
        public string CKD_GFR { get; set; }
       			 
        public string Retinopathy { get; set; }

        public string Neuropathy { get; set; }

        public string Dyslipidemia { get; set; }
        
    }
}