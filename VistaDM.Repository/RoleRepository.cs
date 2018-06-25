using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VistaDM.Domain;

namespace VistaDM.Repository
{
    public class RoleRepository : BaseRepository
    {

        public List<Role> GetRoles()
        {

            List<Role> retLst = new List<Role>();

            foreach (var item in Entites.sp_GetSponserRoles())
            {
                retLst.Add(

                            new Role()
                            {
                                ID = item.ID,
                                Name = item.Name
                            }
                        );
            }

            return retLst;
        }
    }
}
