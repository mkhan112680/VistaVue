using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaDM.Web.Models
{
    public class FeedbackSummary
    {
        public string Measure { get; set; }

        public decimal Met { get; set; }
        public decimal Partially_Met { get; set; }
        public decimal Not_Met { get; set; }
        public decimal NA { get; set; }
    }
}