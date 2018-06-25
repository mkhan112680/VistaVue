using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using VistaDM.Web.Helpers;
using VistaDM.Web.Models;

namespace VistaDM.Web.Controllers
{

    public class PhysicianController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }

        #region Action Items

        [Authorize]
        public ActionResult MOU()
        {
            return View(VistaUser);
        }

        [Authorize]
        [HttpPost]
        public JsonResult SetMOU(bool isChecked)
        {
            bool errored = false;
            try
            {
                Entites.sp_UpdateMOU(isChecked ? 1 : 0, VistaUser.ID);

                UserHelper.ReloadUser();

            }
            catch (Exception exc)
            {

                errored = true;
            }

            return Json(new { Result = errored }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        [Authorize]
        public ActionResult Payee()
        {
            ProvinceController provCntrl = new ProvinceController();

            VistaUser.Payee.Provinces = VistaUser.Payee.Provinces;

            return View(VistaUser.Payee);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Payee(PayeeModel payee, string hdnPayeeTypeCompany, string hdnPayeeTypePersonal)
        {


            if (hdnPayeeTypeCompany == "1")
                payee.PayeeType = PayeeType.Company;

            if (hdnPayeeTypePersonal == "1")
                payee.PayeeType = PayeeType.Personal;

            payee.Provinces = VistaUser.Payee.Provinces;

            payee.UserID = VistaUser.ID;

            if (ModelState.IsValid)
            {

                Entites.sp_UpdatePayee(
                                        payee.UserID,
                                        payee.CheckPayableTo,
                                        payee.InternalRefNumber,
                                        payee.Address1,
                                        payee.Address2,
                                        payee.AttentionTo,
                                        payee.City,
                                        payee.Province.ID,
                                        payee.PostalCode,
                                        payee.TaxNumber,
                                        payee.Instructions,
                                        (int)payee.PayeeType
                                    );

                UserHelper.ReloadUser();
            }


            // ModelState.AddModelError("ffff", "Date cannot be before the current date.");
            return View(payee);
        }

        [HttpGet]
        public ActionResult Not_Me()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register(string txtRegCode)
        {

            var row = Entites.sp_GetUserByRegCode(txtRegCode).SingleOrDefault();
            InviteeModel invitee = null;

            if (row != null)
            {
                invitee = new InviteeModel()
                {
                    ID = row.ID,
                    Address = row.Address,
                    City = row.City,
                    FaxNumber = row.Fax,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    PhoneNumber = row.Phone,
                    PostalCode = row.PostalCode,
                    Province = new ProvinceModel() { ID = row.ProvinceID.Value, Name = row.Province },
                    RegCode = txtRegCode,
                    ClinicName = row.Clinic
                };
            }

            TempData[Constants.INVITEE] = invitee;

            return View(invitee);
        }

        public ActionResult CompleteRegistration()
        {
            ViewBag.Error = string.Empty;

            InviteeModel invModel = TempData[Constants.INVITEE] as InviteeModel;

            invModel.Provinces = new SelectList((new ProvinceController()).GetList(), "ID", "FullName");

            TempData[Constants.INVITEE] = invModel;

            return View(invModel);
        }

        [HttpPost]
        public ActionResult CompleteRegistration(InviteeModel inv, bool check, bool check2)
        {
            ViewBag.Error = string.Empty;

            if (inv.Password != inv.ConfirmPassword)
                ModelState.AddModelError("", Resources.Resource.REGCOMPL_PWDS_MATCH);

            //if (!check)
            //    ModelState.AddModelError("", Resources.Resource.REGCOMPL_SEL_CHECKBOX);

            //if (!check2)
            //    ModelState.AddModelError("", Resources.Resource.REGCOMPL_SEL_CHECKBOX2);


            inv.RegCode = (TempData[Constants.INVITEE] as InviteeModel).RegCode;

            if (ModelState.IsValid)
            {
                try
                {
                    Entites.sp_RegisterUser(

                                        inv.UserName,
                                        Encryptor.Encrypt(inv.Password),
                                        inv.FirstName,
                                        inv.LastName,
                                        inv.ClinicName,
                                        inv.Address,
                                        inv.City,
                                        inv.Province.ID,
                                        inv.PostalCode,
                                        inv.PhoneNumber,
                                        inv.FaxNumber,
                                        inv.RegCode,
                                        check ? 1 : 0 ,
                                        check2 ? 1 : 0  
                        );

                    //send email
                    Emailer.SendHTMLEmail
                                       (
                                           inv.UserName,
                                           inv.FirstName,
                                           inv.LastName,
                                           inv.Password,
                                           Resources.Resource.REGISTEREMAIL_ATTACHMENT,
                                           Resources.Resource.REGISTEREMAIL_PAGE
                                        );



                    //FOR ALI
                    //Entites.sp_AddOptInEmail(inv.UserName, check ? 1 : 0, check2 ? 1 : 0);


                    return RedirectToAction("LoginByUsername", "Account", new LoginViewModel() { Email = inv.UserName });

                }
                catch (Exception exc)
                {
                    if (exc.InnerException != null)
                        ViewBag.Error = exc.InnerException.Message;
                    else
                        ViewBag.Error = exc.Message;
                }
            }

            inv.Provinces = new SelectList((new ProvinceController()).GetList(), "ID", "FullName");

            TempData[Constants.INVITEE] = inv;

            return View(inv);
        }

        #region Waitlist

        [HttpGet]
        public ActionResult WaitlistRegister(string txtRegCode)
        {

            var row = Entites.sp_GetUserByRegCode(txtRegCode).SingleOrDefault();
            InviteeModelWaitlist invitee = null;

            if (row != null)
            {
                invitee = new InviteeModelWaitlist()
                {
                    ID = row.ID,
                    City = row.City,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    Province = new ProvinceModel() { ID = row.ProvinceID.Value, Name = row.Province },
                    RegCode = txtRegCode,
                    
                };
            }

            TempData[Constants.INVITEE] = invitee;

            return View(invitee);
        }

        [HttpPost]
        public ActionResult WaitlistRegister(InviteeModelWaitlist inv)
        {
            ViewBag.Error = string.Empty;

            inv.RegCode = (TempData[Constants.INVITEE] as InviteeModelWaitlist).RegCode;

            if (string.IsNullOrEmpty(inv.Email))
                ModelState.AddModelError("EMAIL_REQ", Resources.Resource.Emailrequired);
            

            if (ModelState.IsValid)
            {
                try
                {
                    Entites.sp_AddToWaitList(

                                            inv.RegCode,
                                            inv.Email
                                        );


                    return RedirectToAction("WaitlistThankyou", "Physician");

                }
                catch (Exception exc)
                {
                    if (exc.InnerException != null)
                        ViewBag.Error = exc.InnerException.Message;
                    else
                        ViewBag.Error = exc.Message;
                }
            }


            return View();
        }


        public ActionResult WaitlistThankyou()
        {

            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        public JsonResult CheckRegistrationWaitlist(string txtRegCode)
        {
            string errorStr = string.Empty;
            bool errored = false;

            if (string.IsNullOrEmpty(txtRegCode))
            {
                errorStr = "Missing Registartion Code";
                errored = true;
            }
            else
            {
                try
                {
                    var row = Entites.sp_GetUserByRegCodeWaitList(txtRegCode).SingleOrDefault();
                    InviteeModel invitee = null;

                    if (row != null)
                    {
                        invitee = new InviteeModel()
                        {
                            ID = row.ID,
                            Address = row.Address,
                            City = row.City,
                            FaxNumber = row.Fax,
                            FirstName = row.FirstName,
                            LastName = row.LastName,
                            PhoneNumber = row.Phone,
                            PostalCode = row.PostalCode,
                            Province = new ProvinceModel() { ID = row.ProvinceID.Value, Name = row.Province },
                        };
                    }

                    if (invitee != null)
                    {
                        errored = false;
                    }
                    else
                    {
                        errorStr = "Invalid Reg Code";
                        errored = true;
                    }

                }
                catch (Exception exception)
                {
                    errorStr = exception.Message;
                    errored = true;
                }
            }

            return Json(new { Errored = errored, ErrorStr = errorStr }, JsonRequestBehavior.AllowGet);
        }

        #endregion 

        [HttpGet]
        [AllowAnonymous]
        public JsonResult CheckRegistration(string txtRegCode)
        {
            string errorStr = string.Empty;
            bool errored = false;

            if (string.IsNullOrEmpty(txtRegCode))
            {
                errorStr = "Missing Registartion Code";
                errored = true;
            }
            else
            {
                try
                {
                    var row = Entites.sp_GetUserByRegCode(txtRegCode).SingleOrDefault();
                    InviteeModel invitee = null;

                    if (row != null)
                    {
                        invitee = new InviteeModel()
                        {
                            ID = row.ID,
                            Address = row.Address,
                            City = row.City,
                            FaxNumber = row.Fax,
                            FirstName = row.FirstName,
                            LastName = row.LastName,
                            PhoneNumber = row.Phone,
                            PostalCode = row.PostalCode,
                            Province = new ProvinceModel() { ID = row.ProvinceID.Value, Name = row.Province },
                        };
                    }

                    if (invitee != null)
                    {
                        errored = false;
                    }
                    else
                    {
                        errorStr = "Invalid Reg Code";
                        errored = true;
                    }

                }
                catch (Exception exception)
                {
                    errorStr = exception.Message;
                    errored = true;
                }
            }

            return Json(new { Errored = errored, ErrorStr = errorStr }, JsonRequestBehavior.AllowGet);
        }


        //[HttpPost]
        //public ActionResult ConfirmRegistration()
        //{

        //    return View();
        //}

        public ActionResult ConfirmRegistration(string regCode)
        {
            //get all data from regcode and then pass a user object in the view

            return View();
        }


        [Authorize]
        public UserModel GetUserDetails()
        {
            Models.UserModel user;

            //var u = Entites.sp_GetUserDetails(Int32.Parse(User.Identity.GetUserId())).SingleOrDefault();
            var u = Entites.sp_GetUserDetails(UserHelper.GetUserID()).SingleOrDefault();

            user = new UserModel()
            {
                ID = u.ID,

                Username = u.Username,
                Password = u.Password,
                IsTest = u.IsTest.Value,

                MOU = u.MOU.HasValue ? u.MOU.Value : false,
                MOUDate = u.MOUDate.HasValue ? u.MOUDate.Value : new DateTime?(),
                AssesmentSurvey = u.AssesmentSurvey.HasValue ? u.AssesmentSurvey.Value : false,

                AssesmentSurveyDate = u.AssesmentSurveyDate.HasValue ? u.AssesmentSurveyDate.Value : new DateTime?(),
                PhysicanType = u.PhysicianType.HasValue ? ( u.PhysicianType.Value == 1 ? PhysicanType.PCP : PhysicanType.CS ) : PhysicanType.CS,
                FirstName = u.FirstName,
                LastName = u.LastName,
                PAF1_Complete = u.PAF1_Complete.HasValue ? u.PAF1_Complete.Value == 1 : false,

                Payee = new PayeeModel()
                {

                    ID = u.PayeeID.HasValue ? u.PayeeID.Value : -1,
                    Address1 = u.PayeeAddress1,
                    Address2 = u.PayeeAddress2,
                    AttentionTo = u.PayeeAttentionTo,
                    CheckPayableTo = u.PayeeCheckPayableTo,
                    City = u.PayeeCity,
                    DateEntered = u.PayeeDate.HasValue ? u.PayeeDate.Value : new DateTime?(),
                    Instructions = u.PayeeInstructions,
                    InternalRefNumber = u.PayeeInternalRefNumber,
                    PostalCode = u.PayeePostalCode,
                    Province = new ProvinceModel()
                    {
                        ID = u.PayeeProvinceID.HasValue ? u.PayeeProvinceID.Value : -1,
                        Name = u.PayeeProvince
                    },
                    TaxNumber = u.PayeeTaxNumber,
                    PayeeType = u.PayeeType.HasValue ? (u.PayeeType.Value == 1 ? PayeeType.Company : PayeeType.Personal) : PayeeType.NONE
                }
            };

            return user;
        }

        #endregion 

        #region Assesment Survey

        [Authorize]
        public ActionResult Assesment()
        {
            return RedirectToAction("AssesmentSurvey_Screen1");
        }


        [Authorize]
        public ActionResult AssesmentSurvey_Screen1()
        {
            AssesmentScreen1_Model model = new AssesmentScreen1_Model();

            model.ReadOnly = VistaUser.AssesmentSurveyDate.HasValue;

            foreach (var item in Entites.sp_GetAssesment_Screen1(VistaUser.ID).ToList())
            {

                if (item.QID == 1)
                {
                    model.q1.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 2)
                {
                    model.q2.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 3)
                {
                    model.q3.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 4)
                {
                    model.q4.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 5)
                {
                    model.q5.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 6)
                {
                    model.q6.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 7)
                {
                    model.q7.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 8)
                {
                    model.q8.Answer.Find(a => a.AID == item.AID).Selected = true;
                }
            }



            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AssesmentSurvey_Screen1(AssesmentScreen1_Model model)
        {
            model.ReadOnly = VistaUser.AssesmentSurveyDate.HasValue;
            if (model.ReadOnly)
                return RedirectToAction("AssesmentSurvey_Screen2");


            if (model.q1.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q1 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q2.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q2 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q3.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q3 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q4.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q4 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q5.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q5 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q6.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q6 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q7.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q7 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q8.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q8 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }


            if (ModelState.IsValid)
            {
                int qid_1 = model.q1.QID;
                int aid_1 = model.q1.SelectedAnswer.AID;

                int qid_2 = model.q2.QID;
                int aid_2 = model.q2.SelectedAnswer.AID;

                int qid_3 = model.q3.QID;
                int aid_3 = model.q3.SelectedAnswer.AID;

                int qid_4 = model.q4.QID;
                int aid_4 = model.q4.SelectedAnswer.AID;

                int qid_5 = model.q5.QID;
                int aid_5 = model.q5.SelectedAnswer.AID;

                int qid_6 = model.q6.QID;
                int aid_6 = model.q6.SelectedAnswer.AID;

                int qid_7 = model.q7.QID;
                int aid_7 = model.q7.SelectedAnswer.AID;

                int qid_8 = model.q8.QID;
                int aid_8 = model.q8.SelectedAnswer.AID;

                Entites.sp_SaveAssesment_Screen1(
                                                    VistaUser.ID,

                                                     qid_1,
                                                     aid_1,
                                                     string.Empty,

                                                     qid_2,
                                                     aid_2,
                                                     string.Empty,

                                                     qid_3,
                                                     aid_3,
                                                     string.Empty,

                                                     qid_4,
                                                     aid_4,
                                                     string.Empty,

                                                     qid_5,
                                                     aid_5,
                                                     string.Empty,

                                                     qid_6,
                                                     aid_6,
                                                     string.Empty,

                                                     qid_7,
                                                     aid_7,
                                                     string.Empty,

                                                     qid_8,
                                                     aid_8,
                                                     string.Empty
                                                );

                return RedirectToAction("AssesmentSurvey_Screen2");
            }

            return View(model);
        }



        [Authorize]
        public ActionResult AssesmentSurvey_Screen2()
        {
            AssesmentScreen2_Model model = new AssesmentScreen2_Model();

            model.ReadOnly = VistaUser.AssesmentSurveyDate.HasValue;

            foreach (var item in Entites.sp_GetAssesment_Screen2(VistaUser.ID).ToList())
            {

                if (item.QID == 9)
                {
                    model.q1.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 10)
                {
                    if (item.AnswerValue == "1")
                        model.q2.SelectedAnswers.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 11)
                {
                    if (item.AnswerValue == "1")
                        model.q3.SelectedAnswers.Find(a => a.AID == item.AID).Selected = true;

                    //model.q3.SelectedAnswers[q3Index].Selected = true;
                    //q3Index++;
                }

                if (item.QID == 12)
                {
                    model.q4.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 13)
                {
                    model.q5.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 14)
                {
                    model.q6.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 15)
                {
                    model.q7.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 16)
                {
                    model.q8.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 17)
                {
                    model.q9.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 18)
                {
                    model.q10.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 19)
                {
                    model.q11.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 20)
                {
                    model.q12.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 21)
                {
                    model.q13.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 22)
                {
                    model.q14.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 23)
                {
                    model.q15.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 24)
                {
                    model.q16.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 25)
                {
                    model.q17.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

            }

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AssesmentSurvey_Screen2(AssesmentScreen2_Model model)
        {
            model.ReadOnly = VistaUser.AssesmentSurveyDate.HasValue;
            if (model.ReadOnly)
                return RedirectToAction("AssesmentSurvey_Screen3");

            if (model.q1.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q9 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            #region Q2 Checkboxes

            bool q2ResponseFound = false;
            foreach (AnswerModel ans in model.q2.SelectedAnswers)
            {
                if (ans.Selected)
                {
                    q2ResponseFound = true;
                    break;
                }
            }
            if (!q2ResponseFound)
            {
                ModelState.AddModelError("", string.Format("Q9A {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            #endregion

            #region Q3 Checkboxes

            bool q3ResponseFound = false;
            foreach (AnswerModel ans in model.q3.SelectedAnswers)
            {
                if (ans.Selected)
                {
                    q3ResponseFound = true;
                    break;
                }
            }
            if (!q3ResponseFound)
            {
                ModelState.AddModelError("", string.Format("Q9B {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            #endregion

            if (model.q4.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q10 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q5.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q10 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q6.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q10 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q7.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q10 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q8.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q10 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q9.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q10 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q10.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q10 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q11.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q11 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q12.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q12 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q13.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q13 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q14.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q14 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q15.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q15 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q16.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q16 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q17.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q17 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }


            if (ModelState.IsValid)
            {
                int qid_1 = model.q1.QID;
                int aid_1 = model.q1.SelectedAnswer.AID;


                int qid_2_1 = model.q2.QID;
                int aid_2_1 = model.q2.SelectedAnswers[0].AID;
                bool selected_2_1 = model.q2.SelectedAnswers[0].Selected;

                int qid_2_2 = model.q2.QID;
                int aid_2_2 = model.q2.SelectedAnswers[1].AID;
                bool selected_2_2 = model.q2.SelectedAnswers[1].Selected;

                int qid_2_3 = model.q2.QID;
                int aid_2_3 = model.q2.SelectedAnswers[2].AID;
                bool selected_2_3 = model.q2.SelectedAnswers[2].Selected;

                int qid_2_4 = model.q2.QID;
                int aid_2_4 = model.q2.SelectedAnswers[3].AID;
                bool selected_2_4 = model.q2.SelectedAnswers[3].Selected;

                int qid_2_5 = model.q2.QID;
                int aid_2_5 = model.q2.SelectedAnswers[4].AID;
                bool selected_2_5 = model.q2.SelectedAnswers[4].Selected;

                int qid_2_6 = model.q2.QID;
                int aid_2_6 = model.q2.SelectedAnswers[5].AID;
                bool selected_2_6 = model.q2.SelectedAnswers[5].Selected;

                int qid_2_7 = model.q2.QID;
                int aid_2_7 = model.q2.SelectedAnswers[6].AID;
                bool selected_2_7 = model.q2.SelectedAnswers[6].Selected;

                int qid_2_8 = model.q2.QID;
                int aid_2_8 = model.q2.SelectedAnswers[7].AID;
                bool selected_2_8 = model.q2.SelectedAnswers[7].Selected;

                int qid_2_9 = model.q2.QID;
                int aid_2_9 = model.q2.SelectedAnswers[8].AID;
                bool selected_2_9 = model.q2.SelectedAnswers[8].Selected;


                int qid_3_1 = model.q3.QID;
                int aid_3_1 = model.q3.SelectedAnswers[0].AID;
                bool selected_3_1 = model.q3.SelectedAnswers[0].Selected;

                int qid_3_2 = model.q3.QID;
                int aid_3_2 = model.q3.SelectedAnswers[1].AID;
                bool selected_3_2 = model.q3.SelectedAnswers[1].Selected;

                int qid_3_3 = model.q3.QID;
                int aid_3_3 = model.q3.SelectedAnswers[2].AID;
                bool selected_3_3 = model.q3.SelectedAnswers[2].Selected;

                int qid_3_4 = model.q3.QID;
                int aid_3_4 = model.q3.SelectedAnswers[3].AID;
                bool selected_3_4 = model.q3.SelectedAnswers[3].Selected;



                int qid_4 = model.q4.QID;
                int aid_4 = model.q4.SelectedAnswer.AID;

                int qid_5 = model.q5.QID;
                int aid_5 = model.q5.SelectedAnswer.AID;

                int qid_6 = model.q6.QID;
                int aid_6 = model.q6.SelectedAnswer.AID;

                int qid_7 = model.q7.QID;
                int aid_7 = model.q7.SelectedAnswer.AID;

                int qid_8 = model.q8.QID;
                int aid_8 = model.q8.SelectedAnswer.AID;

                int qid_9 = model.q9.QID;
                int aid_9 = model.q9.SelectedAnswer.AID;

                int qid_10 = model.q10.QID;
                int aid_10 = model.q10.SelectedAnswer.AID;

                int qid_11 = model.q11.QID;
                int aid_11 = model.q11.SelectedAnswer.AID;

                int qid_12 = model.q12.QID;
                int aid_12 = model.q12.SelectedAnswer.AID;

                int qid_13 = model.q13.QID;
                int aid_13 = model.q13.SelectedAnswer.AID;

                int qid_14 = model.q14.QID;
                int aid_14 = model.q14.SelectedAnswer.AID;

                int qid_15 = model.q15.QID;
                int aid_15 = model.q15.SelectedAnswer.AID;

                int qid_16 = model.q16.QID;
                int aid_16 = model.q16.SelectedAnswer.AID;

                int qid_17 = model.q17.QID;
                int aid_17 = model.q17.SelectedAnswer.AID;

                Entites.sp_SaveAssesment_Screen2(
                                                    VistaUser.ID,

                                                     qid_1,
                                                     aid_1,
                                                     string.Empty,

                                                     qid_2_1,
                                                     aid_2_1,
                                                     selected_2_1 ? "1" : "0",

                                                     qid_2_2,
                                                     aid_2_2,
                                                     selected_2_2 ? "1" : "0",

                                                     qid_2_3,
                                                     aid_2_3,
                                                     selected_2_3 ? "1" : "0",

                                                     qid_2_4,
                                                     aid_2_4,
                                                     selected_2_4 ? "1" : "0",

                                                     qid_2_5,
                                                     aid_2_5,
                                                     selected_2_5 ? "1" : "0",

                                                     qid_2_6,
                                                     aid_2_6,
                                                     selected_2_6 ? "1" : "0",

                                                     qid_2_7,
                                                     aid_2_7,
                                                     selected_2_7 ? "1" : "0",

                                                     qid_2_8,
                                                     aid_2_8,
                                                     selected_2_8 ? "1" : "0",

                                                     qid_2_9,
                                                     aid_2_9,
                                                     selected_2_9 ? "1" : "0",

                                                     qid_3_1,
                                                     aid_3_1,
                                                     selected_3_1 ? "1" : "0",

                                                     qid_3_2,
                                                     aid_3_2,
                                                     selected_3_2 ? "1" : "0",

                                                     qid_3_3,
                                                     aid_3_3,
                                                     selected_3_3 ? "1" : "0",

                                                     qid_3_4,
                                                     aid_3_4,
                                                     selected_3_4 ? "1" : "0",

                                                     qid_4,
                                                     aid_4,
                                                     string.Empty,

                                                     qid_5,
                                                     aid_5,
                                                     string.Empty,

                                                     qid_6,
                                                     aid_6,
                                                     string.Empty,

                                                     qid_7,
                                                     aid_7,
                                                     string.Empty,

                                                     qid_8,
                                                     aid_8,
                                                     string.Empty,

                                                     qid_9,
                                                     aid_9,
                                                     string.Empty,

                                                     qid_10,
                                                     aid_10,
                                                     string.Empty,

                                                     qid_11,
                                                     aid_11,
                                                     string.Empty,

                                                     qid_12,
                                                     aid_12,
                                                     string.Empty,

                                                     qid_13,
                                                     aid_13,
                                                     string.Empty,

                                                     qid_14,
                                                     aid_14,
                                                     string.Empty,

                                                     qid_15,
                                                     aid_15,
                                                     string.Empty,

                                                     qid_16,
                                                     aid_16,
                                                     string.Empty,

                                                     qid_17,
                                                     aid_17,
                                                     string.Empty
                                                );

                return RedirectToAction("AssesmentSurvey_Screen3");
            }

            return View(model);
        }



        [Authorize]
        public ActionResult AssesmentSurvey_Screen3()
        {
            AssesmentScreen3_Model model = new AssesmentScreen3_Model();
            model.ReadOnly = VistaUser.AssesmentSurveyDate.HasValue;

            foreach (var item in Entites.sp_GetAssesment_Screen3(VistaUser.ID).ToList())
            {

                if (item.QID == 26)
                {
                    model.q1.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 27)
                {
                    model.q2.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 28)
                {
                    model.q3.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 29)
                {
                    model.q4.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 30)
                {
                    model.q5.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 31)
                {
                    model.q6.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 32)
                {
                    model.q7.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 33)
                {
                    model.q8.Answer.Find(a => a.AID == item.AID).Selected = true;
                }
            }

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AssesmentSurvey_Screen3(AssesmentScreen3_Model model)
        {
            model.ReadOnly = VistaUser.AssesmentSurveyDate.HasValue;
            if (model.ReadOnly)
                return RedirectToAction("AssesmentSurvey_Screen4");

            if (model.q1.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q18 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q2.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q19 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q3.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q20 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q4.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q21 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q5.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q22 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q6.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q23 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q7.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q24 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q8.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q25 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }


            if (ModelState.IsValid)
            {
                int qid_1 = model.q1.QID;
                int aid_1 = model.q1.SelectedAnswer.AID;

                int qid_2 = model.q2.QID;
                int aid_2 = model.q2.SelectedAnswer.AID;

                int qid_3 = model.q3.QID;
                int aid_3 = model.q3.SelectedAnswer.AID;

                int qid_4 = model.q4.QID;
                int aid_4 = model.q4.SelectedAnswer.AID;

                int qid_5 = model.q5.QID;
                int aid_5 = model.q5.SelectedAnswer.AID;

                int qid_6 = model.q6.QID;
                int aid_6 = model.q6.SelectedAnswer.AID;

                int qid_7 = model.q7.QID;
                int aid_7 = model.q7.SelectedAnswer.AID;

                int qid_8 = model.q8.QID;
                int aid_8 = model.q8.SelectedAnswer.AID;

                Entites.sp_SaveAssesment_Screen3(
                                                    VistaUser.ID,

                                                     qid_1,
                                                     aid_1,
                                                     string.Empty,

                                                     qid_2,
                                                     aid_2,
                                                     string.Empty,

                                                     qid_3,
                                                     aid_3,
                                                     string.Empty,

                                                     qid_4,
                                                     aid_4,
                                                     string.Empty,

                                                     qid_5,
                                                     aid_5,
                                                     string.Empty,

                                                     qid_6,
                                                     aid_6,
                                                     string.Empty,

                                                     qid_7,
                                                     aid_7,
                                                     string.Empty,

                                                     qid_8,
                                                     aid_8,
                                                     string.Empty
                                                );

                return RedirectToAction("AssesmentSurvey_Screen4");
            }
            return View(model);
        }



        [Authorize]
        public ActionResult AssesmentSurvey_Screen4()
        {
            AssesmentScreen4_Model model = new AssesmentScreen4_Model();

            model.ReadOnly = VistaUser.AssesmentSurveyDate.HasValue;


            foreach (var item in Entites.sp_GetAssesment_Screen4(VistaUser.ID).ToList())
            {

                if (item.QID == 34)
                {
                    model.q1.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 35)
                {
                    model.q2.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 36)
                {
                    model.q3.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 37)
                {
                    model.q4.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 38)
                {
                    model.q5.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 39)
                {
                    model.q6.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 40)
                {
                    model.q7.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 41)
                {
                    model.q8.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 42)
                {
                    model.q9.Answer.Find(a => a.AID == item.AID).Selected = true;
                }
                if (item.QID == 43)
                {
                    model.q10.Answer.Find(a => a.AID == item.AID).Selected = true;
                }
                if (item.QID == 44)
                {
                    model.q11.Answer.Find(a => a.AID == item.AID).Selected = true;
                }
                if (item.QID == 45)
                {
                    model.q12.Answer.Find(a => a.AID == item.AID).Selected = true;
                }
                if (item.QID == 46)
                {
                    model.q13.Answer.Find(a => a.AID == item.AID).Selected = true;
                }
                if (item.QID == 47)
                {
                    model.q14.Answer.Find(a => a.AID == item.AID).Selected = true;
                }
                if (item.QID == 48)
                {
                    model.q15.Answer.Find(a => a.AID == item.AID).Selected = true;
                }
                if (item.QID == 49)
                {
                    model.q16.Answer.Find(a => a.AID == item.AID).Selected = true;
                }
                if (item.QID == 50)
                {
                    if (item.AnswerValue == "1")
                        model.q17.SelectedAnswers.Find(a => a.AID == item.AID).Selected = true;
                }

            }

            return View(model);

        }

        [Authorize]
        [HttpPost]
        public ActionResult AssesmentSurvey_Screen4(AssesmentScreen4_Model model)
        {
            model.ReadOnly = VistaUser.AssesmentSurveyDate.HasValue;
            if (model.ReadOnly)
                return RedirectToAction("AssesmentSurvey_Screen5");

            if (model.q1.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q26 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q2.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q27 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q3.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q28 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q4.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q29 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q5.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q30 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q6.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q31 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q7.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q32 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q8.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q33 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q9.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q34 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }
            if (model.q10.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q35 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }
            if (model.q11.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q36 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }
            if (model.q12.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q37 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }
            if (model.q13.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q38 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }
            if (model.q14.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q39 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }
            if (model.q15.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q40 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }
            if (model.q16.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q41 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }


            #region Q2 Checkboxes

            bool q17ResponseFound = false;
            foreach (AnswerModel ans in model.q17.SelectedAnswers)
            {
                if (ans.Selected)
                {
                    q17ResponseFound = true;
                    break;
                }
            }
            if (!q17ResponseFound)
            {
                ModelState.AddModelError("", string.Format("Q42 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            #endregion


            if (ModelState.IsValid)
            {
                int qid_1 = model.q1.QID;
                int aid_1 = model.q1.SelectedAnswer.AID;

                int qid_2 = model.q2.QID;
                int aid_2 = model.q2.SelectedAnswer.AID;

                int qid_3 = model.q3.QID;
                int aid_3 = model.q3.SelectedAnswer.AID;

                int qid_4 = model.q4.QID;
                int aid_4 = model.q4.SelectedAnswer.AID;

                int qid_5 = model.q5.QID;
                int aid_5 = model.q5.SelectedAnswer.AID;

                int qid_6 = model.q6.QID;
                int aid_6 = model.q6.SelectedAnswer.AID;

                int qid_7 = model.q7.QID;
                int aid_7 = model.q7.SelectedAnswer.AID;

                int qid_8 = model.q8.QID;
                int aid_8 = model.q8.SelectedAnswer.AID;

                int qid_9 = model.q9.QID;
                int aid_9 = model.q9.SelectedAnswer.AID;

                int qid_10 = model.q10.QID;
                int aid_10 = model.q10.SelectedAnswer.AID;

                int qid_11 = model.q11.QID;
                int aid_11 = model.q11.SelectedAnswer.AID;

                int qid_12 = model.q12.QID;
                int aid_12 = model.q12.SelectedAnswer.AID;

                int qid_13 = model.q13.QID;
                int aid_13 = model.q13.SelectedAnswer.AID;

                int qid_14 = model.q14.QID;
                int aid_14 = model.q14.SelectedAnswer.AID;

                int qid_15 = model.q15.QID;
                int aid_15 = model.q15.SelectedAnswer.AID;

                int qid_16 = model.q16.QID;
                int aid_16 = model.q16.SelectedAnswer.AID;


                int qid_17_1 = model.q17.QID;
                int aid_17_1 = model.q17.SelectedAnswers[0].AID;
                bool selected_17_1 = model.q17.SelectedAnswers[0].Selected;

                int qid_17_2 = model.q17.QID;
                int aid_17_2 = model.q17.SelectedAnswers[1].AID;
                bool selected_17_2 = model.q17.SelectedAnswers[1].Selected;

                int qid_17_3 = model.q17.QID;
                int aid_17_3 = model.q17.SelectedAnswers[2].AID;
                bool selected_17_3 = model.q17.SelectedAnswers[2].Selected;

                int qid_17_4 = model.q17.QID;
                int aid_17_4 = model.q17.SelectedAnswers[3].AID;
                bool selected_17_4 = model.q17.SelectedAnswers[3].Selected;

                int qid_17_5 = model.q17.QID;
                int aid_17_5 = model.q17.SelectedAnswers[4].AID;
                bool selected_17_5 = model.q17.SelectedAnswers[4].Selected;

                int qid_17_6 = model.q17.QID;
                int aid_17_6 = model.q17.SelectedAnswers[5].AID;
                bool selected_17_6 = model.q17.SelectedAnswers[5].Selected;



                Entites.sp_SaveAssesment_Screen4(
                                                    VistaUser.ID,

                                                     qid_1,
                                                     aid_1,
                                                     string.Empty,

                                                     qid_2,
                                                     aid_2,
                                                     string.Empty,

                                                     qid_3,
                                                     aid_3,
                                                     string.Empty,

                                                     qid_4,
                                                     aid_4,
                                                     string.Empty,

                                                     qid_5,
                                                     aid_5,
                                                     string.Empty,

                                                     qid_6,
                                                     aid_6,
                                                     string.Empty,

                                                     qid_7,
                                                     aid_7,
                                                     string.Empty,

                                                     qid_8,
                                                     aid_8,
                                                     string.Empty,

                                                     qid_9,
                                                     aid_9,
                                                     string.Empty,

                                                     qid_10,
                                                     aid_10,
                                                     string.Empty,

                                                     qid_11,
                                                     aid_11,
                                                     string.Empty,

                                                     qid_12,
                                                     aid_12,
                                                     string.Empty,

                                                     qid_13,
                                                     aid_13,
                                                     string.Empty,

                                                     qid_14,
                                                     aid_14,
                                                     string.Empty,

                                                     qid_15,
                                                     aid_15,
                                                     string.Empty,

                                                     qid_16,
                                                     aid_16,
                                                     string.Empty,

                                                      qid_17_1,
                                                      aid_17_1,
                                                      selected_17_1 ? "1" : "0",

                                                      qid_17_2,
                                                      aid_17_2,
                                                      selected_17_2 ? "1" : "0",

                                                      qid_17_3,
                                                      aid_17_3,
                                                      selected_17_3 ? "1" : "0",

                                                      qid_17_4,
                                                      aid_17_4,
                                                      selected_17_4 ? "1" : "0",

                                                      qid_17_5,
                                                      aid_17_5,
                                                      selected_17_5 ? "1" : "0",

                                                      qid_17_6,
                                                      aid_17_6,
                                                      selected_17_6 ? "1" : "0"
                                                );

                return RedirectToAction("AssesmentSurvey_Screen5");
            }
            return View(model);
        }



        [Authorize]
        public ActionResult AssesmentSurvey_Screen5()
        {
            AssesmentScreen5_Model model = new AssesmentScreen5_Model();

            model.ReadOnly = VistaUser.AssesmentSurveyDate.HasValue;
            model.Completed = false;

            foreach (var item in Entites.sp_GetAssesment_Screen5(VistaUser.ID).ToList())
            {

                if (item.QID == 52)
                {
                    model.q1.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 53)
                {
                    model.q2.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 54)
                {
                    model.q3.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 55)
                {
                    model.q4.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 56)
                {
                    model.q5.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 57)
                {
                    model.q6.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 58)
                {
                    model.q7.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 77)
                {
                    model.q8.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 59)
                {
                    model.q9.Answer.Find(a => a.AID == item.AID).Selected = true;
                }
                if (item.QID == 60)
                {
                    if (item.AnswerValue == "1")
                        model.q10.SelectedAnswers.Find(a => a.AID == item.AID).Selected = true;
                }
                if (item.QID == 61)
                {
                    if (item.AnswerValue == "1")
                        model.q11.SelectedAnswers.Find(a => a.AID == item.AID).Selected = true;
                }
                if (item.QID == 62)
                {
                    if (item.AnswerValue == "1")
                        model.q12.SelectedAnswers.Find(a => a.AID == item.AID).Selected = true;

                }
                if (item.QID == 63)
                {
                    model.q13.Answer.Find(a => a.AID == item.AID).Selected = true;
                }
                if (item.QID == 64)
                {
                    model.q14.Answer.Find(a => a.AID == item.AID).Selected = true;
                }
                if (item.QID == 65)
                {
                    model.q15.Answer.Find(a => a.AID == item.AID).Selected = true;
                }
                if (item.QID == 66)
                {
                    model.q16.Answer.Find(a => a.AID == item.AID).Selected = true;
                }
                if (item.QID == 67)
                {
                    model.q17.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 68)
                {
                    model.q18.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 69)
                {
                    model.q19.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 70)
                {
                    model.q20.Answer.Find(a => a.AID == item.AID).Selected = true;
                }
                if (item.QID == 71)
                {
                    model.q21.Answer.Find(a => a.AID == item.AID).Selected = true;
                }
                if (item.QID == 72)
                {
                    model.q22.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 73)
                {
                    model.q23.Answer.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 74)
                {
                    if (item.AnswerValue == "1")
                        model.q24.SelectedAnswers.Find(a => a.AID == item.AID).Selected = true;
                }

                if (item.QID == 75)
                {
                    model.q25.Answer.Find(a => a.AID == item.AID).Selected = true;
                }
                if (item.QID == 76)
                {
                    model.q26.Answer.Find(a => a.AID == item.AID).Selected = true;
                }
                model.Completed = true;
            }

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AssesmentSurvey_Screen5(AssesmentScreen5_Model model)
        {
            model.ReadOnly = VistaUser.AssesmentSurveyDate.HasValue;

            //if (model.ReadOnly)
            //    return RedirectToAction("Index", "Home");

            if (model.q1.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q43 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q2.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q43 B {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q3.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q43 C {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q4.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q43 D {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q5.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q44 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q6.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q44 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q7.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q44 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            //if (model.q8.SelectedAnswer.AID == 0)
            //{
            //    ModelState.AddModelError("", string.Format("Q44 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            //}

            if (model.q9.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q45 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }
            if (model.q10.SelectedAnswer.AID == 0)
            {

                bool q10ResponseFound = false;
                foreach (AnswerModel ans in model.q10.SelectedAnswers)
                {
                    if (ans.Selected)
                    {
                        q10ResponseFound = true;
                        break;
                    }
                }
                if (!q10ResponseFound)
                {
                    ModelState.AddModelError("", string.Format("Q46 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
                }
            }

            if (model.q11.SelectedAnswer.AID == 0)
            {
                bool q11ResponseFound = false;
                foreach (AnswerModel ans in model.q11.SelectedAnswers)
                {
                    if (ans.Selected)
                    {
                        q11ResponseFound = true;
                        break;
                    }
                }
                if (!q11ResponseFound)
                {
                    ModelState.AddModelError("", string.Format("Q47 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
                }
            }
            if (model.q12.SelectedAnswer.AID == 0)
            {
                bool q12ResponseFound = false;
                foreach (AnswerModel ans in model.q12.SelectedAnswers)
                {
                    if (ans.Selected)
                    {
                        q12ResponseFound = true;
                        break;
                    }
                }
                if (!q12ResponseFound)
                {
                    ModelState.AddModelError("", string.Format("Q48 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
                }
            }
            if (model.q13.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q38 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }
            if (model.q14.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q49 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }
            if (model.q15.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q49 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }
            if (model.q16.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q49 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q17.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q49 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q18.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q49 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q19.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q49 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q20.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q49 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q21.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q49 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q22.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q49 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q23.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q49 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q24.SelectedAnswer.AID == 0)
            {
                bool q24ResponseFound = false;
                foreach (AnswerModel ans in model.q24.SelectedAnswers)
                {
                    if (ans.Selected)
                    {
                        q24ResponseFound = true;
                        break;
                    }
                }
                if (!q24ResponseFound)
                {
                    ModelState.AddModelError("", string.Format("Q50 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
                }
            }

            if (model.q25.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q51 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }

            if (model.q26.SelectedAnswer.AID == 0)
            {
                ModelState.AddModelError("", string.Format("Q52 {0}", Resources.Resource.NEEDS_ASSES_RES_REQ));
            }



            if (ModelState.IsValid)
            {
                int qid_1 = model.q1.QID;
                int aid_1 = model.q1.SelectedAnswer.AID;

                int qid_2 = model.q2.QID;
                int aid_2 = model.q2.SelectedAnswer.AID;

                int qid_3 = model.q3.QID;
                int aid_3 = model.q3.SelectedAnswer.AID;

                int qid_4 = model.q4.QID;
                int aid_4 = model.q4.SelectedAnswer.AID;

                int qid_5 = model.q5.QID;
                int aid_5 = model.q5.SelectedAnswer.AID;

                int qid_6 = model.q6.QID;
                int aid_6 = model.q6.SelectedAnswer.AID;

                int qid_7 = model.q7.QID;
                int aid_7 = model.q7.SelectedAnswer.AID;

                int qid_8 = model.q8.QID;
                int aid_8 = 271;//model.q8.SelectedAnswer.AID;

                int qid_9 = model.q9.QID;
                int aid_9 = model.q9.SelectedAnswer.AID;


                int qid_10 = model.q10.QID;

                int aid_10_1 = model.q10.SelectedAnswers[0].AID;
                bool selected_10_1 = model.q10.SelectedAnswers[0].Selected;

                int aid_10_2 = model.q10.SelectedAnswers[1].AID;
                bool selected_10_2 = model.q10.SelectedAnswers[1].Selected;

                int aid_10_3 = model.q10.SelectedAnswers[2].AID;
                bool selected_10_3 = model.q10.SelectedAnswers[2].Selected;

                int aid_10_4 = model.q10.SelectedAnswers[3].AID;
                bool selected_10_4 = model.q10.SelectedAnswers[3].Selected;

                int aid_10_5 = model.q10.SelectedAnswers[4].AID;
                bool selected_10_5 = model.q10.SelectedAnswers[4].Selected;

                int aid_10_6 = model.q10.SelectedAnswers[5].AID;
                bool selected_10_6 = model.q10.SelectedAnswers[5].Selected;

                int aid_10_7 = model.q10.SelectedAnswers[6].AID;
                bool selected_10_7 = model.q10.SelectedAnswers[6].Selected;



                int qid_11 = model.q11.QID;

                int aid_11_1 = model.q11.SelectedAnswers[0].AID;
                bool selected_11_1 = model.q11.SelectedAnswers[0].Selected;

                int aid_11_2 = model.q11.SelectedAnswers[1].AID;
                bool selected_11_2 = model.q11.SelectedAnswers[1].Selected;

                int aid_11_3 = model.q11.SelectedAnswers[2].AID;
                bool selected_11_3 = model.q11.SelectedAnswers[2].Selected;

                int aid_11_4 = model.q11.SelectedAnswers[3].AID;
                bool selected_11_4 = model.q11.SelectedAnswers[3].Selected;

                int aid_11_5 = model.q11.SelectedAnswers[4].AID;
                bool selected_11_5 = model.q11.SelectedAnswers[4].Selected;

                int aid_11_6 = model.q11.SelectedAnswers[5].AID;
                bool selected_11_6 = model.q11.SelectedAnswers[5].Selected;

                int aid_11_7 = model.q11.SelectedAnswers[6].AID;
                bool selected_11_7 = model.q11.SelectedAnswers[6].Selected;

                int aid_11_8 = model.q11.SelectedAnswers[7].AID;
                bool selected_11_8 = model.q11.SelectedAnswers[7].Selected;

                int aid_11_9 = model.q11.SelectedAnswers[8].AID;
                bool selected_11_9 = model.q11.SelectedAnswers[8].Selected;

                int aid_11_10 = model.q11.SelectedAnswers[9].AID;
                bool selected_11_10 = model.q11.SelectedAnswers[9].Selected;



                int qid_12 = model.q12.QID;

                int aid_12_1 = model.q12.SelectedAnswers[0].AID;
                bool selected_12_1 = model.q12.SelectedAnswers[0].Selected;

                int aid_12_2 = model.q12.SelectedAnswers[1].AID;
                bool selected_12_2 = model.q12.SelectedAnswers[1].Selected;

                int aid_12_3 = model.q12.SelectedAnswers[2].AID;
                bool selected_12_3 = model.q12.SelectedAnswers[2].Selected;

                int aid_12_4 = model.q12.SelectedAnswers[3].AID;
                bool selected_12_4 = model.q12.SelectedAnswers[3].Selected;

                int aid_12_5 = model.q12.SelectedAnswers[4].AID;
                bool selected_12_5 = model.q12.SelectedAnswers[4].Selected;

                int aid_12_6 = model.q12.SelectedAnswers[5].AID;
                bool selected_12_6 = model.q12.SelectedAnswers[5].Selected;

                int aid_12_7 = model.q12.SelectedAnswers[6].AID;
                bool selected_12_7 = model.q12.SelectedAnswers[6].Selected;

                int aid_12_8 = model.q12.SelectedAnswers[7].AID;
                bool selected_12_8 = model.q12.SelectedAnswers[7].Selected;



                int qid_13 = model.q13.QID;
                int aid_13 = model.q13.SelectedAnswer.AID;

                int qid_14 = model.q14.QID;
                int aid_14 = model.q14.SelectedAnswer.AID;

                int qid_15 = model.q15.QID;
                int aid_15 = model.q15.SelectedAnswer.AID;

                int qid_16 = model.q16.QID;
                int aid_16 = model.q16.SelectedAnswer.AID;

                int qid_17 = model.q17.QID;
                int aid_17 = model.q17.SelectedAnswer.AID;

                int qid_18 = model.q18.QID;
                int aid_18 = model.q18.SelectedAnswer.AID;

                int qid_19 = model.q19.QID;
                int aid_19 = model.q19.SelectedAnswer.AID;

                int qid_20 = model.q20.QID;
                int aid_20 = model.q20.SelectedAnswer.AID;

                int qid_21 = model.q21.QID;
                int aid_21 = model.q21.SelectedAnswer.AID;

                int qid_22 = model.q22.QID;
                int aid_22 = model.q22.SelectedAnswer.AID;

                int qid_23 = model.q23.QID;
                int aid_23 = model.q23.SelectedAnswer.AID;

                int qid_24 = model.q24.QID;

                int aid_24_1 = model.q24.SelectedAnswers[0].AID;
                bool selected_24_1 = model.q24.SelectedAnswers[0].Selected;

                int aid_24_2 = model.q24.SelectedAnswers[1].AID;
                bool selected_24_2 = model.q24.SelectedAnswers[1].Selected;

                int aid_24_3 = model.q24.SelectedAnswers[2].AID;
                bool selected_24_3 = model.q24.SelectedAnswers[2].Selected;

                int aid_24_4 = model.q24.SelectedAnswers[3].AID;
                bool selected_24_4 = model.q24.SelectedAnswers[3].Selected;

                int aid_24_5 = model.q24.SelectedAnswers[4].AID;
                bool selected_24_5 = model.q24.SelectedAnswers[4].Selected;

                int aid_24_6 = model.q24.SelectedAnswers[5].AID;
                bool selected_24_6 = model.q24.SelectedAnswers[5].Selected;


                int qid_25 = model.q25.QID;
                int aid_25 = model.q25.SelectedAnswer.AID;

                int qid_26 = model.q26.QID;
                int aid_26 = model.q26.SelectedAnswer.AID;



                Entites.sp_SaveAssesment_Screen5(
                                                    VistaUser.ID,

                                                     qid_1,
                                                     aid_1,
                                                     string.Empty,

                                                     qid_2,
                                                     aid_2,
                                                     string.Empty,

                                                     qid_3,
                                                     aid_3,
                                                     string.Empty,

                                                     qid_4,
                                                     aid_4,
                                                     string.Empty,

                                                     qid_5,
                                                     aid_5,
                                                     string.Empty,

                                                     qid_6,
                                                     aid_6,
                                                     string.Empty,

                                                     qid_7,
                                                     aid_7,
                                                     string.Empty,

                                                     qid_8,
                                                     aid_8,
                                                     string.Empty,

                                                     qid_9,
                                                     aid_9,
                                                     string.Empty,

                                                     qid_10,
                                                     aid_10_1,
                                                     selected_10_1 ? "1" : "0",

                                                     qid_10,
                                                     aid_10_2,
                                                     selected_10_2 ? "1" : "0",

                                                     qid_10,
                                                     aid_10_3,
                                                     selected_10_3 ? "1" : "0",

                                                     qid_10,
                                                     aid_10_4,
                                                     selected_10_4 ? "1" : "0",

                                                     qid_10,
                                                     aid_10_5,
                                                     selected_10_5 ? "1" : "0",

                                                     qid_10,
                                                     aid_10_6,
                                                     selected_10_6 ? "1" : "0",

                                                     qid_10,
                                                     aid_10_7,
                                                     selected_10_7 ? "1" : "0",


                                                     qid_11,
                                                     aid_11_1,
                                                     selected_11_1 ? "1" : "0",

                                                     qid_11,
                                                     aid_11_2,
                                                     selected_11_2 ? "1" : "0",

                                                     qid_11,
                                                     aid_11_3,
                                                     selected_11_3 ? "1" : "0",

                                                     qid_11,
                                                     aid_11_4,
                                                     selected_11_4 ? "1" : "0",

                                                     qid_11,
                                                     aid_11_5,
                                                     selected_11_5 ? "1" : "0",

                                                      qid_11,
                                                     aid_11_6,
                                                     selected_11_6 ? "1" : "0",

                                                      qid_11,
                                                     aid_11_7,
                                                     selected_11_7 ? "1" : "0",

                                                      qid_11,
                                                     aid_11_8,
                                                     selected_11_8 ? "1" : "0",

                                                      qid_11,
                                                     aid_11_9,
                                                     selected_11_9 ? "1" : "0",

                                                     qid_11,
                                                     aid_11_10,
                                                     selected_11_10 ? "1" : "0",

                                                     qid_12,
                                                     aid_12_1,
                                                     selected_12_1 ? "1" : "0",

                                                     qid_12,
                                                     aid_12_2,
                                                     selected_12_2 ? "1" : "0",

                                                     qid_12,
                                                     aid_12_3,
                                                     selected_12_3 ? "1" : "0",

                                                     qid_12,
                                                     aid_12_4,
                                                     selected_12_4 ? "1" : "0",

                                                     qid_12,
                                                     aid_12_5,
                                                     selected_12_5 ? "1" : "0",

                                                     qid_12,
                                                     aid_12_6,
                                                     selected_12_6 ? "1" : "0",

                                                     qid_12,
                                                     aid_12_7,
                                                     selected_12_7 ? "1" : "0",

                                                     qid_12,
                                                     aid_12_8,
                                                     selected_12_8 ? "1" : "0",

                                                     qid_13,
                                                     aid_13,
                                                     string.Empty,

                                                     qid_14,
                                                     aid_14,
                                                     string.Empty,

                                                     qid_15,
                                                     aid_15,
                                                     string.Empty,

                                                     qid_16,
                                                     aid_16,
                                                     string.Empty,

                                                     qid_17,
                                                     aid_17,
                                                     string.Empty,

                                                     qid_18,
                                                     aid_18,
                                                     string.Empty,

                                                     qid_19,
                                                     aid_19,
                                                     string.Empty,

                                                     qid_20,
                                                     aid_20,
                                                     string.Empty,

                                                     qid_21,
                                                     aid_21,
                                                     string.Empty,

                                                     qid_22,
                                                     aid_22,
                                                     string.Empty,

                                                     qid_23,
                                                     aid_23,
                                                     string.Empty,


                                                     qid_24,
                                                     aid_24_1,
                                                     selected_24_1 ? "1" : "0",

                                                     qid_24,
                                                     aid_24_2,
                                                     selected_24_2 ? "1" : "0",

                                                     qid_24,
                                                     aid_24_3,
                                                     selected_24_3 ? "1" : "0",

                                                     qid_24,
                                                     aid_24_4,
                                                     selected_24_4 ? "1" : "0",

                                                     qid_24,
                                                     aid_24_5,
                                                     selected_24_5 ? "1" : "0",

                                                     qid_24,
                                                     aid_24_6,
                                                     selected_24_6 ? "1" : "0",


                                                     qid_25,
                                                     aid_25,
                                                     string.Empty,

                                                     qid_26,
                                                     aid_26,
                                                     string.Empty


                                                );


                model.Completed = true;
            }
            return View(model);
        }

        public ActionResult Review()
        {
            //if ( Entites.sp_GetAssesment_Screen5(VistaUser.ID).ToList().Count == 0  )
            //{
            //    ViewBag.Error = "Please complete This page before reviewing";
            //    return View("AssesmentSurvey_Screen5", new AssesmentScreen5_Model() );
            //}
            //else
            //{
            //    return RedirectToAction("Assesment");
            //}


            return RedirectToAction("Assesment");
        }

        //[HttpPost]
        //[MultipleButton(Name = "action", Argument = "Review")]
        //public ActionResult Review(AssesmentScreen5_Model model) 
        //{
        //    return View("Index", model);
        //}


        public ActionResult Submit()
        {
            //if (Entites.sp_GetAssesment_Screen5(VistaUser.ID).ToList().Count == 0)
            //{
            //    ViewBag.Error = "Please complete This page before submitting";
            //    return View("AssesmentSurvey_Screen5", new AssesmentScreen5_Model());
            //}
            //else
            //{
            //    CloseAssesment();
            //    return RedirectToAction("Assesment");
            //}

            CloseAssesment();
            return RedirectToAction("Assesment");

        }

        public void CloseAssesment()
        {

            Entites.sp_CloseAssesment(VistaUser.ID);

            UserHelper.ReloadUser();

        }

        //public ActionResult CloseAssesment()
        //{

        //    Entites.sp_CloseAssesment(VistaUser.ID);

        //    UserHelper.ReloadUser();

        //    //return RedirectToAction("Index", "Home");
        //}

        #endregion

        #region Practice Assesment

        public ActionResult Instructions()
        {

            return View();
        }

        public void Write(int patientID, int patientNum, bool readOnly)
        {
            TempData[Constants.PatientID] = patientID;
            TempData[Constants.PatientNum] = patientNum;
            TempData[Constants.IsReadOnly] = readOnly;
        }

        //public void Read(ref int patientID, ref int patientNum, ref bool readOnly)
        //{
        //    patientID = Int32.Parse(TempData[Constants.PatientID].ToString());
        //    patientNum = Int32.Parse(TempData[Constants.PatientNum].ToString());
        //    readOnly  = bool.Parse(TempData[Constants.IsReadOnly].ToString());
        //}

        [Authorize]
        public ActionResult Add_PA_Patient()
        {

            Entites.sp_AddPracticeAssesPatient(base.VistaUser.ID);

            return RedirectToAction("PracticeAssessment");
        }

        [HttpGet]
        public ActionResult Start_PAF(int PatientID, int PatientNum, bool IsReadOnly)
        {

            Write(PatientID, PatientNum, IsReadOnly);

            return RedirectToAction("PracticeAssessment_Screen1");
        }

        [Authorize]
        public ActionResult PracticeAssessment()
        {
            List<PracticeAssesmentEntry> retLst = new List<PracticeAssesmentEntry>();
            int patientNum = 0;
            foreach (var item in Entites.sp_GetPracticeAssesmentView(base.VistaUser.ID))
            {
                retLst.Add(new PracticeAssesmentEntry()
                {
                    PatientID = item.PatientID,
                    UserID = item.UserID.HasValue ? item.UserID.Value : -1,
                    ScheduledAppDate = item.ScheduledAppointmentDate,
                    PatientNum = ++patientNum,

                    Status = item.Status.HasValue ? (PracticeAssesmentStatus)item.Status.Value : PracticeAssesmentStatus.NotSet,

                    PAF_Status = item.PAF_Status.HasValue ? (PracticeAssesmentStatus)item.PAF_Status.Value : PracticeAssesmentStatus.NotSet,

                    FF_Status = item.FF_Status.HasValue ? (PracticeAssesmentStatus)item.FF_Status.Value : PracticeAssesmentStatus.NotSet

                    //Status =
                    //         item.Status.HasValue ?
                    //         (item.Status.Value == 1 ? PracticeAssesmentStatus.Incomplete : PracticeAssesmentStatus.Complete) :
                    //         PracticeAssesmentStatus.NotSet,

                    //PAF_Status =
                    //item.PAF_Status.HasValue ?
                    //(item.PAF_Status.Value == 1 ? PracticeAssesmentStatus.Incomplete : PracticeAssesmentStatus.Complete) :
                    //PracticeAssesmentStatus.NotSet,

                    //FF_Status =
                    //         item.FF_Status.HasValue ?
                    //         (item.FF_Status.Value == 1 ? PracticeAssesmentStatus.Incomplete : PracticeAssesmentStatus.Complete) :
                    //         PracticeAssesmentStatus.NotSet,
                }
                            );
            }

            return View(retLst);
        }

        [Authorize]
        [HttpGet]
        public ActionResult PracticeAssessment_Screen1()
        {

            PracticeAssessment_P1 model = new PracticeAssessment_P1();

            //model.PatientID = PatientID.HasValue ? PatientID.Value : Int32.Parse(TempData["PatientID"].ToString());
            //model.PatientNum = PatientNum.HasValue ? PatientNum.Value : Int32.Parse(TempData["PatientNum"].ToString());
            //model.IsReadOnly = IsReadOnly.HasValue ? IsReadOnly.Value : bool.Parse(TempData["IsReadOnly"].ToString());

            model.PatientID = Int32.Parse(TempData[Constants.PatientID].ToString());
            model.PatientNum = Int32.Parse(TempData[Constants.PatientNum].ToString());
            model.IsReadOnly = bool.Parse(TempData[Constants.IsReadOnly].ToString());

            var entry = Entites.sp_Get_PA_Eligibility(model.PatientID).SingleOrDefault();
            if (entry != null)
            {
                model.ID = entry.ID;
                model.PatientID = entry.PatientID.Value;
                model.InternalRefNum = entry.InternalRefNum;
                model.ScheduledAppointment = entry.NextAppointment.Value;
            }

            Write(model.PatientID, model.PatientNum, model.IsReadOnly);


            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult PracticeAssessment_Screen1(PracticeAssessment_P1 model, bool chk1, bool chk2)
        {

            if (model.IsReadOnly)
                return RedirectToAction("PracticeAssessment_Screen2", new { PatientID = model.PatientID, PatientNum = model.PatientNum, IsReadOnly = model.IsReadOnly });

            if (!chk1)
            {
                ModelState.AddModelError("CHECK1", Resources.Resource.CHECK1);
            }

            if (!chk2)
            {
                ModelState.AddModelError("CHECK2", Resources.Resource.CHECK2);

            }

            if (ModelState.IsValid)
            {
                Entites.sp_Set_PA_Eligibility(model.PatientID, model.InternalRefNum, model.ScheduledAppointment);

                return RedirectToAction("PracticeAssessment_Screen2");
                //return RedirectToAction("PracticeAssessment_Screen2", new { PatientID = model.PatientID, PatientNum = model.PatientNum, IsReadOnly=model.IsReadOnly });
            }

            Write(model.PatientID, model.PatientNum, model.IsReadOnly);

            return View(model);
        }


        [Authorize]
        public ActionResult PracticeAssessment_Screen2()
        {
            PracticeAssessment_P2 model = new PracticeAssessment_P2();
            //model.PatientID = PatientID;
            //model.PatientNum = PatientNum;
            //model.IsReadOnly = IsReadOnly;

            //model.PatientID = PatientID.HasValue ? PatientID.Value : Int32.Parse(TempData["PatientID"].ToString());
            //model.PatientNum = PatientNum.HasValue ? PatientNum.Value : Int32.Parse(TempData["PatientNum"].ToString());
            //model.IsReadOnly = IsReadOnly.HasValue ? IsReadOnly.Value : bool.Parse(TempData["IsReadOnly"].ToString());

            model.PatientID = Int32.Parse(TempData[Constants.PatientID].ToString());
            model.PatientNum = Int32.Parse(TempData[Constants.PatientNum].ToString());
            model.IsReadOnly = bool.Parse(TempData[Constants.IsReadOnly].ToString());

            var row = Entites.sp_Get_PA_Demo(model.PatientID).SingleOrDefault();
            if (row != null)
            {
                model.Age = row.Age.Value;
                model.ID = row.ID;
                model.PatientID = row.PatientID.Value;

                model.Gender = row.Gender;
                model.DurationDiabetes = row.DurationDiabetes;
                model.Ethnicity = row.Ethnicity;
                model.MedicationCoverage = row.MedicationCoverage;
                model.EmploymentStatus = row.EmploymentStatus;

                model.CoManagedCardiologist = row.PatientCoManaged_Cardiologist.Value;
                model.CoManagedEducator = row.PatientCoManaged_Educator.Value;
                model.CoManagedEndocrinologist = row.PatientCoManaged_Endocrinologist.Value;
                model.CoManagedInternist = row.PatientCoManaged_Internist.Value;
                model.CoManagedNephrologist = row.PatientCoManaged_Nephrologist.Value;
                model.CoManagedOphthalmologist = row.PatientCoManaged_Ophthalmologist.Value;
                model.CoManagedNone = row.PatientCoManaged_None.Value;

                model.HowManyMeds = row.HowManyMedications;
                model.MedsAntihyperglycemic = row.HowManyMedications_Antihyperglycemic;
                model.HowAdherent = row.HowAdherent;

                model.MedicationAdherance1 = row.MedicationAdherance_1.Value;
                model.MedicationAdherance2 = row.MedicationAdherance_2.Value;
                model.MedicationAdherance3 = row.MedicationAdherance_3.Value;
                model.MedicationAdherance4 = row.MedicationAdherance_4.Value;
                model.MedicationAdherance5 = row.MedicationAdherance_5.Value;
                model.LanguageBarriers = row.Language_Barriers;

            }

            Write(model.PatientID, model.PatientNum, model.IsReadOnly);


            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult PracticeAssessment_Screen2(PracticeAssessment_P2 model)
        {

            if (model.IsReadOnly)
                return RedirectToAction("PracticeAssessment_Screen3", new { PatientID = model.PatientID, PatientNum = model.PatientNum, IsReadOnly = model.IsReadOnly });


            //none selected 
            if (
                  !(
                        model.CoManagedCardiologist ||
                        model.CoManagedEducator ||
                        model.CoManagedEndocrinologist ||
                        model.CoManagedInternist ||
                        model.CoManagedNephrologist ||
                        model.CoManagedOphthalmologist ||
                        model.CoManagedNone
                    )
                )
            {
                this.ModelState.AddModelError("CoManaged", "*");
            }

            //none selected 
            if (
                    !(
                        model.MedicationAdherance1 ||
                        model.MedicationAdherance2 ||
                        model.MedicationAdherance3 ||
                        model.MedicationAdherance4 ||
                        model.MedicationAdherance5
                    )

                )
            {
                this.ModelState.AddModelError("MedicationAdherance", "*");
            }


            if (model.Age.Value < 18 || model.Age.Value > 100)
            {
                this.ModelState.AddModelError("AgeRange", Resources.Resource.PAF_AGE_ERROR);
            }



            if (ModelState.IsValid)
            {
                Entites.sp_Set_PA_Demo(

                                model.PatientID,
                                model.Age,
                                model.Gender,
                                model.DurationDiabetes,
                                model.Ethnicity,
                                model.MedicationCoverage,
                                model.EmploymentStatus,

                                model.CoManagedCardiologist,
                                model.CoManagedEducator,
                                model.CoManagedEndocrinologist,
                                model.CoManagedInternist,
                                model.CoManagedNephrologist,
                                model.CoManagedOphthalmologist,
                                model.CoManagedNone,

                                model.HowManyMeds,
                                model.MedsAntihyperglycemic,
                                model.HowAdherent,

                                model.MedicationAdherance1,
                                model.MedicationAdherance2,
                                model.MedicationAdherance3,
                                model.MedicationAdherance4,
                                model.MedicationAdherance5,

                                model.LanguageBarriers
                    );

                return RedirectToAction("PracticeAssessment_Screen3");
                //return RedirectToAction("PracticeAssessment_Screen3", new { PatientID = model.PatientID, PatientNum = model.PatientNum, IsReadOnly = model.IsReadOnly });
            }

            Write(model.PatientID, model.PatientNum, model.IsReadOnly);

            return View(model);
        }


        [Authorize]
        public ActionResult PracticeAssessment_Screen3()
        {
            PracticeAssessment_P3 model = new PracticeAssessment_P3();
            //model.PatientID = PatientID;
            //model.PatientNum = PatientNum;
            //model.IsReadOnly = IsReadOnly;


            model.PatientID = Int32.Parse(TempData[Constants.PatientID].ToString());
            model.PatientNum = Int32.Parse(TempData[Constants.PatientNum].ToString());
            model.IsReadOnly = bool.Parse(TempData[Constants.IsReadOnly].ToString());

            var row = Entites.sp_Get_PA_PhysicalAssessment(model.PatientID).SingleOrDefault();
            if (row != null)
            {

                model.PatientID = row.PatientID.Value;
                model.SmokingHistory = row.SmokingHistory;
                model.CessationPlan = row.CessationPlan;
                model.AlcoholIntake = row.AlcoholIntake;

                model.CoMorbid_eGFR4559 = row.MICROVASCULAR_e45_59.Value;
                model.CoMorbid_eGFR3044 = row.MICROVASCULAR_e30_44.Value;
                model.CoMorbid_eGFRlessthan30 = row.MICROVASCULAR_e_30.Value;
                model.CoMorbid_Microalbuminuria = row.MICROVASCULAR_Microalbuminuria.Value;
                model.CoMorbid_Macroalbuminuria = row.MICROVASCULAR_Macroalbuminuria.Value;
                model.CoMorbid_Retinopathy = row.MICROVASCULAR_Retinopathy.Value;
                model.CoMorbid_Neuropathy = row.MICROVASCULAR_Neuropathy.Value;

                model.CoMorbid_CoronaryArtery = row.MACROVASCULAR_CoronaryArteryDisease.Value;
                model.CoMorbid_Cerebrovascular = row.MACROVASCULAR_CerebrovascularDisease.Value;
                model.CoMorbid_AbdominalAortic = row.MACROVASCULAR_AbdominalAorticAneurysm.Value;
                model.CoMorbid_PeripheralArterial = row.MACROVASCULAR_PeripheralArterialDisease.Value;

                model.CoMorbid_NonAlcoholicfattyliver = row.LIVERDISEASE_NonAlcoholic.Value;
                model.CoMorbid_NonAlcoholicSteatohepatitis = row.LIVERDISEASE_Steatohepatitis.Value;
                model.CoMorbid_Cirrhosis = row.LIVERDISEASE_Cirrhosis.Value;
                model.CoMorbid_Other = row.LIVERDISEASE_Other.Value;

                model.CoMorbid_CVdisease = row.OTHER_Premature.Value;
                model.CoMorbid_ModifiedFramingham = row.OTHER_Framingham.Value;
                model.CoMorbid_Overweight = row.OTHER_Overweight.Value;
                model.CoMorbid_HighriskHypertension = row.OTHER_Hypertension.Value;
                model.CoMorbid_Dyslipidemia = row.OTHER_Dyslipidemia.Value;
                model.CoMorbid_AtrialFibrillation = row.OTHER_Fibrillation.Value;
                model.CoMorbid_CongestiveHeartFailure = row.OTHER_CongestiveHearthFailure.Value;
                model.CoMorbid_Depression = row.OTHER_Depression.Value;
                model.CoMorbid_CognitiveImpairment = row.OTHER_CognitiveImpairment.Value;
                model.CoMorbid_ErectileDysfunction = row.OTHER_ErectileDysfunction.Value;
                model.CoMorbid_PolycysticOvary = row.OTHER_PolycysticOvarySyndrome.Value;
                model.CoMorbid_Infertility = row.OTHER_Infertility.Value;
                model.CoMorbid_SleepApnea = row.OTHER_SleepApnea.Value;
                model.CoMorbid_ThyroidDisease = row.OTHER_ThyroidDisease.Value;
                model.CoMorbid_Malignancy = row.OTHER_Malignancy.Value;
                model.CoMorbid_None = row.OTHER_None.Value;

                if (row.HeartRate.HasValue)
                {
                    model.HeartRate = row.HeartRate.Value;
                    model.NA_HearRate = false;
                }
                else
                {
                    model.NA_HearRate = true;
                }

                model.Height = row.Height.HasValue ? row.Height.Value : 0;
                model.HeightCM = row.HeightInCm.Value;
                model.HeightIn = !model.HeightCM;

                model.Weight = row.Weight.HasValue ? row.Weight.Value : 0;
                model.WeightKg = row.WeightInKg.Value;
                model.WeightLB = !model.WeightKg;

                model.WaistCM = row.WaistInCm.HasValue ? row.WaistInCm.Value : false;
                model.WaistIn = !model.WaistCM;

                if (row.Waist.HasValue)
                {
                    model.Waist = row.Waist.HasValue ? row.Waist.Value : 0;
                    model.NA_Waist = false;
                }
                else
                {
                    model.NA_Waist = true;

                    model.WaistCM = false;
                    model.WaistIn = false;

                }
            }

            Write(model.PatientID, model.PatientNum, model.IsReadOnly);

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult PracticeAssessment_Screen3(PracticeAssessment_P3 model)
        {

            if (model.IsReadOnly)
                return RedirectToAction("PracticeAssessment_Screen4", new { PatientID = model.PatientID, PatientNum = model.PatientNum, IsReadOnly = model.IsReadOnly });

            if (!model.CoMorbid_None)
            {


                if (
                      !model.CoMorbid_eGFR4559 &&
                      !model.CoMorbid_eGFR3044 &&
                      !model.CoMorbid_eGFRlessthan30 &&
                      !model.CoMorbid_Microalbuminuria &&
                      !model.CoMorbid_Macroalbuminuria &&
                      !model.CoMorbid_Retinopathy &&
                      !model.CoMorbid_Neuropathy &&

                     !model.CoMorbid_CoronaryArtery &&
                     !model.CoMorbid_Cerebrovascular &&
                     !model.CoMorbid_AbdominalAortic &&
                     !model.CoMorbid_PeripheralArterial &&

                     !model.CoMorbid_NonAlcoholicfattyliver &&
                     !model.CoMorbid_NonAlcoholicSteatohepatitis &&
                     !model.CoMorbid_Cirrhosis &&
                     !model.CoMorbid_Other &&

                     !model.CoMorbid_CVdisease &&
                     !model.CoMorbid_ModifiedFramingham &&
                     !model.CoMorbid_Overweight &&
                     !model.CoMorbid_HighriskHypertension &&
                     !model.CoMorbid_Dyslipidemia &&
                     !model.CoMorbid_AtrialFibrillation &&
                     !model.CoMorbid_CongestiveHeartFailure &&
                     !model.CoMorbid_Depression &&
                     !model.CoMorbid_CognitiveImpairment &&

                     !model.CoMorbid_ErectileDysfunction &&
                     !model.CoMorbid_PolycysticOvary &&
                     !model.CoMorbid_Infertility &&
                     !model.CoMorbid_SleepApnea &&
                     !model.CoMorbid_ThyroidDisease &&
                     !model.CoMorbid_Malignancy
                  )
                {
                    ModelState.AddModelError("COMORBID", "*");
                }




                //if (
                //      !model.CoMorbid_eGFR4559 &&
                //      !model.CoMorbid_eGFR3044 &&
                //      !model.CoMorbid_eGFRlessthan30 &&
                //      !model.CoMorbid_Microalbuminuria &&
                //      !model.CoMorbid_Macroalbuminuria &&
                //      !model.CoMorbid_Retinopathy &&
                //      !model.CoMorbid_Neuropathy
                //   )
                //{
                //    ModelState.AddModelError("COMORBID_1", "*");
                //}


                //if (
                //     !model.CoMorbid_CoronaryArtery &&
                //     !model.CoMorbid_Cerebrovascular &&
                //     !model.CoMorbid_AbdominalAortic &&
                //     !model.CoMorbid_PeripheralArterial
                //  )
                //{
                //    ModelState.AddModelError("COMORBID_2", "*");
                //}

                //if (
                //     !model.CoMorbid_NonAlcoholicfattyliver &&
                //     !model.CoMorbid_NonAlcoholicSteatohepatitis &&
                //     !model.CoMorbid_Cirrhosis &&
                //     !model.CoMorbid_Other
                //  )
                //{
                //    ModelState.AddModelError("COMORBID_3", "*");
                //}


                //if (
                //     !model.CoMorbid_CVdisease &&
                //     !model.CoMorbid_ModifiedFramingham &&
                //     !model.CoMorbid_Overweight &&
                //     !model.CoMorbid_HighriskHypertension &&
                //     !model.CoMorbid_Dyslipidemia &&
                //     !model.CoMorbid_AtrialFibrillation &&
                //     !model.CoMorbid_CongestiveHeartFailure &&
                //     !model.CoMorbid_Depression &&
                //     !model.CoMorbid_CognitiveImpairment &&

                //     !model.CoMorbid_ErectileDysfunction &&
                //     !model.CoMorbid_PolycysticOvary &&
                //     !model.CoMorbid_Infertility &&
                //     !model.CoMorbid_SleepApnea &&
                //     !model.CoMorbid_ThyroidDisease &&
                //     !model.CoMorbid_Malignancy
                //  )
                //{
                //    ModelState.AddModelError("COMORBID_4", "*");
                //}

            }

            if (!model.NA_HearRate && !model.HeartRate.HasValue)
            {
                ModelState.AddModelError("HEART_RATE", "*");
            }


            if (model.HeartRate.HasValue && (model.HeartRate.Value < 50 || model.HeartRate.Value > 200))
            {
                ModelState.AddModelError("HEART_RATE_RANGE", Resources.Resource.Range_50_200_HR);
            }


            if (!model.Height.HasValue || (!model.HeightCM && !model.HeightIn))
            {
                ModelState.AddModelError("HEIGHT", "*");
            }

            if (!model.Weight.HasValue || (!model.WeightKg && !model.WeightLB))
            {
                ModelState.AddModelError("WEIGHT", "*");
            }


            if (model.WeightKg)
            {
                if (model.Weight < 30 || model.Weight > 300)
                    ModelState.AddModelError("WEIGHT_KG", Resources.Resource.Range_30_300_KG);
            }
            else
                if (model.WeightLB)
                {
                    if (model.Weight < 66 || model.Weight > 660)
                        ModelState.AddModelError("WEIGHT_LB", Resources.Resource.Range_66_660_LB);
                }


            if (model.HeightCM)
            {
                if (model.Height < 100 || model.Height > 230)
                    ModelState.AddModelError("HEIGHT_CM", Resources.Resource.Range_100_230_CM);
            }
            else
                if (model.HeightIn)
                {
                    if (model.Height < 39 || model.Height > 90)
                        ModelState.AddModelError("HEIGHT_IN", Resources.Resource.Range_39_90_IN);
                }



            if (model.NA_Waist)
            {

            }
            else
            {
                if (!model.Waist.HasValue || (!model.WaistCM && !model.WaistIn))
                {
                    ModelState.AddModelError("WAIST", "*");
                }

                if (model.Waist.HasValue)
                {
                    if (model.WaistIn)
                    {
                        if (model.Waist < 22 || model.Waist > 55)
                            ModelState.AddModelError("WAIST_RANGE", Resources.Resource.Range_22_55_IN);
                    }
                    else
                        if (model.WaistCM)
                        {
                            if (model.Waist < 60 || model.Waist > 150)
                                ModelState.AddModelError("WAIST_RANGE", Resources.Resource.Range_60_150_CM);
                        }
                }

            }

            if (model.SmokingHistory == "Current Smoker")
            {
                if (string.IsNullOrEmpty(model.CessationPlan))
                    ModelState.AddModelError("CessationPlanError", "*");
            }


            if (ModelState.IsValid)
            {
                Entites.sp_Set_PA_PhysicalAssessment(

                                    model.PatientID,
                                    model.SmokingHistory,
                                    model.CessationPlan,
                                    model.AlcoholIntake,

                                    model.CoMorbid_eGFR4559,
                                    model.CoMorbid_eGFR3044,
                                    model.CoMorbid_eGFRlessthan30,
                                    model.CoMorbid_Microalbuminuria,
                                    model.CoMorbid_Macroalbuminuria,
                                    model.CoMorbid_Retinopathy,
                                    model.CoMorbid_Neuropathy,

                                    model.CoMorbid_CoronaryArtery,
                                    model.CoMorbid_Cerebrovascular,
                                    model.CoMorbid_AbdominalAortic,
                                    model.CoMorbid_PeripheralArterial,

                                    model.CoMorbid_NonAlcoholicfattyliver,
                                    model.CoMorbid_NonAlcoholicSteatohepatitis,
                                    model.CoMorbid_Cirrhosis,
                                    model.CoMorbid_Other,

                                    model.CoMorbid_CVdisease,
                                    model.CoMorbid_ModifiedFramingham,
                                    model.CoMorbid_Overweight,
                                    model.CoMorbid_HighriskHypertension,
                                    model.CoMorbid_Dyslipidemia,
                                    model.CoMorbid_AtrialFibrillation,
                                    model.CoMorbid_CongestiveHeartFailure,
                                    model.CoMorbid_Depression,
                                    model.CoMorbid_CognitiveImpairment,
                                    model.CoMorbid_ErectileDysfunction,
                                    model.CoMorbid_PolycysticOvary,
                                    model.CoMorbid_Infertility,
                                    model.CoMorbid_SleepApnea,
                                    model.CoMorbid_ThyroidDisease,
                                    model.CoMorbid_Malignancy,
                                    model.CoMorbid_None,

                                       model.HeartRate,
                                       model.Height,
                                       model.Weight,
                                       model.Waist,

                                       model.HeightCM,
                                       model.WeightKg,
                                       model.WaistCM


                );

                return RedirectToAction("PracticeAssessment_Screen4");
                //return RedirectToAction("PracticeAssessment_Screen4", new { PatientID = model.PatientID, PatientNum = model.PatientNum, IsReadOnly = model.IsReadOnly });
            }

            //        var errors = ModelState
            //.Where(x => x.Value.Errors.Count > 0)
            //.Select(x => new { x.Key, x.Value.Errors })
            //.ToArray();

            Write(model.PatientID, model.PatientNum, model.IsReadOnly);


            return View(model);
        }

        [Authorize]
        public ActionResult PracticeAssessment_Screen4()
        {

            PracticeAssessment_P4 model = new PracticeAssessment_P4();
            //model.PatientID = PatientID;
            //model.PatientNum = PatientNum;
            //model.IsReadOnly = IsReadOnly;


            model.PatientID = Int32.Parse(TempData[Constants.PatientID].ToString());
            model.PatientNum = Int32.Parse(TempData[Constants.PatientNum].ToString());
            model.IsReadOnly = bool.Parse(TempData[Constants.IsReadOnly].ToString());

            var row = Entites.sp_Get_PA_BP(model.PatientID).SingleOrDefault();

            if (row != null)
            {

                model.PatientID = row.PatientID.Value;
                model.TragetSystolicBP = row.SystolicBP_Target;
                model.TragetDiastolicBP = row.DiastolicBP_Target;
                model.SystolicBP_lastVist = row.LastVisit_Sys;
                model.DiastolicBP_lastVist = row.LastVisit_Dys;
                model.BPTherapy_Alphablocker = row.BP_Therapy_Alpha.Value;
                model.BPTherapy_ACEInhibitor = row.BP_Therapy_ACE.Value;
                model.BPTherapy_ARB = row.BP_Therapy_ARB.Value;
                model.BPTherapy_BetaBlocker = row.BP_Therapy_Beta.Value;
                model.BPTherapy_CCB = row.BP_Therapy_Calcium.Value;
                model.BPTherapy_Diuretic = row.BP_Therapy_Diuretic.Value;
                model.ACE_Diuretic = row.CombinationTherapy_ACE_Diuretic.Value;
                model.ARB_Diuretic = row.CombinationTherapy_ARB_Diuretic.Value;
                model.BB_Diuretic = row.CombinationTherapy_BB_Diuretic.Value;
                model.CCB_ARB = row.CombinationTherapy_CCB_ARB.Value;
                model.NoneofAbove = row.CombinationTherapy_None.Value;

            }

            Write(model.PatientID, model.PatientNum, model.IsReadOnly);

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult PracticeAssessment_Screen4(PracticeAssessment_P4 model)
        {

            if (model.IsReadOnly)
                return RedirectToAction("PracticeAssessment_Screen5", new { PatientID = model.PatientID, PatientNum = model.PatientNum, IsReadOnly = model.IsReadOnly });

            if (!model.NoneofAbove)
            {

                if (
                               !model.BPTherapy_Alphablocker &&
                               !model.BPTherapy_ACEInhibitor &&
                               !model.BPTherapy_ARB &&
                               !model.BPTherapy_BetaBlocker &&
                               !model.BPTherapy_CCB &&
                               !model.BPTherapy_Diuretic &&
                               !model.ACE_Diuretic &&
                              !model.ARB_Diuretic &&
                              !model.BB_Diuretic &&
                              !model.CCB_ARB
                            )
                {
                    ModelState.AddModelError("SECTION_1", "*");
                }

            }


            if (model.DiastolicBP_lastVist.Value < 30 || model.DiastolicBP_lastVist.Value > 150)
            {
                ModelState.AddModelError("Dystolic", Resources.Resource.Range_30_150);
            }

            if (model.SystolicBP_lastVist.Value < 60 || model.SystolicBP_lastVist.Value > 250)
            {
                ModelState.AddModelError("Systolic", Resources.Resource.Range_60_250);
            }

            if (model.DiastolicBP_lastVist.Value > model.SystolicBP_lastVist.Value)
            {
                ModelState.AddModelError("DYSTOLIC_GREATER", Resources.Resource.DISTOLIC_SYSTOLIC);
            }

            //if (
            //                !model.BPTherapy_Alphablocker &&
            //                !model.BPTherapy_ACEInhibitor &&
            //                !model.BPTherapy_ARB &&
            //                !model.BPTherapy_BetaBlocker &&
            //                !model.BPTherapy_CCB &&
            //                !model.BPTherapy_Diuretic
            //             )
            //{
            //    ModelState.AddModelError("SECTION_1", "*");
            //}

            //if (
            //               !model.ACE_Diuretic &&
            //               !model.ARB_Diuretic &&
            //               !model.BB_Diuretic &&
            //               !model.CCB_ARB
            //            )
            //{
            //    ModelState.AddModelError("SECTION_2", "*");
            //}



            if (ModelState.IsValid)
            {
                Entites.sp_Set_PA_BP
                                   (
                                       model.PatientID,
                                       model.TragetSystolicBP,
                                       model.TragetDiastolicBP,
                                       model.SystolicBP_lastVist,
                                       model.DiastolicBP_lastVist,
                                       model.BPTherapy_Alphablocker,
                                       model.BPTherapy_ACEInhibitor,
                                       model.BPTherapy_ARB,
                                       model.BPTherapy_BetaBlocker,
                                       model.BPTherapy_CCB,
                                       model.BPTherapy_Diuretic,
                                       model.ACE_Diuretic,
                                       model.ARB_Diuretic,
                                       model.BB_Diuretic,
                                       model.CCB_ARB,
                                       model.NoneofAbove
                               );


                return RedirectToAction("PracticeAssessment_Screen5");
                //return RedirectToAction("PracticeAssessment_Screen5", new { PatientID = model.PatientID, PatientNum = model.PatientNum, IsReadOnly = model.IsReadOnly });
            }

            Write(model.PatientID, model.PatientNum, model.IsReadOnly);

            return View(model);
        }

        [Authorize]
        public ActionResult PracticeAssessment_Screen5()
        {
            PracticeAssessment_P5 model = new PracticeAssessment_P5();
            //model.PatientID = PatientID;
            //model.PatientNum = PatientNum;
            //model.IsReadOnly = IsReadOnly;

            model.PatientID = Int32.Parse(TempData[Constants.PatientID].ToString());
            model.PatientNum = Int32.Parse(TempData[Constants.PatientNum].ToString());
            model.IsReadOnly = bool.Parse(TempData[Constants.IsReadOnly].ToString());


            var row = Entites.sp_Get_PA_Lipid(model.PatientID).SingleOrDefault();

            if (row != null)
            {
                model.LDLC_Target = row.LDL_C_Target;
                model.LipidLevelsChecked = row.LipidLevelsChecked.Value;
                model.TotalCholesterol = row.TotalCholesterol.Value;
                model.LDLC = row.LDL_C.Value;
                model.HDLC = row.HDL_C.Value;
                model.NonHDLC = row.Non_HDL_C.Value;
                model.Triglycerides = row.Triglycerides.Value;
                model.Statin = row.LipidModifyingTherapy_Statin.Value;
                model.BileAcid = row.LipidModifyingTherapy_BileAcidSequestrant.Value;
                model.Ezetimibe = row.LipidModifyingTherapy_Ezetimibe.Value;
                model.Fibrate = row.LipidModifyingTherapy_Fibrate.Value;
                model.Niacin = row.LipidModifyingTherapy_Niacin.Value;
                model.PCSK9Inhibitor = row.LipidModifyingTherapy_PCSK9.Value;
                model.NoneofAbove = row.LipidModifyingTherapy_NONE.Value;
            }

            Write(model.PatientID, model.PatientNum, model.IsReadOnly);

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult PracticeAssessment_Screen5(PracticeAssessment_P5 model)
        {

            if (model.IsReadOnly)
                return RedirectToAction("PracticeAssessment_Screen6", new { PatientID = model.PatientID, PatientNum = model.PatientNum, IsReadOnly = model.IsReadOnly });


            var choles_LB = 1.0M;
            var choles_UB = 10.0M;

            var ldlc_LB = 1.0M;
            var ldlc_UB = 10.0M;

            var hdlc_LB = 0.1M;
            var hdlc_UB = 5.0M;

            var try_LB = 0.1M;
            var try_UB = 10.0M;

            if (!model.NoneofAbove)
            {

                if (
                       !model.Statin &&
                       !model.BileAcid &&
                       !model.Ezetimibe &&
                       !model.Fibrate &&
                       !model.Niacin &&
                       !model.PCSK9Inhibitor
                   )
                {
                    ModelState.AddModelError("SECTION_1", "*");
                }
            }


            if (model.TotalCholesterol.Value < choles_LB || model.TotalCholesterol.Value > choles_UB)
            {
                ModelState.AddModelError("CHOLES_RANGE", Resources.Resource.Range_1_10_CL);
            }

            if (model.LDLC.Value < ldlc_LB || model.LDLC.Value > ldlc_UB)
            {
                ModelState.AddModelError("LDLC_RANGE", Resources.Resource.Range_1_10_LDLC);
            }

            if (model.HDLC.Value < hdlc_LB || model.HDLC.Value > hdlc_UB)
            {
                ModelState.AddModelError("HDLC_RANGE", Resources.Resource.Range_1_5_HDLC);
            }

            if (model.Triglycerides.Value < try_LB || model.Triglycerides.Value > try_UB)
            {
                ModelState.AddModelError("TRI_RANGE", Resources.Resource.Range_1_10_TRY);
            }

            if (ModelState.IsValid)
            {
                Entites.sp_Set_PA_Lipid
                                        (
                                            model.PatientID,
                                            model.LDLC_Target,
                                            model.LipidLevelsChecked,
                                            model.TotalCholesterol,
                                            model.LDLC,
                                            model.HDLC,
                                            model.NonHDLC,
                                            model.Triglycerides,
                                            model.Statin,
                                            model.BileAcid,
                                            model.Ezetimibe,
                                            model.Fibrate,
                                            model.Niacin,
                                            model.PCSK9Inhibitor,
                                            model.NoneofAbove
                                    );


                return RedirectToAction("PracticeAssessment_Screen6");
                //return RedirectToAction("PracticeAssessment_Screen6", new { PatientID = model.PatientID, PatientNum = model.PatientNum, IsReadOnly = model.IsReadOnly });
            }

            Write(model.PatientID, model.PatientNum, model.IsReadOnly);

            return View(model);
        }

        [Authorize]
        public ActionResult PracticeAssessment_Screen6()
        {

            PracticeAssessment_P6 model = new PracticeAssessment_P6();
            //model.PatientID = PatientID;
            //model.PatientNum = PatientNum;
            //model.IsReadOnly = IsReadOnly;

            model.PatientID = Int32.Parse(TempData[Constants.PatientID].ToString());
            model.PatientNum = Int32.Parse(TempData[Constants.PatientNum].ToString());
            model.IsReadOnly = bool.Parse(TempData[Constants.IsReadOnly].ToString());

            var row = Entites.sp_Get_PA_Glycemic(model.PatientID).SingleOrDefault();

            if (row != null)
            {
                model.A1C_Target = row.A1C_Target;
                model.A1C_Limited = row.A1C_Limited.Value;
                model.A1C_FunctionalDependancy = row.A1C_FunctionalDependancy.Value;
                model.A1C_ExtensiveCoronary = row.A1C_ExtensiveCoronary.Value;
                model.A1C_MultipleMorbidities = row.A1C_MultipleMorbidities.Value;
                model.A1C_Hypoglycemia = row.A1C_Hypoglycemia.Value;
                model.A1C_HypoglycemiaUnawareness = row.A1C_HypoglycemiaUnawareness.Value;
                model.A1C_Diabetes = row.A1C_Diabetes.Value;
                model.A1C_ClinicalJudgement = row.A1C_ClinicalJudgement.Value;
                model.A1C_NONE = row.A1C_NONE.Value;
                model.A1C_Checked = row.A1C_Checked.Value;
                model.A1C = row.A1C ?? new decimal?();
                model.FPG = row.FPG ?? new decimal?();
                model.FPG_NA = !model.FPG.HasValue;
                model.Patient_Counselled = row.Patient_Counselled;
                model.Patient_DietPlan = row.Patient_DietPlan;
                model.PhysicalActivity = row.PhysicalActivity;
                model.WrittenExercisePlan = row.WrittenExercisePlan;
                model.ComprehensiveFootExam = row.ComprehensiveFootExam;
                model.FootExamFinding = row.FootExamFinding;
                model.EyeExam = row.EyeExam;
                model.EyeExamFinding = row.EyeExamFinding;
                model.SMBG = row.SMBG;
                model.SMBGResults = row.SMBGResults;
                model.Antihyperglycemic_Glucosidase = row.Antihyperglycemic_Glucosidase.Value;
                model.Antihyperglycemic_DPP4 = row.Antihyperglycemic_DPP_4.Value;
                model.Antihyperglycemic_GLP1 = row.Antihyperglycemic_GLP_1.Value;
                model.Antihyperglycemic_Insulin = row.Antihyperglycemic_Insulin.Value;
                model.Antihyperglycemic_Meglitinide = row.Antihyperglycemic_Meglitinide.Value;
                model.Antihyperglycemic_Metformin = row.Antihyperglycemic_Metformin.Value;
                model.Antihyperglycemic_Metformin_DPP4 = row.Antihyperglycemic_Metformin_DPP4_FDC.Value;
                model.Antihyperglycemic_SGLT2 = row.Antihyperglycemic_SGLT2.Value;
                model.Antihyperglycemic_Sulfonylurea = row.Antihyperglycemic_Sulfonylurea.Value;
                model.Antihyperglycemic_Thiazolidinedione = row.Antihyperglycemic_Thiazolidinedione.Value;
                model.Antihyperglycemic_None = row.Antihyperglycemic_None.Value;
                model.InsulinRegimen = row.InsulinRegimen;
                model.SickDayInstructions = row.SickDayInstructions;
                model.Hypoglycemia_PatientReported = row.Hypoglycemia_PatientReported.Value;
                model.Hypoglycemia_Evidence = row.Hypoglycemia_Evidence.Value;
                model.Hypoglycemia_Paramedic = row.Hypoglycemia_Paramedic.Value;
                model.Hypoglycemia_NoDiscussion = row.Hypoglycemia_NoDiscussion.Value;
                model.Hypoglycemia_Adjusted = row.Hypoglycemia_Adjusted.Value;
                model.Hypoglycemia_Exercise = row.Hypoglycemia_Exercise.Value;
                model.Hypoglycemia_NutritionTherapy = row.Hypoglycemia_NutritionTherapy.Value;
                model.Hypoglycemia_ManagementPlan = row.Hypoglycemia_ManagementPlan.Value;
                model.Hypoglycemia_NoActionTaken = row.Hypoglycemia_NoActionTaken.Value;
                model.Hypoglycemia_Inquire = row.Hypoglycemia_Inquired.HasValue ? row.Hypoglycemia_Inquired.Value : false;
            }

            Write(model.PatientID, model.PatientNum, model.IsReadOnly);

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult PracticeAssessment_Screen6(PracticeAssessment_P6 model)
        {

            if (model.IsReadOnly)
                return RedirectToAction("PracticeAssessment_Screen7", new { PatientID = model.PatientID, PatientNum = model.PatientNum, IsReadOnly = model.IsReadOnly });

            var a1c_LB = 5.0M;
            var a1c_UB = 12.0M;

            var glu_LB = 3.0M;
            var glu_UB = 12.0M;


            if (
                    model.A1C_Target == "7.5%" ||
                    model.A1C_Target == "8.0%" ||
                    model.A1C_Target == "7.1 to 8.5 %"
                )
            {
                if (!model.A1C_NONE)
                {

                    if (
                           !model.A1C_Limited &&
                           !model.A1C_FunctionalDependancy &&
                           !model.A1C_ExtensiveCoronary &&
                           !model.A1C_MultipleMorbidities &&
                           !model.A1C_Hypoglycemia &&
                           !model.A1C_HypoglycemiaUnawareness &&
                           !model.A1C_Diabetes &&
                           !model.A1C_ClinicalJudgement
                       )
                    {
                        ModelState.AddModelError("SECTION_1", "*");
                    }
                }
            }


            //if (!model.Antihyperglycemic_None)
            //{

                if (
                       !model.Antihyperglycemic_Glucosidase &&
                       !model.Antihyperglycemic_DPP4 &&
                       !model.Antihyperglycemic_GLP1 &&
                       !model.Antihyperglycemic_Insulin &&
                       !model.Antihyperglycemic_Meglitinide &&
                       !model.Antihyperglycemic_Metformin &&
                       !model.Antihyperglycemic_Metformin_DPP4 &&
                       !model.Antihyperglycemic_SGLT2 &&
                       !model.Antihyperglycemic_Sulfonylurea &&
                       !model.Antihyperglycemic_Thiazolidinedione
                   )
                {
                    ModelState.AddModelError("SECTION_2", "*");
                }
            //}


            if (!model.Hypoglycemia_NoDiscussion)
            {

                if (
                       !model.Hypoglycemia_Inquire         &&
                       !model.Hypoglycemia_PatientReported &&
                       !model.Hypoglycemia_Evidence        &&
                       !model.Hypoglycemia_Paramedic

                   )
                {
                    ModelState.AddModelError("SECTION_3", "*");
                }
            }


            //if (!model.Hypoglycemia_NoActionTaken)
            //{

            //    if (
            //           !model.Hypoglycemia_Adjusted &&
            //           !model.Hypoglycemia_Exercise &&
            //           !model.Hypoglycemia_NutritionTherapy &&
            //           !model.Hypoglycemia_ManagementPlan
            //       )
            //    {
            //        ModelState.AddModelError("SECTION_4", "*");
            //    }
            //}

            if (!model.FPG_NA)
            {
                if (!(model.FPG.HasValue))
                    ModelState.AddModelError("FPG", "*");
            }

            if (model.ComprehensiveFootExam == "Yes")
            {
                if (string.IsNullOrEmpty(model.FootExamFinding))
                    ModelState.AddModelError("FootExamFinding", "*");
            }


            if (model.EyeExam == "Yes")
            {
                if (string.IsNullOrEmpty(model.EyeExamFinding))
                    ModelState.AddModelError("EyeExamFinding", "*");
            }

            if (model.SMBG == "Yes")
            {
                if (string.IsNullOrEmpty(model.SMBGResults))
                    ModelState.AddModelError("SMBGResults", "*");
            }

            if (model.Antihyperglycemic_Insulin)
            {
                if (string.IsNullOrEmpty(model.InsulinRegimen))
                {
                    ModelState.AddModelError("InsulinRegimen", "*");
                }

                if (string.IsNullOrEmpty(model.SickDayInstructions))
                {
                    ModelState.AddModelError("SickDayInstructions", "*");
                }

            }


            if (model.A1C < a1c_LB || model.A1C > a1c_UB)
            {
                ModelState.AddModelError("A1C_Range", Resources.Resource.Range_5_12_A1C);
            }

            if (!model.FPG_NA)
            {
                if (model.FPG < glu_LB || model.A1C > glu_UB)
                {
                    ModelState.AddModelError("FPG_Range", Resources.Resource.Range_3_12_GLU);
                }
            }

            if (
                   model.Hypoglycemia_PatientReported ||
                   model.Hypoglycemia_Evidence ||
                   model.Hypoglycemia_Paramedic
                 )
            {
                if (!model.Hypoglycemia_Adjusted &&
                     !model.Hypoglycemia_Exercise &&
                     !model.Hypoglycemia_NutritionTherapy &&
                     !model.Hypoglycemia_ManagementPlan &&
                     !model.Hypoglycemia_NoActionTaken
                 )
                {

                    ModelState.AddModelError("Hypoglycemia", "*");
                }
            }

            if (ModelState.IsValid)
            {

                Entites.sp_Set_PA_Glycemic
                    (

                                        model.PatientID,
                                        model.A1C_Target,
                                        model.A1C_Limited,
                                        model.A1C_FunctionalDependancy,
                                        model.A1C_ExtensiveCoronary,
                                        model.A1C_MultipleMorbidities,
                                        model.A1C_Hypoglycemia,
                                        model.A1C_HypoglycemiaUnawareness,
                                        model.A1C_Diabetes,
                                        model.A1C_ClinicalJudgement,
                                        model.A1C_NONE,
                                        model.A1C_Checked,
                                        model.A1C,
                                        model.FPG,
                                        model.Patient_Counselled,
                                        model.Patient_DietPlan,
                                        model.PhysicalActivity,
                                        model.WrittenExercisePlan,
                                        model.ComprehensiveFootExam,
                                        model.FootExamFinding,
                                        model.EyeExam,
                                        model.EyeExamFinding,
                                        model.SMBG,
                                        model.SMBGResults,
                                        model.Antihyperglycemic_Glucosidase,
                                        model.Antihyperglycemic_DPP4,
                                        model.Antihyperglycemic_GLP1,
                                        model.Antihyperglycemic_Insulin,
                                        model.Antihyperglycemic_Meglitinide,
                                        model.Antihyperglycemic_Metformin,
                                        model.Antihyperglycemic_Metformin_DPP4,
                                        model.Antihyperglycemic_SGLT2,
                                        model.Antihyperglycemic_Sulfonylurea,
                                        model.Antihyperglycemic_Thiazolidinedione,
                                        model.Antihyperglycemic_None,
                                        model.InsulinRegimen,
                                        model.SickDayInstructions,
                                        model.Hypoglycemia_PatientReported,
                                        model.Hypoglycemia_Evidence,
                                        model.Hypoglycemia_Paramedic,
                                        model.Hypoglycemia_NoDiscussion,
                                        model.Hypoglycemia_Adjusted,
                                        model.Hypoglycemia_Exercise,
                                        model.Hypoglycemia_NutritionTherapy,
                                        model.Hypoglycemia_ManagementPlan,
                                        model.Hypoglycemia_NoActionTaken,
                                        model.Hypoglycemia_Inquire

                                );

                return RedirectToAction("PracticeAssessment_Screen7");
                //return RedirectToAction("PracticeAssessment_Screen7", new { PatientID = model.PatientID, PatientNum = model.PatientNum, IsReadOnly = model.IsReadOnly });
            }

            Write(model.PatientID, model.PatientNum, model.IsReadOnly);

            return View(model);
        }


        public ActionResult PracticeAssessment_Screen7()
        {
            PracticeAssessment_P7 model = new PracticeAssessment_P7();
            //model.PatientID = PatientID;
            //model.PatientNum = PatientNum;
            //model.IsReadOnly = IsReadOnly;
            model.Completed = false;

            model.PatientID = Int32.Parse(TempData[Constants.PatientID].ToString());
            model.PatientNum = Int32.Parse(TempData[Constants.PatientNum].ToString());
            model.IsReadOnly = bool.Parse(TempData[Constants.IsReadOnly].ToString());

            var row = Entites.sp_Get_PA_Lab(model.PatientID).SingleOrDefault();

            if (row != null)
            {
                model.Creatinine = row.Creatinine ?? new decimal?();
                model.Creatinine_NA = !model.Creatinine.HasValue;

                model.eGFR = row.e_GFR ?? new decimal?();
                model.eGFR_NA = !model.eGFR.HasValue;

                model.ACR = row.ACR ?? new decimal?();
                
                if (  row.Normal_ACR.HasValue && ! row.Normal_ACR.Value )
                    model.ACR_NA = !model.ACR.HasValue;

                model.OtherMedications_Antidepressant = row.OtherMedications_Antidepressant.Value;
                model.OtherMedications_ASA = row.OtherMedications_ASA.Value;
                model.OtherMedications_Antiplatelet = row.OtherMedications_Antiplatelet.Value;
                model.OtherMedications_Erectile = row.OtherMedications_Erectile.Value;
                model.OtherMedications_NSAID = row.OtherMedications_NSAID.Value;
                model.OtherMedications_PPI = row.OtherMedications_PPI.Value;
                model.OtherMedications_Cessation = row.OtherMedications_Cessation.Value;
                model.OtherMedications_Vitamins = row.OtherMedications_Vitamins.Value;
                model.OtherMedications_Warfarin = row.OtherMedications_Warfarin.Value;
                model.OtherMedications_Anticoagulant = row.OtherMedications_Anticoagulant.Value;
                model.OtherMedications_NONE = row.OtherMedications_NONE.Value;
                model.Normal_AC =  row.Normal_ACR.HasValue ? row.Normal_ACR.Value : false;

                if (!model.IsReadOnly)
                    model.Completed = true;

            }

            Write(model.PatientID, model.PatientNum, model.IsReadOnly);

            return View(model);
        }

        [HttpPost]
        public ActionResult PracticeAssessment_Screen7(PracticeAssessment_P7 model)
        {

            if (model.IsReadOnly)
                return RedirectToAction("PracticeAssessment");


            var cret_LB = 5.0M;
            var cret_UB = 1500.0M;

            var eGFR_LB = 29.0M;
            var eGFR_UB = 150.0M;

            var ACR_LB = 1.0M;
            var ACR_UB = 50.0M;

            if (!model.OtherMedications_NONE)
            {

                if (
                        !model.OtherMedications_Antidepressant &&
                        !model.OtherMedications_ASA &&
                        !model.OtherMedications_Antiplatelet &&
                        !model.OtherMedications_Erectile &&
                        !model.OtherMedications_NSAID &&
                        !model.OtherMedications_PPI &&
                        !model.OtherMedications_Cessation &&
                        !model.OtherMedications_Vitamins &&
                        !model.OtherMedications_Warfarin &&
                        !model.OtherMedications_Anticoagulant
                   )
                {
                    ModelState.AddModelError("SECTION_1", "*");
                }
            }

            if (!model.Creatinine_NA)
            {
                if (!model.Creatinine.HasValue)
                    ModelState.AddModelError("Creatinine", "*");

                if (model.Creatinine < cret_LB || model.Creatinine > cret_UB)
                {
                    ModelState.AddModelError("Creatinine_RANGE", Resources.Resource.Range_5_1500_Cret);
                }
            }

            if (!model.eGFR_NA)
            {
                if (!model.eGFR.HasValue)
                    ModelState.AddModelError("eGFR", "*");

                if (model.eGFR < eGFR_LB || model.eGFR > eGFR_UB)
                {
                    ModelState.AddModelError("eGFR_RANGE", Resources.Resource.Range_29_150_GFR);
                }
            }

            if (!model.Normal_AC)
            {
                if (!model.ACR_NA)
                {
                    if (!model.ACR.HasValue)
                        ModelState.AddModelError("ACR", "*");

                    if (model.ACR < ACR_LB || model.ACR > ACR_UB)
                    {
                        ModelState.AddModelError("ACR_RANGE", Resources.Resource.Range_1_50_ACR);
                    }
                }
            }


            if (ModelState.IsValid)
            {
                Entites.sp_Set_PA_Lab(

                                        model.PatientID,
                                        model.Creatinine,
                                        model.eGFR,
                                        model.ACR,
                                        model.OtherMedications_Antidepressant,
                                        model.OtherMedications_ASA,
                                        model.OtherMedications_Antiplatelet,
                                        model.OtherMedications_Erectile,
                                        model.OtherMedications_NSAID,
                                        model.OtherMedications_PPI,
                                        model.OtherMedications_Cessation,
                                        model.OtherMedications_Vitamins,
                                        model.OtherMedications_Warfarin,
                                        model.OtherMedications_Anticoagulant,
                                        model.OtherMedications_NONE ,
                                        model.Normal_AC
                    );



                return RedirectToAction("PracticeAssessment_Review", new { PatientID = model.PatientID, PatientNum = model.PatientNum });

                //model.Completed = true;
                //Entites.sp_ClosePAF(model.PatientID);

                //return RedirectToAction("PracticeAssessment");

            }
            Write(model.PatientID, model.PatientNum, model.IsReadOnly);

            return View(model);
        }

        public ActionResult PracticeAssessment_Review(int PatientID, int PatientNum)
        {

            PracticeAssessment_P1 model = new PracticeAssessment_P1();

            var entry = Entites.sp_Get_PA_Eligibility(PatientID).SingleOrDefault();
            if (entry != null)
            {
                model.ScheduledAppointment = entry.NextAppointment.Value;
            }

            model.PatientID = PatientID;
            model.PatientNum = PatientNum;

            return View(model);

        }

        public ActionResult Get_SVR_Log()
        {
            string pdf_Name = "NEXT_SCHEDULED_VISIT_DATE_LOG.pdf";
            
            byte[] bytes = Get_SVR_PDF();

            if (bytes == null ||  bytes.Length == 0 )
            {
                return null;
            }


            return File(bytes, "application/pdf", pdf_Name );

        }

        private List<SVR_Log> Get_SVR_List()
        {

            List<SVR_Log> lst = new List<SVR_Log>();
            int count = 0;

            foreach (var item in Entites.sp_Get_PAF1_SVR_Log(VistaUser.ID))
            {
                if (item != null)
                {
                    lst.Add
                    (
                          new SVR_Log()
                          {
                              PatientNum = ++count,
                              PatientID = item.PatientID.Value,
                              InternalRefNum = item.InternalRefNum,
                              NextAppointment = item.NextAppointment.HasValue ? item.NextAppointment.Value : new DateTime?()
                          }
                    );

                }
            }

            return lst;

        }

        private byte[] Get_SVR_PDF()
        {
            string PATH = "~/PDF/";  
            string formname = "NEXT SCHEDULED VISIT DATE LOG.pdf";
            //string formname = "test.pdf";
          
            GenPdf genpdf = new GenPdf(Server.MapPath(PATH));

            genpdf.Create();
 
            genpdf.AddForm(formname);

            List<SVR_Log> lst = Get_SVR_List();
            int counter = 1;
            foreach (SVR_Log item in lst)
            {
                genpdf.AddField("Internal Reference Number_" + GetNextNumber(counter), item.InternalRefNum, 0);
                genpdf.AddField("Next Scheduled Appointment Date_" + GetNextNumber(counter), item.NextAppointment.Value.ToString("yyyy/MM/dd"), 0);
                
                counter++;
            }
            
            
 
            // genpdf.Save();
            genpdf.FinalizeForm(true);

            return genpdf.Close();
        }
        private string GetNextNumber(int index)
        {
            string retVal = string.Empty;

            switch (index)
            {
               
                case 1 :

                    retVal = "01";
                    break;

                case 2:

                    retVal = "02";
                    break;

                case 3:

                    retVal = "03";
                    break;

                case 4:

                    retVal = "04";
                    break;

                case 5:

                    retVal = "05";
                    break;

                case 6:

                    retVal = "06";
                    break;

                case 7:

                    retVal = "07";
                    break;

                case 8:

                    retVal = "08";
                    break;

                case 9:

                    retVal = "09";
                    break;

                case 10:

                    retVal = "10";
                    break;
                
                default:
                    break;
            }

            return retVal;

        }

        [Authorize]
        [HttpPost]
        public JsonResult Submit_PAF_Ajax(int PatientID)
        {
            bool errored = false;
            try
            {
                Entites.sp_ClosePAF(PatientID);

            }
            catch (Exception exc)
            {

                errored = true;
            }

            return Json(new { Result = errored }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Submit_PAF(int PatientID)
        {

            Entites.sp_ClosePAF(PatientID);

            return RedirectToAction("PracticeAssessment");
        }

        public ActionResult Review_PAF(int PatientID, int PatientNum)
        {
            return RedirectToAction("PracticeAssessment_Screen1", new { PatientID = PatientID, PatientNum = PatientNum, IsReadOnly = false });
        }

        //public ActionResult FeedbackSummary(int userID)
        //{
        //    List<FeedbackSummary> lst = new List<FeedbackSummary>();

        //    foreach (var item in Entites.sp_GetFeedbackSummary(userID) )
        //    {
        //        lst.Add
        //                (

        //                new FeedbackSummary()
        //                {
        //                        Measure         = item.Measure,
        //                        Met             = item.Met,
        //                        Partially_Met   = item.Partially_Met,
        //                        Not_Met         = item.Not_Met,
        //                        NA              = item.NA
        //                }
        //            );
        //    }

        //    return View(lst);  
        //}


        public ActionResult FeedbackSummary()
        {
            List<FeedbackSummary> lst = new List<FeedbackSummary>();

            foreach (var item in Entites.sp_GetFeedbackSummary(VistaUser.ID))
	        {
                lst.Add
                        (

                        new FeedbackSummary()
                        {
                                Measure         = item.Measure,
                                Met             = item.Met,
                                Partially_Met   = item.Partially_Met,
                                Not_Met         = item.Not_Met,
                                NA              = item.NA
                        }
                    );
	        }

            return View(lst);  
        }

 
        #endregion

        #region PAF Feedback

        public ActionResult PAF_Feedback(int PatientID, int PatientNum)
        {
            PAF_Feedback model = new Models.PAF_Feedback();
            model.PatientNum = PatientNum;
            var row = Entites.sp_Get_PAF_Feedback(PatientID).SingleOrDefault();
            if (row != null)
            {
                model.Blood_Glucose = GetFeedBackImage(GetFeedBack(row.Blood_Glucose));
                model.A1C = GetFeedBackImage(GetFeedBack(row.A1C));
                model.Hypoglycemia = GetFeedBackImage(GetFeedBack(row.Hypoglycemia));
                model.Hypertension = GetFeedBackImage(GetFeedBack(row.Hypertension));
                model.WaistCircumference = GetFeedBackImage(GetFeedBack(row.WaistCircumference));
                model.BodyMassIndex = GetFeedBackImage(GetFeedBack(row.BodyMassIndex));
                model.Nutrition = GetFeedBackImage(GetFeedBack(row.Nutrition));
                model.PhysicalActivity = GetFeedBackImage(GetFeedBack(row.PhysicalActivity));
                model.Smoking = GetFeedBackImage(GetFeedBack(row.Smoking));
                model.CKD_ACR = GetFeedBackImage(GetFeedBack(row.CKD_ACR));
                model.CKD_GFR = GetFeedBackImage(GetFeedBack(row.CKD_GFR));
                model.Retinopathy = GetFeedBackImage(GetFeedBack(row.Retinopathy));
                model.Neuropathy = GetFeedBackImage(GetFeedBack(row.Neuropathy));
                model.Dyslipidemia = GetFeedBackImage(GetFeedBack(row.Dyslipidemia));
            }

            return View(model);
        }

        public FeedbackType GetFeedBack(int? prop)
        {

            FeedbackType retVal = FeedbackType.NULL;

            if (prop.HasValue)
            {
                switch (prop.Value)
                {
                    case 1:

                        retVal = FeedbackType.TARGET_CARE_OBJECTIVE_MET;
                        break;

                    case 2:

                        retVal = FeedbackType.TARGET_CARE_OBJECTIVE_NOT_MET;
                        break;

                    case 3:

                        retVal = FeedbackType.TARGET_CARE_OBJECTIVE_PARTIALLY_MET;
                        break;

                    case 4:

                        retVal = FeedbackType.NOT_APPLICABLE;
                        break;

                    case 5:

                        retVal = FeedbackType.NOT_RECORDED;
                        break;


                    //default:
                }
            }

            return retVal;

        }

        public string GetFeedBackImage(FeedbackType fb)
        {
            string retImg = string.Empty;

            switch (fb)
            {
                case FeedbackType.TARGET_CARE_OBJECTIVE_MET:

                    retImg = "<img src='../images/check.png' height='34' width='34'>";
                    break;

                case FeedbackType.TARGET_CARE_OBJECTIVE_NOT_MET:

                    retImg = "<img src='../images/x.png' height='26' width='26'>";
                    break;

                case FeedbackType.TARGET_CARE_OBJECTIVE_PARTIALLY_MET:

                    retImg = "<img src='../images/caution.png' height='33' width='37'>";
                    break;

                case FeedbackType.NOT_APPLICABLE:

                    retImg = "<img src='../images/NA.png' height='36' width='50'>";
                    break;

                case FeedbackType.NOT_RECORDED:

                    retImg = "<img src='../images/NR.png' height='36' width='50'>";
                    break;

                case FeedbackType.NULL:

                    retImg = "<img src='../images/check43.png' height='34' width='34'>";
                    break;

            }

            return retImg;
        }

        #endregion

        #region Forgot me

        [HttpGet]
        public ActionResult EmailPassword()
        {
            return View();

        }
        [HttpPost]
        public ActionResult EmailPassword(string USERNAME)
        {
            bool errored = false;

            try
            {
                string pwd = string.Empty;

                var row = Entites.sp_GetUserDetailsByUsername(USERNAME).SingleOrDefault();
                if (row != null)
                {
                    pwd = Encryptor.Decrypt(row.Password);

                    Emailer.SendPasswordEmail(USERNAME, pwd, Constants.FORGOTPWD_HTML);
                }
                else
                {
                    errored = true;
                }
            }
            catch (Exception exc)
            {

                errored = true;
            }

            return View("PasswordSent", errored);
        }

        public ActionResult FutureEmail(string txtRegCode)
        {
            ViewBag.RegCode = txtRegCode;

            return View();
        }

        [HttpPost]
        public ActionResult FutureEmail(bool chkYes, bool chkNo, string email, string RegCode)
        {

            ViewBag.RegCode = RegCode;

            if (chkYes && string.IsNullOrEmpty(email))
                ModelState.AddModelError("", "Please enter an email address");


            if (!chkYes && !chkNo)
                ModelState.AddModelError("", "Please check at least one option");

            if (ModelState.IsValid)
            {

                try
                {
                    if (chkYes)
                    {
                        Entites.sp_UpdateFutureEmail(email, RegCode);
                    }

                    return View("FutureEmailDone");
                }
                catch (Exception exc)
                {
                    ViewBag.Error = exc.Message;
                }
            }

            return View();

        }

        #endregion
     
        //public  bool Login(string username, string pwd, string returnUrl)
        //{

        //    var res = (new AccountController()).LoginProgramatically(username, pwd, returnUrl, HttpContext.GetOwinContext().Get<ApplicationSignInManager>(""));

        //    return res;

        //}

        //public async Task<bool>  Login(string username, string pwd, string returnUrl)
        //{
        //   var res = await (new AccountController()).LoginProgramatically(username, pwd, returnUrl);

        //    return res;
        //}

    }
}