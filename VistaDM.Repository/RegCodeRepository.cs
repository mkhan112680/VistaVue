using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VistaDM.Domain;

namespace VistaDM.Repository
{
    public class RegCodeRepository  : BaseRepository
    {

        public RegCode GetNewCode()
        {
            return (from r in Entites.RegistrationCodes

                    where r.Used == false
                    orderby r.ID

                    select new RegCode()
                    {
                        ID = r.ID,
                        Code = r.Code,
                        Used = r.Used
                    }
            ).Take(1).SingleOrDefault();
        }

        public void UpdateRegCode(int id)
        {

            Entites.sp_UpdateRegistrationCode(id);
        }
    }
    
}
