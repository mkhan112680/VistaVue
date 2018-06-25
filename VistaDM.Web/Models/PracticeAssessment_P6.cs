using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VistaDM.Web.Models
{
    public class PracticeAssessment_P6
    {

        
        public int ID { get; set; }
        public int PatientID { get; set; }

        [Required(ErrorMessage = "*")]
        public String A1C_Target { get; set; }
 
        public bool A1C_Limited { get; set; }
        public bool A1C_FunctionalDependancy { get; set; }
        public bool A1C_ExtensiveCoronary { get; set; }
        public bool A1C_MultipleMorbidities { get; set; }
        public bool A1C_Hypoglycemia { get; set; }
        public bool A1C_HypoglycemiaUnawareness { get; set; }
        public bool A1C_Diabetes { get; set; }
        public bool A1C_ClinicalJudgement { get; set; }
        public bool A1C_NONE { get; set; }

        [Required(ErrorMessage = "*")]
        public bool? A1C_Checked { get; set; }

        [Required(ErrorMessage = "*")]
        public decimal? A1C { get; set; }

        //[Required(ErrorMessage = "*")]
        public decimal? FPG { get; set; }

        public bool FPG_NA { get; set; }

        [Required(ErrorMessage = "*")]
        public String Patient_Counselled { get; set; }

        [Required(ErrorMessage = "*")]
        public String Patient_DietPlan { get; set; }

        [Required(ErrorMessage = "*")]
        public String PhysicalActivity { get; set; }

        [Required(ErrorMessage = "*")]
        public String WrittenExercisePlan { get; set; }

        [Required(ErrorMessage = "*")]
        public String ComprehensiveFootExam { get; set; }

        public String FootExamFinding { get; set; }

        [Required(ErrorMessage = "*")]
        public String EyeExam { get; set; }

        public String EyeExamFinding { get; set; }

        [Required(ErrorMessage = "*")]
        public String SMBG { get; set; }

        public String SMBGResults { get; set; }

        public bool Antihyperglycemic_Glucosidase { get; set; }
        public bool Antihyperglycemic_DPP4 { get; set; }
        public bool Antihyperglycemic_GLP1 { get; set; }
        public bool Antihyperglycemic_Insulin { get; set; }
        public bool Antihyperglycemic_Meglitinide { get; set; }
        public bool Antihyperglycemic_Metformin { get; set; }
        public bool Antihyperglycemic_Metformin_DPP4 { get; set; }
        public bool Antihyperglycemic_SGLT2 { get; set; }
        public bool Antihyperglycemic_Sulfonylurea { get; set; }
        public bool Antihyperglycemic_Thiazolidinedione { get; set; }
        public bool Antihyperglycemic_None { get; set; }

        public string InsulinRegimen { get; set; }

        public string SickDayInstructions { get; set; }


        public bool Hypoglycemia_Inquire { get; set; }
        public bool Hypoglycemia_PatientReported { get; set; }
        public bool Hypoglycemia_Evidence { get; set; }
        public bool Hypoglycemia_Paramedic { get; set; }
        public bool Hypoglycemia_NoDiscussion { get; set; }

        public bool Hypoglycemia_Adjusted { get; set; }
        public bool Hypoglycemia_Exercise { get; set; }
        public bool Hypoglycemia_NutritionTherapy { get; set; }
        public bool Hypoglycemia_ManagementPlan { get; set; }
        public bool Hypoglycemia_NoActionTaken { get; set; }

        public int PatientNum { get; set; }

        public bool IsReadOnly { get; set; }
    }
}