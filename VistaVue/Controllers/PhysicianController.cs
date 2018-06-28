using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VistaVue.Models;

namespace VistaVue.Controllers
{
    public class PhysicianController : BaseController
    {
        public ActionResult MOU()
        {
            return PartialView("MOU");
        }

        public ActionResult Payee()
        {
            return PartialView("Payee");
        }
        [HttpPost]
        public ActionResult SavePayee(Payee payee)
        {
            bool errored = false;
            string mssg = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(payee.CheckPayableTo))
                {
                    errored = true;
                    mssg = "Check PayableTo cannot be blank";
                }
                else
                {
                    Entites.sp_UpdatePayee(
                                        payee.UserID,
                                        payee.CheckPayableTo,
                                        payee.InternalRefNumber,
                                        payee.Address1,
                                        payee.Address2,
                                        payee.AttentionTo,
                                        payee.City,
                                        //payee.Province.ID,
                                        1,
                                        payee.PostalCode,
                                        payee.TaxNumber,
                                        payee.Instructions,
                                        (int)payee.Payee_Type
                                    );
                }
            }
            catch (Exception exc)
            {
                errored = true;
                mssg = exc.Message;
            }
            return Json(new {Message= mssg, Errored= errored }, JsonRequestBehavior.AllowGet);
        }
    }
}