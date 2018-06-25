
 
   
   
   using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VistaDM.Domain;
using VistaDM.Data;

namespace VistaDM.Repository
{
    public class InviteeRepository : BaseRepository
    {
        public List<RegistrationStatus> GetRegistartionStatus()
        {
            return (from r in Entites.RegistartionStatus
                    select new RegistrationStatus()
                    {
                        ID = r.ID,
                        Name = r.Name
                    }).ToList();

        }

        public void UpdateRegistartionStatus(int physicianID, int statusID)
        {
            Entites.sp_UpdateRegistrationStatus(physicianID, statusID);
        }

        public void UpdateInvitedValue(int physicianID, bool invited)
        {
            Entites.sp_UpdateInvitedValue(physicianID, invited);
        }

        public void UpdateInviteDate(int physicianID, bool dateEntered, bool isFrench, bool updateCHRC)
        {
            Entites.sp_UpdateInvitationDate(physicianID, dateEntered ? 1 : 0, isFrench ? 1 : 0, updateCHRC ? 1 : 0);
        }

        public List<Domain.Invitee> GetAllInvitees(bool? isPCP)
        {
            List<Domain.Invitee> retLst = new List<Domain.Invitee>();

            foreach (var item in Entites.sp_GetAllInvitees(null, isPCP.HasValue ? (isPCP.Value ? 1 : 2) : 0 ))
            {

                Domain.Invitee newInvitee = new Domain.Invitee();

                newInvitee.PhysicianID = item.ID;
                newInvitee.Speciality = item.Specialty;
                newInvitee.OneKeyID = item.OneKeyID;
                newInvitee.RegistrationCode = item.RegCode;
                newInvitee.FirstName = item.FirstName;
                newInvitee.LastName = item.LastName;
                newInvitee.PrimaryWorkplace = item.PrimaryWorkplace;
                newInvitee.Address = item.Address;
                newInvitee.City = item.City;
                newInvitee.ProvinceID = item.ProvinceID.HasValue ? item.ProvinceID.Value : 0;
                newInvitee.Invited = item.Invited.HasValue ? item.Invited.Value : false;
                newInvitee.Status = item.RegistrationStatusID;
                newInvitee.PostalCode = item.PostalCode;
                newInvitee.Phone = item.Phone;
                newInvitee.Fax = item.Fax;
                newInvitee.OptInEmail = item.OptInEmail;
                newInvitee.BITerritoryID = item.BITerritoryID.HasValue ?  item.BITerritoryID.Value : new int?();
                newInvitee.LillyID = string.IsNullOrEmpty(item.LillyID) ? string.Empty : item.LillyID ;

                newInvitee.Province = new Domain.Province() { ID = item.ProvinceID, Name = item.Province };
                newInvitee.PhysicianType = item.TypeID == 1 ? Enums.PhysicianType.PCP : Enums.PhysicianType.CS;
                newInvitee.ReStatus = new RegistrationStatus() { ID = item.RegistrationStatusID, Name = item.Status };
                newInvitee.FSA = item.FSA;

                newInvitee.InvitationSentDate = item.InvitationSentDate; 
                newInvitee.InvitationSentDateFrench = item.InvitationSentDateFrench ;

                retLst.Add(newInvitee);
            }

            return retLst;

        }

        public List<Domain.Invitee> GetAllInviteesPending(bool? isPCP)
        {
            List<Domain.Invitee> retLst = new List<Domain.Invitee>();

            foreach (var item in Entites.sp_GetAllInviteesPending(null, isPCP.HasValue ? (isPCP.Value ? 1 : 2) : 0))
            {

                Domain.Invitee newInvitee = new Domain.Invitee();

                newInvitee.PhysicianID = item.ID;
                newInvitee.Speciality = item.Specialty;
                newInvitee.OneKeyID = item.OneKeyID;
                newInvitee.RegistrationCode = item.RegCode;
                newInvitee.FirstName = item.FirstName;
                newInvitee.LastName = item.LastName;
                newInvitee.PrimaryWorkplace = item.PrimaryWorkplace;
                newInvitee.Address = item.Address;
                newInvitee.City = item.City;
                newInvitee.ProvinceID = item.ProvinceID.HasValue ? item.ProvinceID.Value : 0;
                newInvitee.Invited = item.Invited.HasValue ? item.Invited.Value : false;
                newInvitee.Status = item.RegistrationStatusID;
                newInvitee.PostalCode = item.PostalCode;
                newInvitee.Phone = item.Phone;
                newInvitee.Fax = item.Fax;
                newInvitee.OptInEmail = item.OptInEmail;

                newInvitee.YourFirstName = item.AdderFirstName;
                newInvitee.YourLastName = item.AdderLastName;
                newInvitee.YourEmail = item.AdderEmail;

                newInvitee.Province = new Domain.Province() { ID = item.ProvinceID, Name = item.Province };
                newInvitee.ReStatus = new RegistrationStatus() { ID = item.RegistrationStatusID, Name = item.Status };
                newInvitee.FSA = item.FSA;

                newInvitee.InvitationSentDate = item.InvitationSentDate;
                newInvitee.InvitationSentDateFrench = item.InvitationSentDateFrench;

                newInvitee.PhysicianType = item.TypeID.Value == 1 ? VistaDM.Domain.Enums.PhysicianType.PCP : VistaDM.Domain.Enums.PhysicianType.CS;

                retLst.Add(newInvitee);
            }

            return retLst;

        }

