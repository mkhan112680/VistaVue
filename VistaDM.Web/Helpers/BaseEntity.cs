using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VistaDM.Data;

namespace VistaDM.Web.Helpers
{
    public class BaseEntity
    {


        private   VistaDMEntities ent = null;

        protected   VistaDMEntities Entites
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