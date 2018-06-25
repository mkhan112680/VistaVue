using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaDM.Web.Models
{
    public class AssesmentScreen2_Model
    {
        public bool ReadOnly { get; set; }
        
        public QuestionModel q1 { get; set; }
        public QuestionModel q2 { get; set; }
        public QuestionModel q3 { get; set; }
        public QuestionModel q4 { get; set; }
        public QuestionModel q5 { get; set; }
        public QuestionModel q6 { get; set; }
        public QuestionModel q7 { get; set; }
        public QuestionModel q8 { get; set; }
        public QuestionModel q9 { get; set; }
        public QuestionModel q10 { get; set; }
        public QuestionModel q11 { get; set; }
        public QuestionModel q12 { get; set; }
        public QuestionModel q13 { get; set; }
        public QuestionModel q14 { get; set; }
        public QuestionModel q15 { get; set; }
        public QuestionModel q16 { get; set; }
        public QuestionModel q17 { get; set; }

        public AssesmentScreen2_Model()
        {
            q1 = new QuestionModel();
            q1.QID = 9;
            q1.Answer.Add(new AnswerModel() { QID = q1.QID, AID = 40 });
            q1.Answer.Add(new AnswerModel() { QID = q1.QID, AID = 41 });

            q2 = new QuestionModel();
            q2.QID = 10;
            
            q2.Answer.Add(new AnswerModel() { QID = q2.QID, AID = 42 });
            q2.Answer.Add(new AnswerModel() { QID = q2.QID, AID = 43 });
            q2.Answer.Add(new AnswerModel() { QID = q2.QID, AID = 44 });
            q2.Answer.Add(new AnswerModel() { QID = q2.QID, AID = 45 });
            q2.Answer.Add(new AnswerModel() { QID = q2.QID, AID = 46 });
            q2.Answer.Add(new AnswerModel() { QID = q2.QID, AID = 47 });
            q2.Answer.Add(new AnswerModel() { QID = q2.QID, AID = 48 });
            q2.Answer.Add(new AnswerModel() { QID = q2.QID, AID = 49 });
            q2.Answer.Add(new AnswerModel() { QID = q2.QID, AID = 50 });

            q2.SelectedAnswers.Add(new AnswerModel() { AID = 42 });
            q2.SelectedAnswers.Add(new AnswerModel() { AID = 43 });
            q2.SelectedAnswers.Add(new AnswerModel() { AID = 44 });
            q2.SelectedAnswers.Add(new AnswerModel() { AID = 45 });
            q2.SelectedAnswers.Add(new AnswerModel() { AID = 46 });
            q2.SelectedAnswers.Add(new AnswerModel() { AID = 47 });
            q2.SelectedAnswers.Add(new AnswerModel() { AID = 48 });
            q2.SelectedAnswers.Add(new AnswerModel() { AID = 49 });
            q2.SelectedAnswers.Add(new AnswerModel() { AID = 50 });


            q3 = new QuestionModel();
            q3.QID = 11;
            q3.Answer.Add(new AnswerModel() { QID = q3.QID, AID = 51 });
            q3.Answer.Add(new AnswerModel() { QID = q3.QID, AID = 52 });
            q3.Answer.Add(new AnswerModel() { QID = q3.QID, AID = 53 });
            q3.Answer.Add(new AnswerModel() { QID = q3.QID, AID = 54 });

            q3.SelectedAnswers.Add(new AnswerModel() { AID = 51 });
            q3.SelectedAnswers.Add(new AnswerModel() { AID = 52 });
            q3.SelectedAnswers.Add(new AnswerModel() { AID = 53 });
            q3.SelectedAnswers.Add(new AnswerModel() { AID = 54 });
            

            q4 = new QuestionModel();
            q4.QID = 12;
            q4.Answer.Add(new AnswerModel() { QID = q4.QID, AID = 55 });
            q4.Answer.Add(new AnswerModel() { QID = q4.QID, AID = 56 });
            q4.Answer.Add(new AnswerModel() { QID = q4.QID, AID = 57 });
            q4.Answer.Add(new AnswerModel() { QID = q4.QID, AID = 58 });
            q4.Answer.Add(new AnswerModel() { QID = q4.QID, AID = 59 });

            q5 = new QuestionModel();
            q5.QID = 13;
            q5.Answer.Add(new AnswerModel() { QID = q5.QID, AID = 60 });
            q5.Answer.Add(new AnswerModel() { QID = q5.QID, AID = 61 });
            q5.Answer.Add(new AnswerModel() { QID = q5.QID, AID = 62 });
            q5.Answer.Add(new AnswerModel() { QID = q5.QID, AID = 63 });
            q5.Answer.Add(new AnswerModel() { QID = q5.QID, AID = 64 });

            q6 = new QuestionModel();
            q6.QID = 14;
            q6.Answer.Add(new AnswerModel() { QID = q6.QID, AID = 65 });
            q6.Answer.Add(new AnswerModel() { QID = q6.QID, AID = 66 });
            q6.Answer.Add(new AnswerModel() { QID = q6.QID, AID = 67 });
            q6.Answer.Add(new AnswerModel() { QID = q6.QID, AID = 68 });
            q6.Answer.Add(new AnswerModel() { QID = q6.QID, AID = 69 });

            q7 = new QuestionModel();
            q7.QID = 15;
            q7.Answer.Add(new AnswerModel() { QID = q7.QID, AID = 70 });
            q7.Answer.Add(new AnswerModel() { QID = q7.QID, AID = 71 });
            q7.Answer.Add(new AnswerModel() { QID = q7.QID, AID = 72 });
            q7.Answer.Add(new AnswerModel() { QID = q7.QID, AID = 73 });
            q7.Answer.Add(new AnswerModel() { QID = q7.QID, AID = 74 });

            q8 = new QuestionModel();
            q8.QID = 16;
            q8.Answer.Add(new AnswerModel() { QID = q8.QID, AID = 75 });
            q8.Answer.Add(new AnswerModel() { QID = q8.QID, AID = 76 });
            q8.Answer.Add(new AnswerModel() { QID = q8.QID, AID = 77 });
            q8.Answer.Add(new AnswerModel() { QID = q8.QID, AID = 78 });
            q8.Answer.Add(new AnswerModel() { QID = q8.QID, AID = 79 });

            q9 = new QuestionModel();
            q9.QID = 17;
            q9.Answer.Add(new AnswerModel() { QID = q9.QID, AID = 80 });
            q9.Answer.Add(new AnswerModel() { QID = q9.QID, AID = 81 });
            q9.Answer.Add(new AnswerModel() { QID = q9.QID, AID = 82 });
            q9.Answer.Add(new AnswerModel() { QID = q9.QID, AID = 83 });
            q9.Answer.Add(new AnswerModel() { QID = q9.QID, AID = 84 });

            q10 = new QuestionModel();
            q10.QID = 18;
            q10.Answer.Add(new AnswerModel() { QID = q10.QID, AID = 85 });
            q10.Answer.Add(new AnswerModel() { QID = q10.QID, AID = 86 });
            q10.Answer.Add(new AnswerModel() { QID = q10.QID, AID = 87 });
            q10.Answer.Add(new AnswerModel() { QID = q10.QID, AID = 88 });
            q10.Answer.Add(new AnswerModel() { QID = q10.QID, AID = 89 });

            q11 = new QuestionModel();
            q11.QID = 19;
            q11.Answer.Add(new AnswerModel() { QID = q11.QID, AID = 90 });
            q11.Answer.Add(new AnswerModel() { QID = q11.QID, AID = 91 });
            q11.Answer.Add(new AnswerModel() { QID = q11.QID, AID = 92 });
            q11.Answer.Add(new AnswerModel() { QID = q11.QID, AID = 93 });

            q12 = new QuestionModel();
            q12.QID = 20;
            q12.Answer.Add(new AnswerModel() { QID = q12.QID, AID = 94 });
            q12.Answer.Add(new AnswerModel() { QID = q12.QID, AID = 95 });
            q12.Answer.Add(new AnswerModel() { QID = q12.QID, AID = 96 });
            q12.Answer.Add(new AnswerModel() { QID = q12.QID, AID = 97 });
            q12.Answer.Add(new AnswerModel() { QID = q12.QID, AID = 98 });


            q13 = new QuestionModel();
            q13.QID = 21;
            q13.Answer.Add(new AnswerModel() { QID = q12.QID, AID = 99 });
            q13.Answer.Add(new AnswerModel() { QID = q12.QID, AID = 100 });
            q13.Answer.Add(new AnswerModel() { QID = q12.QID, AID = 101 });
            q13.Answer.Add(new AnswerModel() { QID = q12.QID, AID = 102 });

            q14 = new QuestionModel();
            q14.QID = 22;
            q14.Answer.Add(new AnswerModel() { QID = q14.QID, AID = 103 });
            q14.Answer.Add(new AnswerModel() { QID = q14.QID, AID = 104 });
            q14.Answer.Add(new AnswerModel() { QID = q14.QID, AID = 105 });
            q14.Answer.Add(new AnswerModel() { QID = q14.QID, AID = 106 });
            q14.Answer.Add(new AnswerModel() { QID = q14.QID, AID = 107 });

            q15 = new QuestionModel();
            q15.QID = 23;
            q15.Answer.Add(new AnswerModel() { QID = q15.QID, AID = 108 });
            q15.Answer.Add(new AnswerModel() { QID = q15.QID, AID = 109 });
            q15.Answer.Add(new AnswerModel() { QID = q15.QID, AID = 110 });
            q15.Answer.Add(new AnswerModel() { QID = q15.QID, AID = 111 });


            q16 = new QuestionModel();
            q16.QID = 24;
            q16.Answer.Add(new AnswerModel() { QID = q16.QID, AID = 112 });
            q16.Answer.Add(new AnswerModel() { QID = q16.QID, AID = 113 });
            q16.Answer.Add(new AnswerModel() { QID = q16.QID, AID = 114 });
            q16.Answer.Add(new AnswerModel() { QID = q16.QID, AID = 115 });

            q17 = new QuestionModel();
            q17.QID = 25;
            q17.Answer.Add(new AnswerModel() { QID = q17.QID, AID = 116 });
            q17.Answer.Add(new AnswerModel() { QID = q17.QID, AID = 117 });
            q17.Answer.Add(new AnswerModel() { QID = q17.QID, AID = 118 });
            q17.Answer.Add(new AnswerModel() { QID = q17.QID, AID = 119 });
            
        }
        
    }
    
}