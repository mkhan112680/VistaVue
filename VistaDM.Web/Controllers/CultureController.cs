using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using VistaDM.Web.Helpers;

namespace VistaDM.Web.Controllers
{
    public class CultureController : Controller
    {
        [HttpGet]
        [AllowAnonymousAttribute]
        public ActionResult SetEnglishCulture()
        {
            HttpContext.Session[Constants.CULTURE] = Constants.ENGLISH;
            return RedirectToAction("Index", "Home");
            
        }
        
        [HttpGet]
        [AllowAnonymousAttribute]
        public ActionResult SetFrenchCulture()
        {
            HttpContext.Session[Constants.CULTURE] = Constants.FRENCH;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymousAttribute]
        public ActionResult ToggleCulture(string orgUrl)
        {
            if (  HttpContext.Session[Constants.CULTURE] == null  )
                HttpContext.Session[Constants.CULTURE] = Constants.ENGLISH;
            
            string currCulture = HttpContext.Session[Constants.CULTURE].ToString();

            if (currCulture == Constants.ENGLISH)
                currCulture = Constants.FRENCH;
            else
                currCulture = Constants.ENGLISH;

            HttpContext.Session[Constants.CULTURE] = currCulture;
            //return RedirectToAction("Index", "Home");

            return Redirect(orgUrl);
        }
        
    }
}