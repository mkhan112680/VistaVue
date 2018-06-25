using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VistaDM.Domain;

namespace VistaDM.Repository
{
    public class UserRepository : BaseRepository
    {
        public UserRepository()
        {
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

        public string GetSponserPassword(string userName)
        {
            string retVal = string.Empty;

            var row = Entites.sp_GetSponserDetails_UserName(userName).SingleOrDefault();
            if (row != null)
            {
                retVal = row.Password.ToString();
            }

            return retVal;
        }

    }
}
