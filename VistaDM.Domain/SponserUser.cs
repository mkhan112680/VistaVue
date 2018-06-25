using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VistaDM.Domain
{
    public class SponserUser
    {
        public int? UserID { get; set; }

        public Company Company { get; set; }
        public Role Role { get; set; }

        public bool IsAdmin { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool? TerritoryCovergae_All { get; set; }
        public bool? TerritoryCovergae_BC { get; set; }
        public bool? TerritoryCovergae_AB { get; set; }
        public bool? TerritoryCovergae_SK { get; set; }
        public bool? TerritoryCovergae_MB { get; set; }
        public bool? TerritoryCovergae_ON { get; set; }
        public bool? TerritoryCovergae_QC { get; set; }
        public bool? TerritoryCovergae_NS { get; set; }
        public bool? TerritoryCovergae_NB { get; set; }
        public bool? TerritoryCovergae_NL { get; set; }
        public bool? TerritoryCovergae_PEI { get; set; }

        public bool HasMoreThanOneProvince()
        {
            bool retVal = false;

            int count = 0;

            if (TerritoryCovergae_All.Value)
                count++;

            if (TerritoryCovergae_BC.Value)
                count++;

            if (TerritoryCovergae_AB.Value)
                count++;

            if (TerritoryCovergae_SK.Value)
                count++;

            if (TerritoryCovergae_MB.Value)
                count++;

            if (TerritoryCovergae_ON.Value)
                count++;

            if (TerritoryCovergae_QC.Value)
                count++;

            if (TerritoryCovergae_NS.Value)
                count++;

            if (TerritoryCovergae_NB.Value)
                count++;

            if (TerritoryCovergae_NL.Value)
                count++;

            if (TerritoryCovergae_PEI.Value)
                count++;


            return retVal = ( count > 1 );

        }

        public string GetSelectedProvince()
        {
            string retStr = string.Empty;

            if (TerritoryCovergae_AB.Value)
                retStr = "1";

            if (TerritoryCovergae_BC.Value)
                retStr = "2";

            if (TerritoryCovergae_MB.Value)
                retStr = "3";

            if (TerritoryCovergae_NB.Value)
                retStr = "4";

            if (TerritoryCovergae_NL.Value)
                retStr = "5";

            if (TerritoryCovergae_NS.Value)
                retStr = "6";

            if (TerritoryCovergae_ON.Value)
                retStr = "7";

            if (TerritoryCovergae_PEI.Value)
                retStr = "8";

            if (TerritoryCovergae_QC.Value)
                retStr = "9";

            if (TerritoryCovergae_SK.Value)
                retStr = "10";

            return retStr;

        }
    }
}
