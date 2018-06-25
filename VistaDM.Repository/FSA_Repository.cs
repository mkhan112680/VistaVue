using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VistaDM.Domain;

namespace VistaDM.Repository
{
    public class FSA_Repository : BaseRepository
    {
        public List<FSA> GetFSAList(SponserUser user)
        {
            List<FSA> retLst = new List<FSA>();

            var fsaLst = Entites.sp_GetFSA
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

            foreach (var item in fsaLst)
            {

                if (!string.IsNullOrEmpty(item.FSA))
                {
                    retLst.Add(
                                 new FSA()
                                 {
                                     Name = item.FSA
                                 }
                              );
                }
            }

            return retLst;

        }
    }
}
