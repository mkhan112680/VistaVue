using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VistaDM.Data;

namespace VistaVue.Controllers
{
    public class BaseController : Controller
    {
        private VistaDMEntities ent = null;

        protected VistaDMEntities Entites
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