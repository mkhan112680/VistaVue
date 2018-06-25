using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using VistaDM.Data;
using VistaDM.Web.Helpers;

namespace VistaDM.Web.Controllers
{
    public class BaseController :  Controller
    {


        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (Session[Constants.CULTURE] == null)
                Session[Constants.CULTURE] = Constants.ENGLISH;
            
            Thread.CurrentThread.CurrentUICulture =  new System.Globalization.CultureInfo(Session[Constants.CULTURE].ToString());
        }
        
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

        protected Models.UserModel VistaUser
        {

            get
            {
                return UserHelper.GetLoggedInUser();
            }
        }

    }
}