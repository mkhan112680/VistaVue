using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using VistaDM.Data;

namespace VistaDM.Web.App_Start
{
    public class VistaUser : IUser
    {
        public string Id
        {
            get;
            set;
        }
        public string UserName
        {
            get;
            set;
        }
        public string PasswordHash
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<VistaUser> manager)
        {
            //Logger.Log("SimpleUser:GenerateUserIdentityAsync ()");
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public override string ToString()
        {
            return string.Format("Id={0} Password={1}", Id, (PasswordHash == null ? string.Empty : PasswordHash));
        }
    }

    public class UserStore : IUserStore<VistaUser>, IUserPasswordStore<VistaUser>, IUserLockoutStore<VistaUser, object>
    {

        VistaDMEntities Entites = new VistaDMEntities();
        
        #region IUserStore

        public  Task CreateAsync(VistaUser user)
        {
            throw new NotImplementedException();
        }

        public  Task DeleteAsync(VistaUser user)
        {
            throw new NotImplementedException();
        }

        public  Task<VistaUser> FindByIdAsync(string userName)
        {
            VistaUser retUser = null;

            if (string.IsNullOrEmpty(userName))
            {
                retUser = null;
            }

            var user = Entites.Users.Where(x => x.Username == userName).SingleOrDefault();
            if (user != null)
            {
                retUser = new VistaUser() 
                                          {
                                                Id = user.ID.ToString(),  
                                                UserName = userName,
                                                PasswordHash = user.Password 
                                           };
            }
             
            return   Task.FromResult<VistaUser>(retUser);
        }

        public  Task<VistaUser> FindByNameAsync(string userName)
        {
           // return FindByIdAsync(userName);

            VistaUser retUser = null;

            if (string.IsNullOrEmpty(userName))
            {
                retUser = null;
            }

            var user = Entites.Users.Where(x => x.Username == userName).SingleOrDefault();
            if (user != null)
            {
                retUser = new VistaUser()
                {
                    Id = user.ID.ToString(),
                    UserName = userName,
                    PasswordHash = user.Password
                };
            }

            return Task.FromResult<VistaUser>(retUser);
        }

        public  Task UpdateAsync(VistaUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserPasswordStore

        public  Task<string> GetPasswordHashAsync(VistaUser user)
        {
            string hash = user.PasswordHash ;
            return Task.FromResult<string>(hash);
        }

        public  Task<bool> HasPasswordAsync(VistaUser user)
        {
            throw new NotImplementedException();
        }

        public  Task SetPasswordHashAsync(VistaUser user, string passwordHash)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserLockoutStore

        public Task<int> GetAccessFailedCountAsync(VistaUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetLockoutEnabledAsync(VistaUser user)
        {
            throw new NotImplementedException();
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(VistaUser user)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(VistaUser user)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(VistaUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEnabledAsync(VistaUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(VistaUser user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        #endregion 

        public Task<VistaUser> FindByIdAsync(object userId)
        {
            throw new NotImplementedException();
        }
    }
}