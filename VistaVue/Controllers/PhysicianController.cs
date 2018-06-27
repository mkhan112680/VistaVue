using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VistaVue.Models;

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

        public ActionResult SavePayee(Payee payee)
        {
            
            //if (hdnPayeeTypeCompany == "1")
            //    payee.PayeeType = PayeeType.Company;

            //if (hdnPayeeTypePersonal == "1")
            //    payee.PayeeType = PayeeType.Personal;

            //payee.Provinces = VistaUser.Payee.Provinces;

            //payee.UserID = VistaUser.ID;

            //if (ModelState.IsValid)
            //{

            //    Entites.sp_UpdatePayee(
            //                            payee.UserID,
            //                            payee.CheckPayableTo,
            //                            payee.InternalRefNumber,
            //                            payee.Address1,
            //                            payee.Address2,
            //                            payee.AttentionTo,
            //                            payee.City,
            //                            payee.Province.ID,
            //                            payee.PostalCode,
            //                            payee.TaxNumber,
            //                            payee.Instructions,
            //                            (int)payee.PayeeType
            //                        );

            //}
            //return Json(new { Data = null }, JsonRequestBehavior.AllowGet);
            return Json(new { }, JsonRequestBehavior.AllowGet);
        }
    }
}