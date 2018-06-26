using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VistaVue.Controllers
{
    public class PhysicianController : Controller
    {
        public ActionResult MOU()
        {
            return PartialView("MOU");
        }

        public ActionResult Payee()
        {
            return PartialView("Payee");
        }
    }
}