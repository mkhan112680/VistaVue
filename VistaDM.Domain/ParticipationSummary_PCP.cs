using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VistaDM.Domain
{
    public enum Status
    {
        NOT_COMPLETED = 0,
        COMPLETED = 1
    }
    
    public class ParticipationSummary_PCP
    {
        public Status MOU { get; set; }
        public Status Payee { get; set; }
        public Status NeedsAssesment { get; set; }
        public int    NeedsAsses_Remuneration { get; set; }
        public int    PAF1 { get; set; }
        public int    PAF1_Renum { get; set; }
        public int    PatientSurvey { get; set; }
        public int    PS_Received { get; set; }
    }
}
