using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VistaDM.Domain;

namespace VistaDM.Repository
{
    public class SponserRepository : BaseRepository
    {
        public void Register(SponserUser user )
        {
            Entites.sp_RegisterSponser(

                user.FirstName ,
                user.LastName ,
                user.Company.ID ,
                user.Role.ID,

                user.TerritoryCovergae_All.Value ? 1: 0,
                user.TerritoryCovergae_BC.Value ? 1 : 0,
                user.TerritoryCovergae_AB.Value ? 1 : 0,
                user.TerritoryCovergae_SK.Value ? 1 : 0,
                user.TerritoryCovergae_MB.Value ? 1 : 0,
                user.TerritoryCovergae_ON.Value ? 1 : 0,
                user.TerritoryCovergae_QC.Value ? 1 : 0,
                user.TerritoryCovergae_NS.Value ? 1 : 0,
                user.TerritoryCovergae_NB.Value ? 1 : 0,
                user.TerritoryCovergae_NL.Value ? 1 : 0,
                user.TerritoryCovergae_PEI.Value ? 1 : 0,

                user.Username,
                user.Password

                );
        }

        public bool Authenticate(string userName , string password)
        {
            
            bool IsAuthenticated = Entites.sp_AuthenticateSponser(userName, password).FirstOrDefault().Value == 1;
            return IsAuthenticated;
        }

        public SponserUser GetDetails(int userID)
        {
            SponserUser retUser = new SponserUser();

            var item = Entites.sp_GetSponserDetails(userID).SingleOrDefault();
            if (item != null)
            {
                retUser.UserID                  = item.UserID.Value;
                retUser.Company                 = new Company() {  ID= item.CompanyID.Value, Name=item.CompanyName };
                retUser.Role                    = new Role() { ID = item.RoleID.Value, Name = item.RoleName };
                retUser.Username                = item.Username;
                retUser.Password                = item.Password;
                retUser.FirstName               = item.FirstName;
                retUser.LastName                = item.LastName;
                retUser.TerritoryCovergae_All   = item.TerritoryCovergae_All.HasValue ? item.TerritoryCovergae_All.Value : false;
                retUser.TerritoryCovergae_BC    = item.TerritoryCovergae_BC.HasValue  ? item.TerritoryCovergae_BC.Value  : false;
                retUser.TerritoryCovergae_AB    = item.TerritoryCovergae_AB.HasValue  ? item.TerritoryCovergae_AB.Value  : false;
                retUser.TerritoryCovergae_SK    = item.TerritoryCovergae_SK.HasValue  ? item.TerritoryCovergae_SK.Value  : false;
                retUser.TerritoryCovergae_MB    = item.TerritoryCovergae_MB.HasValue  ? item.TerritoryCovergae_MB.Value  : false;
                retUser.TerritoryCovergae_ON    = item.TerritoryCovergae_ON.HasValue  ? item.TerritoryCovergae_ON.Value  : false;
                retUser.TerritoryCovergae_QC    = item.TerritoryCovergae_QC.HasValue  ? item.TerritoryCovergae_QC.Value  : false;
                retUser.TerritoryCovergae_NS    = item.TerritoryCovergae_NS.HasValue  ? item.TerritoryCovergae_NS.Value  : false;
                retUser.TerritoryCovergae_NB    = item.TerritoryCovergae_NB.HasValue  ? item.TerritoryCovergae_NB.Value  : false;
                retUser.TerritoryCovergae_NL    = item.TerritoryCovergae_NL.HasValue  ? item.TerritoryCovergae_NL.Value  : false;
                retUser.TerritoryCovergae_PEI   = item.TerritoryCovergae_PEI.HasValue ? item.TerritoryCovergae_PEI.Value : false;

            }

            return retUser;
        }

        public SponserUser GetDetailsByUsername(string userName)
        {
            SponserUser retUser = new SponserUser();

            var item = Entites.sp_GetSponserDetails_UserName(userName).SingleOrDefault();
            if (item != null)
            {
                retUser.UserID = item.UserID.Value;
                retUser.Company = new Company() { ID = item.CompanyID.Value, Name = item.CompanyName };
                retUser.Role = new Role() { ID = item.RoleID.Value, Name = item.RoleName };
                retUser.Username = item.Username;
                retUser.Password = item.Password;
                retUser.FirstName = item.FirstName;
                retUser.LastName = item.LastName;
                retUser.TerritoryCovergae_All = item.TerritoryCovergae_All.HasValue ? item.TerritoryCovergae_All.Value : false;
                retUser.TerritoryCovergae_BC = item.TerritoryCovergae_BC.HasValue ? item.TerritoryCovergae_BC.Value : false;
                retUser.TerritoryCovergae_AB = item.TerritoryCovergae_AB.HasValue ? item.TerritoryCovergae_AB.Value : false;
                retUser.TerritoryCovergae_SK = item.TerritoryCovergae_SK.HasValue ? item.TerritoryCovergae_SK.Value : false;
                retUser.TerritoryCovergae_MB = item.TerritoryCovergae_MB.HasValue ? item.TerritoryCovergae_MB.Value : false;
                retUser.TerritoryCovergae_ON = item.TerritoryCovergae_ON.HasValue ? item.TerritoryCovergae_ON.Value : false;
                retUser.TerritoryCovergae_QC = item.TerritoryCovergae_QC.HasValue ? item.TerritoryCovergae_QC.Value : false;
                retUser.TerritoryCovergae_NS = item.TerritoryCovergae_NS.HasValue ? item.TerritoryCovergae_NS.Value : false;
                retUser.TerritoryCovergae_NB = item.TerritoryCovergae_NB.HasValue ? item.TerritoryCovergae_NB.Value : false;
                retUser.TerritoryCovergae_NL = item.TerritoryCovergae_NL.HasValue ? item.TerritoryCovergae_NL.Value : false;
                retUser.TerritoryCovergae_PEI = item.TerritoryCovergae_PEI.HasValue ? item.TerritoryCovergae_PEI.Value : false;

            }

            return retUser;
        }

        public SponserUser GetAdminDetails(string userName)
        {
            SponserUser retUser = new SponserUser();

            retUser.Username = userName;
            retUser.FirstName = "admin";
            retUser.LastName = "admin";
            retUser.TerritoryCovergae_All = true;
            retUser.TerritoryCovergae_BC = true;
            retUser.TerritoryCovergae_AB = true;
            retUser.TerritoryCovergae_SK = true;
            retUser.TerritoryCovergae_MB = true;
            retUser.TerritoryCovergae_ON = true;
            retUser.TerritoryCovergae_QC = true;
            retUser.TerritoryCovergae_NS = true;
            retUser.TerritoryCovergae_NB = true;
            retUser.TerritoryCovergae_NL = true;
            retUser.TerritoryCovergae_PEI = true;
            retUser.IsAdmin = true;
            
            return retUser;
        }

        public string[] GetRolesAsArray(string userName)
        {
            //return Entites.Users.First(u => u.Username == userName).Roles.Select(r => r.Name).ToArray();

            List<string> cities = new List<string>();
            cities.Add("New York");
            cities.Add("Mumbai");
            cities.Add("Berlin");
            cities.Add("Istanbul");


            return cities.ToArray();

        }
    }
}
