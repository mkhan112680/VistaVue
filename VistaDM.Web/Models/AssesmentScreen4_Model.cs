using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaDM.Web.Models
{
    public class AssesmentScreen4_Model
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
        
        public AssesmentScreen4_Model()
        {

            q1 = new QuestionModel();
            q1.QID = 34;
            q1.Answer.Add(new AnswerModel() { QID = q1.QID, AID = 155 });
            q1.Answer.Add(new AnswerModel() { QID = q1.QID, AID = 156 });
            q1.Answer.Add(new AnswerModel() { QID = q1.QID, AID = 157 });
            q1.Answer.Add(new AnswerModel() { QID = q1.QID, AID = 158 });
            q1.Answer.Add(new AnswerModel() { QID = q1.QID, AID = 159 });
            q1.Answer.Add(new AnswerModel() { QID = q1.QID, AID = 160 });

            q2 = new QuestionModel();
            q2.QID = 35;
            q2.Answer.Add(new AnswerModel() { QID = q2.QID, AID = 161 });
            q2.Answer.Add(new AnswerModel() { QID = q2.QID, AID = 162 });
            q2.Answer.Add(new AnswerModel() { QID = q2.QID, AID = 163 });
            q2.Answer.Add(new AnswerModel() { QID = q2.QID, AID = 164 });
            
            q3 = new QuestionModel();
            q3.QID = 36;
            q3.Answer.Add(new AnswerModel() { QID = q3.QID, AID = 165 });
            q3.Answer.Add(new AnswerModel() { QID = q3.QID, AID = 166 });
            q3.Answer.Add(new AnswerModel() { QID = q3.QID, AID = 167 });
            q3.Answer.Add(new AnswerModel() { QID = q3.QID, AID = 168 });
            q3.Answer.Add(new AnswerModel() { QID = q3.QID, AID = 169 });
            q3.Answer.Add(new AnswerModel() { QID = q3.QID, AID = 170 });

            q4 = new QuestionModel();
            q4.QID = 37;
            q4.Answer.Add(new AnswerModel() { QID = q4.QID, AID = 171 });
            q4.Answer.Add(new AnswerModel() { QID = q4.QID, AID = 172 });
            q4.Answer.Add(new AnswerModel() { QID = q4.QID, AID = 173 });
            q4.Answer.Add(new AnswerModel() { QID = q4.QID, AID = 174 });

            q5 = new QuestionModel();
            q5.QID = 38;
            q5.Answer.Add(new AnswerModel() { QID = q5.QID, AID = 175 });
            q5.Answer.Add(new AnswerModel() { QID = q5.QID, AID = 176 });
            q5.Answer.Add(new AnswerModel() { QID = q5.QID, AID = 177 });
            q5.Answer.Add(new AnswerModel() { QID = q5.QID, AID = 178 });
            q5.Answer.Add(new AnswerModel() { QID = q5.QID, AID = 179 });
            q5.Answer.Add(new AnswerModel() { QID = q5.QID, AID = 180 });

            q6 = new QuestionModel();
            q6.QID = 39;
            q6.Answer.Add(new AnswerModel() { QID = q6.QID, AID = 181 });
            q6.Answer.Add(new AnswerModel() { QID = q6.QID, AID = 182 });
            q6.Answer.Add(new AnswerModel() { QID = q6.QID, AID = 183 });
            q6.Answer.Add(new AnswerModel() { QID = q6.QID, AID = 184 });
            
            q7 = new QuestionModel();
            q7.QID = 40;
            q7.Answer.Add(new AnswerModel() { QID = q7.QID, AID = 185 });
            q7.Answer.Add(new AnswerModel() { QID = q7.QID, AID = 186 });
            q7.Answer.Add(new AnswerModel() { QID = q7.QID, AID = 187 });
            q7.Answer.Add(new AnswerModel() { QID = q7.QID, AID = 188 });
            q7.Answer.Add(new AnswerModel() { QID = q7.QID, AID = 189 });
            q7.Answer.Add(new AnswerModel() { QID = q7.QID, AID = 190 });

            q8 = new QuestionModel();
            q8.QID = 41;
            q8.Answer.Add(new AnswerModel() { QID = q8.QID, AID = 191 });
            q8.Answer.Add(new AnswerModel() { QID = q8.QID, AID = 192 });
            q8.Answer.Add(new AnswerModel() { QID = q8.QID, AID = 193 });
            q8.Answer.Add(new AnswerModel() { QID = q8.QID, AID = 194 });
            q8.Answer.Add(new AnswerModel() { QID = q8.QID, AID = 195 });
            q8.Answer.Add(new AnswerModel() { QID = q8.QID, AID = 196 });

            q9 = new QuestionModel();
            q9.QID = 42;
            q9.Answer.Add(new AnswerModel() { QID = q9.QID, AID = 197 });
            q9.Answer.Add(new AnswerModel() { QID = q9.QID, AID = 198 });
            q9.Answer.Add(new AnswerModel() { QID = q9.QID, AID = 199 });
            q9.Answer.Add(new AnswerModel() { QID = q9.QID, AID = 200 });
            q9.Answer.Add(new AnswerModel() { QID = q9.QID, AID = 201 });
            q9.Answer.Add(new AnswerModel() { QID = q9.QID, AID = 202 });

            q10 = new QuestionModel();
            q10.QID = 43;
            q10.Answer.Add(new AnswerModel() { QID = q10.QID, AID = 203 });
            q10.Answer.Add(new AnswerModel() { QID = q10.QID, AID = 204 });
            q10.Answer.Add(new AnswerModel() { QID = q10.QID, AID = 205 });
            q10.Answer.Add(new AnswerModel() { QID = q10.QID, AID = 206 });
            q10.Answer.Add(new AnswerModel() { QID = q10.QID, AID = 207 });
            q10.Answer.Add(new AnswerModel() { QID = q10.QID, AID = 208 });

            q11 = new QuestionModel();
            q11.QID = 44;
            q11.Answer.Add(new AnswerModel() { QID = q11.QID, AID = 209 });
            q11.Answer.Add(new AnswerModel() { QID = q11.QID, AID = 210 });
            q11.Answer.Add(new AnswerModel() { QID = q11.QID, AID = 211 });
            q11.Answer.Add(new AnswerModel() { QID = q11.QID, AID = 212 });
            q11.Answer.Add(new AnswerModel() { QID = q11.QID, AID = 213 });
            q11.Answer.Add(new AnswerModel() { QID = q11.QID, AID = 214 });

            q12 = new QuestionModel();
            q12.QID = 45;
            q12.Answer.Add(new AnswerModel() { QID = q12.QID, AID = 215 });
            q12.Answer.Add(new AnswerModel() { QID = q12.QID, AID = 216 });
            q12.Answer.Add(new AnswerModel() { QID = q12.QID, AID = 217 });
            q12.Answer.Add(new AnswerModel() { QID = q12.QID, AID = 218 });
            q12.Answer.Add(new AnswerModel() { QID = q12.QID, AID = 219 });
            q12.Answer.Add(new AnswerModel() { QID = q12.QID, AID = 220 });

            q13 = new QuestionModel();
            q13.QID = 46;
            q13.Answer.Add(new AnswerModel() { QID = q13.QID, AID = 221 });
            q13.Answer.Add(new AnswerModel() { QID = q13.QID, AID = 222 });
            q13.Answer.Add(new AnswerModel() { QID = q13.QID, AID = 223 });
            q13.Answer.Add(new AnswerModel() { QID = q13.QID, AID = 224 });
            q13.Answer.Add(new AnswerModel() { QID = q13.QID, AID = 225 });

            q14 = new QuestionModel();
            q14.QID = 47;
            q14.Answer.Add(new AnswerModel() { QID = q14.QID, AID = 226 });
            q14.Answer.Add(new AnswerModel() { QID = q14.QID, AID = 227 });
            q14.Answer.Add(new AnswerModel() { QID = q14.QID, AID = 228 });
            q14.Answer.Add(new AnswerModel() { QID = q14.QID, AID = 229 });
            q14.Answer.Add(new AnswerModel() { QID = q14.QID, AID = 230 });

            q15 = new QuestionModel();
            q15.QID = 48;
            q15.Answer.Add(new AnswerModel() { QID = q15.QID, AID = 231 });
            q15.Answer.Add(new AnswerModel() { QID = q15.QID, AID = 232 });
            q15.Answer.Add(new AnswerModel() { QID = q15.QID, AID = 233 });
            q15.Answer.Add(new AnswerModel() { QID = q15.QID, AID = 234 });
            q15.Answer.Add(new AnswerModel() { QID = q15.QID, AID = 235 });

            q16 = new QuestionModel();
            q16.QID = 49;
            q16.Answer.Add(new AnswerModel() { QID = q16.QID, AID = 236 });
            q16.Answer.Add(new AnswerModel() { QID = q16.QID, AID = 237 });
            q16.Answer.Add(new AnswerModel() { QID = q16.QID, AID = 238 });
            q16.Answer.Add(new AnswerModel() { QID = q16.QID, AID = 239 });

            q17 = new QuestionModel();
            q17.QID = 50;
            q17.Answer.Add(new AnswerModel() { QID = q17.QID, AID = 240 });
            q17.Answer.Add(new AnswerModel() { QID = q17.QID, AID = 241 });
            q17.Answer.Add(new AnswerModel() { QID = q17.QID, AID = 242 });
            q17.Answer.Add(new AnswerModel() { QID = q17.QID, AID = 243 });
            q17.Answer.Add(new AnswerModel() { QID = q17.QID, AID = 244 });
            q17.Answer.Add(new AnswerModel() { QID = q17.QID, AID = 245 });

            q17.SelectedAnswers.Add(new AnswerModel() { AID = 240 });
            q17.SelectedAnswers.Add(new AnswerModel() { AID = 241 });
            q17.SelectedAnswers.Add(new AnswerModel() { AID = 242 });
            q17.SelectedAnswers.Add(new AnswerModel() { AID = 243 });
            q17.SelectedAnswers.Add(new AnswerModel() { AID = 244 });
            q17.SelectedAnswers.Add(new AnswerModel() { AID = 245 });
           
        }
    }
}