        public List<Domain.Invitee> GetAllInviteesByProvince(int provinceID, bool? isPCP)
        {
            List<Domain.Invitee> retLst = new List<Domain.Invitee>();

            foreach (var item in Entites.sp_GetAllInvitees(provinceID,  isPCP.HasValue ? (isPCP.Value ? 1 : 2 ) : 0 ))
            {
                 
                Domain.Invitee newInvitee = new Domain.Invitee();

                newInvitee.PhysicianID = item.ID;
                newInvitee.Speciality = item.Specialty;
                newInvitee.OneKeyID = item.OneKeyID;
                newInvitee.RegistrationCode = item.RegCode;
                newInvitee.FirstName = item.FirstName;
                newInvitee.LastName = item.LastName;
                newInvitee.PrimaryWorkplace = item.PrimaryWorkplace;
                newInvitee.Address = item.Address;
                newInvitee.City = item.City;
                newInvitee.ProvinceID = item.ProvinceID.HasValue ? item.ProvinceID.Value : 0;
                newInvitee.Invited = item.Invited.HasValue ? item.Invited.Value : false;
                newInvitee.Status = item.RegistrationStatusID;
                newInvitee.PostalCode = item.PostalCode;
                newInvitee.Phone = item.Phone;
                newInvitee.Fax = item.Fax;
                newInvitee.OptInEmail = item.OptInEmail;
                newInvitee.BITerritoryID = item.BITerritoryID.HasValue ? item.BITerritoryID.Value : new int?();
                newInvitee.LillyID = string.IsNullOrEmpty(item.LillyID) ? string.Empty : item.LillyID;
                
                newInvitee.Province = new Domain.Province() { ID = item.ProvinceID, Name = item.Province };
                newInvitee.ReStatus = new RegistrationStatus() { ID = item.RegistrationStatusID, Name = item.Status };
                newInvitee.FSA = item.FSA;

                newInvitee.InvitationSentDate = item.InvitationSentDate;
                newInvitee.InvitationSentDateFrench = item.InvitationSentDateFrench;

                newInvitee.PhysicianType = item.TypeID.Value == 1 ? VistaDM.Domain.Enums.PhysicianType.PCP : VistaDM.Domain.Enums.PhysicianType.CS;

                retLst.Add(newInvitee);
            }

            return retLst;

        }

        public List<Domain.Invitee> GetAllInviteesByProvincePending(int provinceID, bool? isPCP)
        {
            List<Domain.Invitee> retLst = new List<Domain.Invitee>();

            foreach (var item in Entites.sp_GetAllInviteesPending(provinceID, isPCP.HasValue ? (isPCP.Value ? 1 : 2) : 0))
            {

                Domain.Invitee newInvitee = new Domain.Invitee();

                newInvitee.PhysicianID = item.ID;
                newInvitee.Speciality = item.Specialty;
                newInvitee.OneKeyID = item.OneKeyID;
                newInvitee.RegistrationCode = item.RegCode;
                newInvitee.FirstName = item.FirstName;
                newInvitee.LastName = item.LastName;
                newInvitee.PrimaryWorkplace = item.PrimaryWorkplace;
                newInvitee.Address = item.Address;
                newInvitee.City = item.City;
                newInvitee.ProvinceID = item.ProvinceID.HasValue ? item.ProvinceID.Value : 0;
                newInvitee.Invited = item.Invited.HasValue ? item.Invited.Value : false;
                newInvitee.Status = item.RegistrationStatusID;
                newInvitee.PostalCode = item.PostalCode;
                newInvitee.Phone = item.Phone;
                newInvitee.Fax = item.Fax;
                newInvitee.OptInEmail = item.OptInEmail;

                newInvitee.YourFirstName = item.AdderFirstName;
                newInvitee.YourLastName = item.AdderLastName;
                newInvitee.YourEmail = item.AdderEmail;


                newInvitee.Province = new Domain.Province() { ID = item.ProvinceID, Name = item.Province };
                
                newInvitee.ReStatus = new RegistrationStatus() { ID = item.RegistrationStatusID, Name = item.Status };
                newInvitee.FSA = item.FSA;

                newInvitee.InvitationSentDate = item.InvitationSentDate;
                newInvitee.InvitationSentDateFrench = item.InvitationSentDateFrench;

                newInvitee.PhysicianType = item.TypeID.Value == 1 ? VistaDM.Domain.Enums.PhysicianType.PCP : VistaDM.Domain.Enums.PhysicianType.CS;

                retLst.Add(newInvitee);
            }

            return retLst;

        }

