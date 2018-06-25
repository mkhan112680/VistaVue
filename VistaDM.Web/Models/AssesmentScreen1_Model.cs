using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaDM.Web.Models
{
    public class AssesmentScreen1_Model
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
        
        public AssesmentScreen1_Model()
        {
            q1 = new QuestionModel();
            q1.QID = 1 ;
            q1.Answer.Add(new AnswerModel() { QID = q1.QID, AID = 1 });
            q1.Answer.Add(new AnswerModel() { QID = q1.QID, AID = 2 });

            q2 = new QuestionModel();
            q2.QID = 2;
            q2.Answer.Add(new AnswerModel() { QID = q2.QID, AID = 3 });
            q2.Answer.Add(new AnswerModel() { QID = q2.QID, AID = 4 });
            q2.Answer.Add(new AnswerModel() { QID = q2.QID, AID = 5 });
            q2.Answer.Add(new AnswerModel() { QID = q2.QID, AID = 6 });
            q2.Answer.Add(new AnswerModel() { QID = q2.QID, AID = 7 });
            
            q3 = new QuestionModel();
            q3.QID = 3;
            q3.Answer.Add(new AnswerModel() { QID = q3.QID, AID = 8 });
            q3.Answer.Add(new AnswerModel() { QID = q3.QID, AID = 9 });
            q3.Answer.Add(new AnswerModel() { QID = q3.QID, AID = 10 });
            q3.Answer.Add(new AnswerModel() { QID = q3.QID, AID = 11 });
            q3.Answer.Add(new AnswerModel() { QID = q3.QID, AID = 12 });
            q3.Answer.Add(new AnswerModel() { QID = q3.QID, AID = 13 });

            q4 = new QuestionModel();
            q4.QID = 4;
            q4.Answer.Add(new AnswerModel() { QID = q4.QID, AID = 14 });
            q4.Answer.Add(new AnswerModel() { QID = q4.QID, AID = 15 });
            q4.Answer.Add(new AnswerModel() { QID = q4.QID, AID = 16 });
            q4.Answer.Add(new AnswerModel() { QID = q4.QID, AID = 17 });
            q4.Answer.Add(new AnswerModel() { QID = q4.QID, AID = 18 });

            q5 = new QuestionModel();
            q5.QID = 5;
            q5.Answer.Add(new AnswerModel() { QID = q5.QID, AID = 19 });
            q5.Answer.Add(new AnswerModel() { QID = q5.QID, AID = 20 });
            q5.Answer.Add(new AnswerModel() { QID = q5.QID, AID = 21 });
            q5.Answer.Add(new AnswerModel() { QID = q5.QID, AID = 22 });
            q5.Answer.Add(new AnswerModel() { QID = q5.QID, AID = 23 });

            q6 = new QuestionModel();
            q6.QID = 6;
            q6.Answer.Add(new AnswerModel() { QID = q6.QID, AID = 24 });
            q6.Answer.Add(new AnswerModel() { QID = q6.QID, AID = 25 });
            q6.Answer.Add(new AnswerModel() { QID = q6.QID, AID = 26 });
            q6.Answer.Add(new AnswerModel() { QID = q6.QID, AID = 27 });
            q6.Answer.Add(new AnswerModel() { QID = q6.QID, AID = 28 });

            q7 = new QuestionModel();
            q7.QID = 7;
            q7.Answer.Add(new AnswerModel() { QID = q7.QID, AID = 29 });
            q7.Answer.Add(new AnswerModel() { QID = q7.QID, AID = 30 });
            q7.Answer.Add(new AnswerModel() { QID = q7.QID, AID = 31 });
            q7.Answer.Add(new AnswerModel() { QID = q7.QID, AID = 32 });
            q7.Answer.Add(new AnswerModel() { QID = q7.QID, AID = 33 });
            q7.Answer.Add(new AnswerModel() { QID = q7.QID, AID = 34 });

            q8 = new QuestionModel();
            q8.QID = 8;
            q8.Answer.Add(new AnswerModel() { QID = q8.QID, AID = 35 });
            q8.Answer.Add(new AnswerModel() { QID = q8.QID, AID = 36 });
            q8.Answer.Add(new AnswerModel() { QID = q8.QID, AID = 37 });
            q8.Answer.Add(new AnswerModel() { QID = q8.QID, AID = 38 });
            q8.Answer.Add(new AnswerModel() { QID = q8.QID, AID = 39 });
            
        }
        
    }
}