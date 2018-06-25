using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VistaDM.Domain;

namespace VistaDM.Repository
{
    public class ProvinceRepository : BaseRepository
    {

        public List<Domain.Province> GetProvinces()
        {
            return Entites.Provinces.Select(p => new Province() { ID = p.ID, Name = p.name , FullName= p.FullName })
            .ToList();

        }

    }
}
