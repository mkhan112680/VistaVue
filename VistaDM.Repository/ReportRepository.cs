using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VistaDM.Domain;

namespace VistaDM.Repository
{
    public class ReportRepository : BaseRepository
    {

        public ProvinceReport GetCount_PCP()
        {
            ProvinceReport retVal = new ProvinceReport();

            foreach (var item in Entites.sp_GetProvinceReport_PCP())
            {
                switch (item.Province)
                {
                    case "AB":

                        retVal.AB_Invited = item.Invited;
                        retVal.AB_Registered = item.Registered;
                        
                        retVal.AB_ePAF = item.ePAF;
                        retVal.AB_eMAF = item.eMAF;

                        break;

                    case "BC":

                        retVal.BC_Invited = item.Invited;
                        retVal.BC_Registered = item.Registered;

                        retVal.BC_ePAF = item.ePAF;
                        retVal.BC_eMAF = item.eMAF;

                        break;

                    case "SK":

                        retVal.SK_Invited = item.Invited;
                        retVal.SK_Registered = item.Registered;

                        retVal.SK_ePAF = item.ePAF;
                        retVal.SK_eMAF = item.eMAF;

                        break;
                    case "MB":

                        retVal.MB_Invited = item.Invited;
                        retVal.MB_Registered = item.Registered;

                        retVal.MB_ePAF = item.ePAF;
                        retVal.MB_eMAF = item.eMAF;

                        break;
                    case "ON":

                        retVal.ON_Invited = item.Invited;
                        retVal.ON_Registered = item.Registered;

                        retVal.ON_ePAF = item.ePAF;
                        retVal.ON_eMAF = item.eMAF;

                        break;
                    case "QC":

                        retVal.QC_Invited = item.Invited;
                        retVal.QC_Registered = item.Registered;

                        retVal.QC_ePAF = item.ePAF;
                        retVal.QC_eMAF = item.eMAF;

                        break;
                    case "NB":

                        retVal.NB_Invited = item.Invited;
                        retVal.NB_Registered = item.Registered;

                        retVal.NB_ePAF = item.ePAF;
                        retVal.NB_eMAF = item.eMAF;

                        break;
                    case "NS":

                        retVal.NS_Invited = item.Invited;
                        retVal.NS_Registered = item.Registered;

                        retVal.NS_ePAF = item.ePAF;
                        retVal.NS_eMAF = item.eMAF;

                        break;
                   
                    case "NL":
                       
                        retVal.NL_Invited = item.Invited;
                        retVal.NL_Registered = item.Registered;

                        retVal.NL_ePAF = item.ePAF;
                        retVal.NL_eMAF = item.eMAF;

                        break;
                    case "PEI":

                        retVal.PEI_Invited = item.Invited;
                        retVal.PEI_Registered = item.Registered;

                        retVal.PEI_ePAF = item.ePAF;
                        retVal.PEI_eMAF = item.eMAF;

                        break;
                }

            }

            return retVal;
        }

        public ProvinceReport GetCount_CS()
        {
            ProvinceReport retVal = new ProvinceReport();

            foreach (var item in Entites.sp_GetProvinceReport_CS())
            {
                switch (item.Province)
                {
                    case "AB":

                        retVal.AB_Invited = item.Invited;
                        retVal.AB_Registered = item.Registered;

                        break;

                    case "BC":

                        retVal.BC_Invited = item.Invited;
                        retVal.BC_Registered = item.Registered;

                        break;

                    case "SK":

                        retVal.SK_Invited = item.Invited;
                        retVal.SK_Registered = item.Registered;

                        break;
                    case "MB":

                        retVal.MB_Invited = item.Invited;
                        retVal.MB_Registered = item.Registered;

                        break;
                    case "ON":

                        retVal.ON_Invited = item.Invited;
                        retVal.ON_Registered = item.Registered;

                        break;
                    case "QC":

                        retVal.QC_Invited = item.Invited;
                        retVal.QC_Registered = item.Registered;

                        break;
                    case "NB":

                        retVal.NB_Invited = item.Invited;
                        retVal.NB_Registered = item.Registered;

                        break;
                    case "NS":

                        retVal.NS_Invited = item.Invited;
                        retVal.NS_Registered = item.Registered;

                        break;
                    case "NL":
                        retVal.NL_Invited = item.Invited;
                        retVal.NL_Registered = item.Registered;

                        break;
                    case "PEI":

                        retVal.PEI_Invited = item.Invited;
                        retVal.PEI_Registered = item.Registered;

                        break;
                }

            }

            return retVal;
        }

