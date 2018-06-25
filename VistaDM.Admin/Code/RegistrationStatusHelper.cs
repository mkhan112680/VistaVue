using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VistaDM.Domain;
using VistaDM.Repository;
 

namespace VistaDM.Admin.Code
{
    public class RegistrationStatusHelper
    {
        public List<RegistrationStatus> GetRecords()
        {
            InviteeRepository invRepos = new InviteeRepository();

            return invRepos.GetRegistartionStatus();

        }
    }
}