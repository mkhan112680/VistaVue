using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VistaDM.Data;

namespace VistaDM.Repository
{
    public class BaseRepository
    {

        public BaseRepository()
        {


        }

        private VistaDMEntities ent = null;

        public VistaDMEntities Entites
        {

            get
            {
                if (ent == null)
                    ent = new VistaDMEntities();

                return ent;
            }
        }

    }
}