        public Domain.Invitee GetDetail(int physicianID)
        {
            Domain.Invitee retVal = new Domain.Invitee();

            var item = Entites.sp_GetInviteeDetail(physicianID).SingleOrDefault();

            if (item != null)
            {
                retVal.PhysicianID = item.ID;
                retVal.Speciality = item.Specialty;
                retVal.OneKeyID = item.OneKeyID;
                retVal.RegistrationCode = item.RegCode;
                retVal.FirstName = item.FirstName;
                retVal.LastName = item.LastName;
                retVal.PrimaryWorkplace = item.PrimaryWorkplace;
                retVal.Address = item.Address;
                retVal.City = item.City;
                retVal.ProvinceID = item.ProvinceID.HasValue ? item.ProvinceID.Value : 0;
                retVal.Invited = item.Invited.HasValue ? item.Invited.Value : false;
                retVal.Status = item.RegistrationStatusID;
                retVal.PostalCode = item.PostalCode;
                retVal.Phone = item.Phone;
                retVal.Fax = item.Fax;
                retVal.OptInEmail = item.OptInEmail;
                retVal.Comments = item.Comments;

                retVal.YourFirstName = item.AdderFirstName;
                retVal.YourLastName = item.AdderLastName;
                retVal.YourEmail = item.AdderEmail;

                retVal.BITerritoryID = item.BITerritoryID.HasValue ? item.BITerritoryID.Value : new int?();
                retVal.LillyID = string.IsNullOrEmpty(item.LillyID) ? string.Empty : item.LillyID;
                retVal.UserName = item.UserName;

                retVal.Province = new Domain.Province() { ID = item.ProvinceID, Name = item.Province };
                retVal.PhysicianType = item.TypeID.Value == 1 ? VistaDM.Domain.Enums.PhysicianType.PCP : VistaDM.Domain.Enums.PhysicianType.CS;
                retVal.ReStatus = new RegistrationStatus() { ID = item.RegistrationStatusID, Name = item.Status };
            }
            return retVal;

        }

        public void AddInvitee(Domain.Invitee inv)
        {
            Entites.sp_AddPhysician
                                    (
                                       inv.FirstName ,
                                       inv.LastName ,
                                       inv.PrimaryWorkplace , 
                                       inv.Address,
                                       inv.City,
                                       inv.ProvinceID ,
                                       inv.PostalCode ,
                                       inv.Phone ,
                                       inv.Fax ,
                                       inv.OptInEmail,
                                       inv.Comments ,
                                       inv.RegistrationCode ,
                                       inv.IsAdminApproved ? 1 : 0 ,
                                       inv.PhysicianType == Enums.PhysicianType.PCP ? 1 : 2 ,
                                       inv.YourFirstName,
                                       inv.YourLastName,
                                       inv.YourEmail ,

                                       inv.BITerritoryID ,
                                       inv.LillyID 
                                    ); 
        }

        public void UpdateInvitee(Domain.Invitee inv)
        {
            Entites.sp_UpdatePhysician
                                    (
                                      
                                       inv.PhysicianID,
                                       inv.FirstName,
                                       inv.LastName,
                                       inv.PrimaryWorkplace,
                                       inv.Address,
                                       inv.City,
                                       inv.ProvinceID,
                                       inv.PostalCode,
                                       inv.Phone,
                                       inv.Fax,
                                       inv.OptInEmail,
                                       inv.Comments,
                                       inv.BITerritoryID,
                                       inv.LillyID 
                                    );
        }

        public List<Domain.Invitee> GetInviteeData(List<int> idLst)
        {
            List<Domain.Invitee> retLst = new List<Domain.Invitee>();

            foreach (var item in Entites.sp_GetAllInvitees(null,null))
            {

                if (idLst.Contains(item.ID))
                {
                    Domain.Invitee newInvitee = new Domain.Invitee();

                    newInvitee.PhysicianID = item.ID;
                    newInvitee.Speciality = item.Specialty;
                    newInvitee.OneKeyID = item.OneKeyID;
                    newInvitee.RegistrationCode = item.RegCode;
                    newInvitee.FirstName = item.FirstName;
                    newInvitee.LastName = item.LastName;
                    newInvitee.PrimaryWorkplace = item.PrimaryWorkplace;
                    newInvitee.Address = item.Address;
                    newInvitee.City = item.City;
                    newInvitee.ProvinceID = item.ProvinceID.HasValue ? item.ProvinceID.Value : 0;
                    newInvitee.Invited = item.Invited.HasValue ? item.Invited.Value : false;
                    newInvitee.Status = item.RegistrationStatusID;
                    newInvitee.PostalCode = item.PostalCode;
                    newInvitee.Phone = item.Phone;
                    newInvitee.Fax = item.Fax;
                    newInvitee.OptInEmail = item.OptInEmail;

                    newInvitee.Province = new Domain.Province() { ID = item.ProvinceID, Name = item.Province };
                    newInvitee.PhysicianType = item.TypeID == 1 ? Enums.PhysicianType.PCP : Enums.PhysicianType.CS;
                    newInvitee.ReStatus = new RegistrationStatus() { ID = item.RegistrationStatusID, Name = item.Status };
                    newInvitee.FSA = item.FSA;

                    retLst.Add(newInvitee);
                }
            }

            return retLst;
        }