        public List<GlanceReport> GetGlanceReport_PCP()
        {
            List<GlanceReport> lst = new List<GlanceReport>();
            
            foreach (var item in Entites.sp_Get_PCPGlance_Report())
            {
                lst.Add(
                         new GlanceReport() 
                                {
                                    Province    = item.Province,
                                    Invited     = item.Invited ,
                                    Registered  = item.Registered,
                                    MOU         = item.MOU,
                                    NA          = item.NA,
                                    Payee       = item.Payee,
                                    ePAF        = item.ePAF,
                                    eMAF        = item.eMAF
                                }
                        );
            }

            return lst;
        }

        public List<GlanceReport> GetGlanceReport_CS()
        {
            List<GlanceReport> lst = new List<GlanceReport>();

            foreach (var item in Entites.sp_Get_CSGlance_Report())
            {
                lst.Add(
                         new GlanceReport()
                         {
                             Province = item.Province,
                             Invited = item.Invited,
                             Registered = item.Registered,
                             MOU = item.MOU,
                             NA = item.NA,
                             Payee = item.Payee
                         }
                        );
            }

            return lst;
        }

       
        public List<MasterReport> GetMasterReport(string fsaLst, bool isPCP )
        {
            List<MasterReport> retVal = new List<MasterReport>();

            foreach (var item in Entites.sp_GetMasterListReport(fsaLst, isPCP?1:2))
            {
                retVal.Add
                        (
                            new MasterReport()
                            {
                                RegCode = item.RegCode,
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                FSA = item.FSA,
                                PostalCode = item.PostalCode,
                                Status = item.Status,
                                Clinic = item.Clinic,
                                Address = item.Address,
                                City = item.City,
                                Province = item.Province,
                                Phone = item.Phone,
                                Fax = item.Fax,
                                DocType = item.DocType == 1 ? "PCP" : "CS",
                                BITerritoryID = item.BITerritoryID.HasValue ? item.BITerritoryID.Value : new int?() ,
                                LillyID = item.LillyID
                                
                            }
                        );
            }

            return retVal;
        }

        public List<MasterReport> GetMasterReport_BI(string biLst, bool isPCP)
        {
            List<MasterReport> retVal = new List<MasterReport>();

            foreach (var item in Entites.sp_GetMasterListReport_BI(biLst, isPCP ? 1 : 2))
            {
                retVal.Add
                        (
                            new MasterReport()
                            {
                                RegCode = item.RegCode,
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                FSA = item.FSA,
                                PostalCode = item.PostalCode,
                                Status = item.Status,
                                Clinic = item.Clinic,
                                Address = item.Address,
                                City = item.City,
                                Province = item.Province,
                                Phone = item.Phone,
                                Fax = item.Fax,
                                DocType = item.DocType == 1 ? "PCP" : "CS",
                                BITerritoryID = item.BITerritoryID.HasValue ? item.BITerritoryID.Value : new int?() ,
                                LillyID = item.LillyID
                            }
                        );
            }

            return retVal;
        }

        public List<MasterReport> GetMasterReport_Lilly(string lillyLst, bool isPCP)
        {
            List<MasterReport> retVal = new List<MasterReport>();

            foreach (var item in Entites.sp_GetMasterListReport_Lilly(lillyLst, isPCP ? 1 : 2))
            {
                retVal.Add
                        (
                            new MasterReport()
                            {
                                RegCode = item.RegCode,
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                FSA = item.FSA,
                                PostalCode = item.PostalCode,
                                Status = item.Status,
                                Clinic = item.Clinic,
                                Address = item.Address,
                                City = item.City,
                                Province = item.Province,
                                Phone = item.Phone,
                                Fax = item.Fax,
                                DocType = item.DocType == 1 ? "PCP" : "CS",
                                BITerritoryID = item.BITerritoryID.HasValue ? item.BITerritoryID.Value : new int?(),
                                LillyID = item.LillyID
                            }
                        );
            }

            return retVal;
        }

        
        
        public List<MasterReport> GetInvitedReport(string fsaLst, bool isPCP )
        {
            List<MasterReport> retVal = new List<MasterReport>();

            foreach (var item in Entites.sp_GetInvitedListReport(fsaLst, isPCP ? 1 : 2))
            {
                retVal.Add
                        (
                            new MasterReport()
                            {
                                RegCode = item.RegCode,
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                FSA = item.FSA,
                                PostalCode = item.PostalCode,
                                Status = item.Status,
                                Clinic = item.Clinic,
                                Address = item.Address,
                                City = item.City,
                                Province = item.Province,
                                Phone = item.Phone,
                                Fax = item.Fax,
                                DocType = item.DocType == 1 ? "PCP" : "CS",
                                BITerritoryID = item.BITerritoryID.HasValue ? item.BITerritoryID.Value : new int?() ,
                                LillyID = item.LillyID
                            }
                        );
            }

            return retVal;
        }

