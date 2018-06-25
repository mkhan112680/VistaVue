using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaDM.Web.Models
{
    public class AssesmentScreen3_Model
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

        public AssesmentScreen3_Model()
        {
            q1 = new QuestionModel();
            q1.QID = 26;
            q1.Answer.Add(new AnswerModel() { QID = q1.QID, AID = 120 });
            q1.Answer.Add(new AnswerModel() { QID = q1.QID, AID = 121 });
            q1.Answer.Add(new AnswerModel() { QID = q1.QID, AID = 122 });
            q1.Answer.Add(new AnswerModel() { QID = q1.QID, AID = 123 });

            q2 = new QuestionModel();
            q2.QID = 27;
            q2.Answer.Add(new AnswerModel() { QID = q2.QID, AID = 124 });
            q2.Answer.Add(new AnswerModel() { QID = q2.QID, AID = 125 });
            q2.Answer.Add(new AnswerModel() { QID = q2.QID, AID = 126 });
            q2.Answer.Add(new AnswerModel() { QID = q2.QID, AID = 127 });
            q2.Answer.Add(new AnswerModel() { QID = q2.QID, AID = 128 });

            q3 = new QuestionModel();
            q3.QID = 28;
            q3.Answer.Add(new AnswerModel() { QID = q3.QID, AID = 129 });
            q3.Answer.Add(new AnswerModel() { QID = q3.QID, AID = 130 });
            q3.Answer.Add(new AnswerModel() { QID = q3.QID, AID = 131 });
            q3.Answer.Add(new AnswerModel() { QID = q3.QID, AID = 132 });
            q3.Answer.Add(new AnswerModel() { QID = q3.QID, AID = 133 });
            q3.Answer.Add(new AnswerModel() { QID = q3.QID, AID = 134 });

            q4 = new QuestionModel();
            q4.QID = 29;
            q4.Answer.Add(new AnswerModel() { QID = q4.QID, AID = 135 });
            q4.Answer.Add(new AnswerModel() { QID = q4.QID, AID = 136 });
            q4.Answer.Add(new AnswerModel() { QID = q4.QID, AID = 137 });
            q4.Answer.Add(new AnswerModel() { QID = q4.QID, AID = 138 });

            q5 = new QuestionModel();
            q5.QID = 30;
            q5.Answer.Add(new AnswerModel() { QID = q5.QID, AID = 139 });
            q5.Answer.Add(new AnswerModel() { QID = q5.QID, AID = 140 });
            q5.Answer.Add(new AnswerModel() { QID = q5.QID, AID = 141 });
            q5.Answer.Add(new AnswerModel() { QID = q5.QID, AID = 142 });

            q6 = new QuestionModel();
            q6.QID = 31;
            q6.Answer.Add(new AnswerModel() { QID = q6.QID, AID = 143 });
            q6.Answer.Add(new AnswerModel() { QID = q6.QID, AID = 144 });
            q6.Answer.Add(new AnswerModel() { QID = q6.QID, AID = 145 });
            q6.Answer.Add(new AnswerModel() { QID = q6.QID, AID = 146 });

            q7 = new QuestionModel();
            q7.QID = 32;
            q7.Answer.Add(new AnswerModel() { QID = q7.QID, AID = 147 });
            q7.Answer.Add(new AnswerModel() { QID = q7.QID, AID = 148 });
            q7.Answer.Add(new AnswerModel() { QID = q7.QID, AID = 149 });
            q7.Answer.Add(new AnswerModel() { QID = q7.QID, AID = 150 });

            q8 = new QuestionModel();
            q8.QID = 33;
            q8.Answer.Add(new AnswerModel() { QID = q8.QID, AID = 151 });
            q8.Answer.Add(new AnswerModel() { QID = q8.QID, AID = 152 });
            q8.Answer.Add(new AnswerModel() { QID = q8.QID, AID = 153 });
            q8.Answer.Add(new AnswerModel() { QID = q8.QID, AID = 154 });
            
        }
    }
}