        public void Approve(int physicianID )
        {
            Entites.sp_ApprovePhysician( physicianID );
                                    
        }

        public ParticipationSummary_PCP GetParticipantSummary_PCP(int physicianID)
        {
            ParticipationSummary_PCP retVal = new ParticipationSummary_PCP();

            var item = Entites.sp_GetParticipationSummary_PCP(physicianID).SingleOrDefault();
            if (item != null)
            {
                retVal.MOU              = item.MOU.HasValue ? (item.MOU.Value  ? Status.COMPLETED : Status.NOT_COMPLETED) : Status.NOT_COMPLETED;
                retVal.Payee            = item.Payee.HasValue ? (item.Payee.Value ? Status.COMPLETED : Status.NOT_COMPLETED) : Status.NOT_COMPLETED;
                retVal.NeedsAssesment   = item.AssesmentSurvey.HasValue ? (item.AssesmentSurvey.Value ? Status.COMPLETED : Status.NOT_COMPLETED) : Status.NOT_COMPLETED;
                retVal.NeedsAsses_Remuneration = item.NeedsAsses_Remuneration.Value;
                retVal.PAF1             = item.PAF1_Complete.Value;
                retVal.PAF1_Renum       = item.PAF1_Remuneration.Value;
                retVal.PatientSurvey    = item.PatientSurvey.Value;
                retVal.PS_Received      = item.PS_Received.HasValue ? item.PS_Received.Value : 0 ;
            }

            return retVal;

        }

        public List<Remuneration> Get_PAF_Remuneration(int physicianID)
        {
            List<Remuneration> retLst = new List<Remuneration>();

            foreach (var item in Entites.sp_Get_PAF_Remuneration(physicianID))
            {
                retLst.Add(

                        new Remuneration()
                        {
                           Date      = item.Date.Value,
                           Cheque    = item.Cheque,
                           Amount    = item.Amount.Value,
                           Comments  = item.Comments,
                           InviteeID = item.InviteeID.Value

                        }
                    );
            }

            return retLst;
        }

        public void Set_PAF_Remuneration(Remuneration ren)
        {

            Entites.sp_Set_PAF_Remuneration(

                                            ren.Date,
                                            ren.Cheque,
                                            ren.Amount,
                                            ren.Comments,
                                            ren.InviteeID
                                );

        }


        public List<Remuneration> Get_Assesment_Remuneration(int physicianID)
        {
            List<Remuneration> retLst = new List<Remuneration>();

            foreach (var item in Entites.sp_Get_Assesment_Remuneration(physicianID))
            {
                retLst.Add(

                        new Remuneration()
                        {
                            Date = item.Date.Value,
                            Cheque = item.Cheque,
                            Amount = item.Amount.Value,
                            Comments = item.Comments,
                            InviteeID = item.InviteeID.Value

                        }
                    );
            }

            return retLst;
        }

        public void Set_Assesment_Remuneration(Remuneration ren)
        {

            Entites.sp_Set_Assesment_Remuneration(

                                            ren.Date,
                                            ren.Cheque,
                                            ren.Amount,
                                            ren.Comments,
                                            ren.InviteeID
                                );

        }


        public void Set_PS(Remuneration_PS ren)
        {
            Entites.sp_Set_PS
                            (
                                ren.InviteeID, 
                                ren.Date ,
                                ren.Received ,
                                ren.GiftCard
                           );
        }

        public Remuneration_PS Get_PS(int inviteeID)
        {
            Remuneration_PS retVal = new Remuneration_PS();

            var item = Entites.sp_Get_PS(inviteeID).SingleOrDefault();
            if (item != null)
            {
                if ( item.Date.HasValue )
                { 
                    retVal.Date = item.Date.Value;
                    retVal.Received = item.Received;
                    retVal.GiftCard = item.GiftCard.Value;
                }
            }

            return retVal;
        }
        
    }
}

   
   
   
   
 