using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VistaDM.Domain
{
    public class Remuneration
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Cheque { get; set; }
        public decimal Amount { get; set; }
        public string Comments { get; set; }
        public int InviteeID { get; set; }
    }
}
