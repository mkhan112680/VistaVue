using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaDM.Web.Models
{
    public class AnswerModel
    {
        public int QID { get; set; }
        public int AID { get; set; }
        public string AnswerValue { get; set; }
        public bool Selected { get; set; }
    }

    public class QuestionModel
    {
        public QuestionModel()
        {
            Answer = new List<AnswerModel>();

            SelectedAnswer = new AnswerModel();

            SelectedAnswers = new List<AnswerModel>();
        }

        public int QID { get; set; }
        public string QuestionText { get; set; }
        public string QuestionTextFR { get; set; }
        public string QuestionType { get; set; }
        public bool QuestionRequired { get; set; }
        public int Sequence { get; set; }
        public int UserID { get; set; }

        public AnswerModel SelectedAnswer { get; set; }

        public List<AnswerModel> SelectedAnswers { get; set; }

        public List<AnswerModel> Answer { get; set; }

    }
}