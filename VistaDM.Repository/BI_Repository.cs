using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VistaDM.Domain;

namespace VistaDM.Repository
{
    public class BI_Repository : BaseRepository
    {

        public List<BI> Get_BI_List(SponserUser user)
        {
            List<BI> retLst = new List<BI>();

            var biLst = Entites.sp_Get_BI
                            (
                                user.TerritoryCovergae_AB,
                                user.TerritoryCovergae_BC,
                                user.TerritoryCovergae_MB,
                                user.TerritoryCovergae_NB,
                                user.TerritoryCovergae_NL,
                                user.TerritoryCovergae_NS,
                                user.TerritoryCovergae_ON,
                                user.TerritoryCovergae_PEI,
                                user.TerritoryCovergae_QC,
                                user.TerritoryCovergae_SK

                                ).ToList();

            foreach (var item in biLst)
            {

                if (item.BI.HasValue )
                {
                    retLst.Add(
                                 new BI()
                                 {
                                     Name = item.BI.Value

                                 }
                              );
                }
            }

            return retLst;

        }
    }
}
