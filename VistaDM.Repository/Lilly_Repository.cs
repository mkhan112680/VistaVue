using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using VistaDM.Domain;

namespace VistaDM.Repository
{
    public class Lilly_Repository : BaseRepository
    {
        public List<Lilly> Get_Lilly_List(SponserUser user)
        {
            List<Lilly> retLst = new List<Lilly>();

            var lillyLst = Entites.sp_Get_Lilly
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

            foreach (var item in lillyLst)
            {
                if ( !string.IsNullOrEmpty(item.Lilly))
                {
                    retLst.Add(
                                 new Lilly()
                                 {
                                     Name = item.Lilly
                                 }
                              );
                }
            }

            return retLst;

        }
    }
}
