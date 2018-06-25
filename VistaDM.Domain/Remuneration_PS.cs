using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VistaDM.Domain
{
    public class Remuneration_PS
    {
        public int InviteeID { get; set; }
        public DateTime Date { get; set; }
        public bool GiftCard { get; set; }
        public string Received { get; set; }
    }
}