        public List<MasterReport> GetInvitedReport_BI(string biLst, bool isPCP)
        {
            List<MasterReport> retVal = new List<MasterReport>();

            foreach (var item in Entites.sp_GetInvitedListReport_BI(biLst, isPCP ? 1 : 2))
            {
                retVal.Add
                        (
                            new MasterReport()
                            {
                                RegCode = item.RegCode,
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                FSA = item.FSA,
                                PostalCode = item.PostalCode,
                                Status = item.Status,
                                Clinic = item.Clinic,
                                Address = item.Address,
                                City = item.City,
                                Province = item.Province,
                                Phone = item.Phone,
                                Fax = item.Fax,
                                DocType = item.DocType == 1 ? "PCP" : "CS",
                                BITerritoryID = item.BITerritoryID.HasValue ? item.BITerritoryID.Value : new int?() ,
                                LillyID = item.LillyID
                            }
                        );
            }

            return retVal;
        }

        public List<MasterReport> GetInvitedReport_Lilly(string biLst, bool isPCP)
        {
            List<MasterReport> retVal = new List<MasterReport>();

            foreach (var item in Entites.sp_GetInvitedListReport_Lilly(biLst, isPCP ? 1 : 2))
            {
                retVal.Add
                        (
                            new MasterReport()
                            {
                                RegCode = item.RegCode,
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                FSA = item.FSA,
                                PostalCode = item.PostalCode,
                                Status = item.Status,
                                Clinic = item.Clinic,
                                Address = item.Address,
                                City = item.City,
                                Province = item.Province,
                                Phone = item.Phone,
                                Fax = item.Fax,
                                DocType = item.DocType == 1 ? "PCP" : "CS",
                                BITerritoryID = item.BITerritoryID.HasValue ? item.BITerritoryID.Value : new int?() ,
                                LillyID = item.LillyID
                            }
                        );
            }

            return retVal;
        }

        

        public List<MasterReport> GetRegisteredReport(string fsaLst, bool isPCP )
        {
            List<MasterReport> retVal = new List<MasterReport>();

            foreach (var item in Entites.sp_GetRegisteredListReport(fsaLst, isPCP ? 1 : 2))
            {
                retVal.Add
                        (
                            new MasterReport()
                            {
                                RegCode = item.RegCode,
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                FSA = item.FSA,
                                PostalCode = item.PostalCode,
                                Status = item.Status,
                                Clinic = item.Clinic,
                                Address = item.Address,
                                City = item.City,
                                Province = item.Province,
                                Phone = item.Phone,
                                Fax = item.Fax,
                                DocType = item.DocType == 1 ? "PCP" : "CS",
                                BITerritoryID = item.BITerritoryID.HasValue ? item.BITerritoryID.Value : new int?() ,
                                LillyID = item.LillyID
                            }
                        );
            }

            return retVal;
        }

        public List<MasterReport> GetRegisteredReport_BI(string biLst, bool isPCP)
        {
            List<MasterReport> retVal = new List<MasterReport>();

            foreach (var item in Entites.sp_GetRegisteredListReport_BI(biLst, isPCP ? 1 : 2))
            {
                retVal.Add
                        (
                            new MasterReport()
                            {
                                RegCode = item.RegCode,
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                FSA = item.FSA,
                                PostalCode = item.PostalCode,
                                Status = item.Status,
                                Clinic = item.Clinic,
                                Address = item.Address,
                                City = item.City,
                                Province = item.Province,
                                Phone = item.Phone,
                                Fax = item.Fax,
                                DocType = item.DocType == 1 ? "PCP" : "CS",
                                BITerritoryID = item.BITerritoryID.HasValue ? item.BITerritoryID.Value : new int?() ,
                                LillyID = item.LillyID
                            }
                        );
            }

            return retVal;
        }

