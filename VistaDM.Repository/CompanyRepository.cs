using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VistaDM.Domain;

namespace VistaDM.Repository
{
    public class CompanyRepository : BaseRepository
    {
        public List<Company> GetCompanies()
        {

            List<Company> retLst = new List<Company>();

            foreach (var item in Entites.sp_GetSponserCompanies())
	        {
                retLst.Add(

                            new Company()
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
