using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using VistaDM.Web.Helpers;

using Microsoft.AspNet.Identity;

namespace VistaDM.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (base.VistaUser.IsPCP)
                return RedirectToAction("Index_PCP");
            else
                return RedirectToAction("Index_CS");
            
        }

        public ActionResult Index_PCP()
        {
            return View();
        }

        public ActionResult Index_CS()
        {
            return View();
        }


        public ActionResult Contact()
        {
            return View();
        }
    }
}