        public List<MasterReport> GetRegisteredReport_Lilly(string lillyLst, bool isPCP)
        {
            List<MasterReport> retVal = new List<MasterReport>();

            foreach (var item in Entites.sp_GetRegisteredListReport_Lilly(lillyLst, isPCP ? 1 : 2))
            {
                retVal.Add
                        (
                            new MasterReport()
                            {
                                RegCode = item.RegCode,
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                FSA = item.FSA,
                                PostalCode = item.PostalCode,
                                Status = item.Status,
                                Clinic = item.Clinic,
                                Address = item.Address,
                                City = item.City,
                                Province = item.Province,
                                Phone = item.Phone,
                                Fax = item.Fax,
                                DocType = item.DocType == 1 ? "PCP" : "CS",
                                BITerritoryID = item.BITerritoryID.HasValue ? item.BITerritoryID.Value : new int?() ,
                                LillyID = item.LillyID
                            }
                        );
            }

            return retVal;
        }

    
   
        public List<MasterReport> GetNoResponseReport(string fsaLst, bool isPCP )
        {
            List<MasterReport> retVal = new List<MasterReport>();

            foreach (var item in Entites.sp_GetNoResponseListReport(fsaLst, isPCP ? 1 : 2))
            {
                retVal.Add
                        (
                            new MasterReport()
                            {
                                RegCode = item.RegCode,
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                FSA = item.FSA,
                                PostalCode = item.PostalCode,
                                Status = item.Status,
                                Clinic = item.Clinic,
                                Address = item.Address,
                                City = item.City,
                                Province = item.Province,
                                Phone = item.Phone,
                                Fax = item.Fax,
                                DocType = item.DocType == 1 ? "PCP" : "CS",
                                BITerritoryID = item.BITerritoryID.HasValue ? item.BITerritoryID.Value : new int?() ,
                                LillyID = item.LillyID
                            }
                        );
            }

            return retVal;
        }

        public List<MasterReport> GetNoResponseReport_BI(string biLst, bool isPCP)
        {
            List<MasterReport> retVal = new List<MasterReport>();

            foreach (var item in Entites.sp_GetNoResponseListReport_BI(biLst, isPCP ? 1 : 2))
            {
                retVal.Add
                        (
                            new MasterReport()
                            {
                                RegCode = item.RegCode,
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                FSA = item.FSA,
                                PostalCode = item.PostalCode,
                                Status = item.Status,
                                Clinic = item.Clinic,
                                Address = item.Address,
                                City = item.City,
                                Province = item.Province,
                                Phone = item.Phone,
                                Fax = item.Fax,
                                DocType = item.DocType == 1 ? "PCP" : "CS",
                                BITerritoryID = item.BITerritoryID.HasValue ? item.BITerritoryID.Value : new int?() ,
                                LillyID = item.LillyID
                            }
                        );
            }

            return retVal;
        }

        public List<MasterReport> GetNoResponseReport_Lilly(string biLst, bool isPCP)
        {
            List<MasterReport> retVal = new List<MasterReport>();

            foreach (var item in Entites.sp_GetNoResponseListReport_Lilly(biLst, isPCP ? 1 : 2))
            {
                retVal.Add
                        (
                            new MasterReport()
                            {
                                RegCode = item.RegCode,
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                FSA = item.FSA,
                                PostalCode = item.PostalCode,
                                Status = item.Status,
                                Clinic = item.Clinic,
                                Address = item.Address,
                                City = item.City,
                                Province = item.Province,
                                Phone = item.Phone,
                                Fax = item.Fax,
                                DocType = item.DocType == 1 ? "PCP" : "CS",
                                BITerritoryID = item.BITerritoryID.HasValue ? item.BITerritoryID.Value : new int?() ,
                                LillyID = item.LillyID
                            }
                        );
            }

            return retVal;
        }

        

        public List<MasterReport> GetNotInvitedReport(string fsaLst, bool isPCP )
        {
            List<MasterReport> retVal = new List<MasterReport>();

            foreach (var item in Entites.sp_GetNotInvitedListReport(fsaLst, isPCP ? 1 : 2))
            {
                retVal.Add
                        (
                            new MasterReport()
                            {
                                RegCode = item.RegCode,
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                FSA = item.FSA,
                                PostalCode = item.PostalCode,
                                Status = item.Status,
                                Clinic = item.Clinic,
                                Address = item.Address,
                                City = item.City,
                                Province = item.Province,
                                Phone = item.Phone,
                                Fax = item.Fax,
                                DocType = item.DocType == 1 ? "PCP" : "CS",
                                BITerritoryID = item.BITerritoryID.HasValue ? item.BITerritoryID.Value : new int?() ,
                                LillyID = item.LillyID
                            }
                        );
            }

            return retVal;
        }

