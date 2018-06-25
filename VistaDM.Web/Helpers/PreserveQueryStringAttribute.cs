using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VistaDM.Web.Helpers
{
    public class PreservePatientDataAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //object p = filterContext.HttpContext.Request.QueryString["PatientID"];//Get prarmeters
            //var actionName = filterContext.RouteData.Values["action"];
            //var ControllerName = filterContext.RouteData.Values["controller"];
            //if (actionName != null && actionName.Equals("self"))
            //{
            //    var controllerName = filterContext.RouteData.Values["controller"];
            //    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Controller", controllerName }, { "Action", controllerName } });
            //}
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            //int PatientID = 0;
            //int PatientNum = 0;
            //bool IsReadOnly = false;
            
            //if (filterContext.ActionParameters.ContainsKey("model") )
            //{
            //    string actionName = filterContext.ActionDescriptor.ActionName;
            //    if (actionName == "PracticeAssessment_Screen1")
            //    {
            //        PatientID = (filterContext.ActionParameters["model"] as Models.PracticeAssessment_P1).PatientID;
            //        PatientNum = (filterContext.ActionParameters["model"] as Models.PracticeAssessment_P1).PatientNum;
            //        IsReadOnly = (filterContext.ActionParameters["model"] as Models.PracticeAssessment_P1).IsReadOnly;
            //    }
            //    else
            //        if (actionName == "PracticeAssessment_Screen2")
            //        {
            //            PatientID = (filterContext.ActionParameters["model"] as Models.PracticeAssessment_P2).PatientID;
            //            PatientNum = (filterContext.ActionParameters["model"] as Models.PracticeAssessment_P2).PatientNum;
            //            IsReadOnly = (filterContext.ActionParameters["model"] as Models.PracticeAssessment_P2).IsReadOnly;
            //        }
            //        else
            //            if (actionName == "PracticeAssessment_Screen3")
            //            {
            //                PatientID = (filterContext.ActionParameters["model"] as Models.PracticeAssessment_P3).PatientID;
            //                PatientNum = (filterContext.ActionParameters["model"] as Models.PracticeAssessment_P3).PatientNum;
            //                IsReadOnly = (filterContext.ActionParameters["model"] as Models.PracticeAssessment_P3).IsReadOnly;
            //            }
            //    //else
            //    //if (actionName == "PracticeAssessment_Screen4")
            //    //    model = filterContext.ActionParameters["model"] as Models.PracticeAssessment_P4;
            //    //else
            //    //if (actionName == "PracticeAssessment_Screen5")
            //    //    model = filterContext.ActionParameters["model"] as Models.PracticeAssessment_P5;
            //    //else
            //    //if (actionName == "PracticeAssessment_Screen6")
            //    //    model = filterContext.ActionParameters["model"] as Models.PracticeAssessment_P6;
            //    //else
            //    //if (actionName == "PracticeAssessment_Screen7")
            //    //    model = filterContext.ActionParameters["model"] as Models.PracticeAssessment_P7;
            

            //}
            //else
            //{
            //    PatientID = Int32.Parse(filterContext.ActionParameters["PatientID"].ToString());
            //    PatientNum = Int32.Parse(filterContext.ActionParameters["PatientNum"].ToString());
            //    IsReadOnly = bool.Parse(filterContext.ActionParameters["IsReadOnly"].ToString());
                
            //}

            
            //Controller controller = filterContext.Controller as Controller;
            //if (controller != null)
            //{
            //    //controller.ViewData
            //    if (!controller.TempData.ContainsKey("PatientID"))
            //    {
            //        controller.TempData.Add("PatientID", PatientID.ToString());
            //    }
            //    if (!controller.TempData.ContainsKey("PatientNum"))
            //    {
            //        controller.TempData.Add("PatientNum", PatientNum.ToString());
            //    }
            //    if (!controller.TempData.ContainsKey("IsReadOnly"))
            //    {
            //        controller.TempData.Add("IsReadOnly", IsReadOnly.ToString());
            //    }
            //}
           
        }
        
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //TempData["PatientID"] = model.PatientID;
            //TempData["PatientNum"] = model.PatientNum;
            //TempData["IsReadOnly"] = model.IsReadOnly;
        }
    }
}