        public List<MasterReport> GetNotInvitedReport_BI(string biLst, bool isPCP)
        {
            List<MasterReport> retVal = new List<MasterReport>();

            foreach (var item in Entites.sp_GetNotInvitedListReport_BI(biLst, isPCP ? 1 : 2))
            {
                retVal.Add
                        (
                            new MasterReport()
                            {
                                RegCode = item.RegCode,
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                FSA = item.FSA,
                                PostalCode = item.PostalCode,
                                Status = item.Status,
                                Clinic = item.Clinic,
                                Address = item.Address,
                                City = item.City,
                                Province = item.Province,
                                Phone = item.Phone,
                                Fax = item.Fax,
                                DocType = item.DocType == 1 ? "PCP" : "CS",
                                BITerritoryID = item.BITerritoryID.HasValue ? item.BITerritoryID.Value : new int?() ,
                                LillyID = item.LillyID
                            }
                        );
            }

            return retVal;
        }

        public List<MasterReport> GetNotInvitedReport_Lilly(string biLst, bool isPCP)
        {
            List<MasterReport> retVal = new List<MasterReport>();

            foreach (var item in Entites.sp_GetNotInvitedListReport_Lilly(biLst, isPCP ? 1 : 2))
            {
                retVal.Add
                        (
                            new MasterReport()
                            {
                                RegCode = item.RegCode,
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                FSA = item.FSA,
                                PostalCode = item.PostalCode,
                                Status = item.Status,
                                Clinic = item.Clinic,
                                Address = item.Address,
                                City = item.City,
                                Province = item.Province,
                                Phone = item.Phone,
                                Fax = item.Fax,
                                DocType = item.DocType == 1 ? "PCP" : "CS",
                                BITerritoryID = item.BITerritoryID.HasValue ? item.BITerritoryID.Value : new int?() ,
                                LillyID = item.LillyID
                            }
                        );
            }

            return retVal;
        }

        
 
        public List<AllianceReport> GetAllianceReport()
        {
            List<AllianceReport> retVal = new List<AllianceReport>();

            foreach (var item in Entites.sp_GetAllianceReport())
            {
                retVal.Add
                        (
                            new AllianceReport()
                            {
                                FirstName = item.FirstName ,
                                LastName = item.LastName,
                                CompanyName = item.CompanyName ,
                                Role = item.Role,
                                All = item.All.HasValue ? ( item.All.Value ? "1" : "0" ): "0",
                                BC = item.BC.HasValue ? (item.BC.Value ? "1" : "0") : "0",
                                AB = item.AB.HasValue ? (item.AB.Value ? "1" : "0") : "0",
                                SK = item.SK.HasValue ? (item.SK.Value ? "1" : "0") : "0",
                                MB = item.MB.HasValue ? (item.MB.Value ? "1" : "0") : "0",
                                ON = item.ON.HasValue ? (item.ON.Value ? "1" : "0") : "0",
                                QC = item.QC.HasValue ? (item.QC.Value ? "1" : "0") : "0",
                                NS = item.NS.HasValue ? (item.NS.Value ? "1" : "0") : "0",
                                NB = item.NB.HasValue ? (item.NB.Value ? "1" : "0") : "0",
                                NL = item.NL.HasValue ? (item.NL.Value ? "1" : "0") : "0",
                                PEI = item.PEI.HasValue ? (item.PEI.Value ? "1" : "0") : "0" 
                            }
                        );
            }

            return retVal;
        }

        public List<PCP_ActionItem> GetPCP_ActionItemReport()
        {
            List<PCP_ActionItem> retVal = new List<PCP_ActionItem>();

            foreach (var item in Entites.sp_Get_ActionItems_PCP())
            {
                retVal.Add
                        (
                            new PCP_ActionItem()
                            {
                                FirstName   = item.FirstName,
                                LastName    = item.LastName,
                                WorkPlace   = item.WorkPlace,
                                Address     = item.Address,
                                City        = item.City,
                                Province    = item.Province,
                                PostalCode  = item.PostalCode,
                                Phone       = item.Phone,
                                Fax         = item.Fax,
                                UserName    = item.UserName,
                                MOU         = item.MOU.HasValue ? item.MOU.Value ? "1" : "0" : "0",
                                Payee       = item.Payee.HasValue ? item.Payee.Value ? "1" : "0" : "0",
                                NeedsAsssesment = item.NeedsAsssesment.HasValue ? item.NeedsAsssesment.Value ? "1" : "0" : "0",
                                ePAF1       = item.ePAF1.Value,
                                eMAf1       = item.eMAf1
                            }

                        );
            }

            return retVal;
        }

    }
}
