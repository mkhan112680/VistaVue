using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using VistaDM.Web.Models;
using VistaDM.Web.App_Start;
using VistaDM.Web.Helpers;
using VistaDM.Data;

namespace VistaDM.Web
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    //public class ApplicationUserManager : UserManager<ApplicationUser>
    //{
    //    public ApplicationUserManager(IUserStore<ApplicationUser> store)
    //        : base(store)
    //    {
    //    }

    //    public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) 
    //    {
    //        var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
    //        // Configure validation logic for usernames
    //        manager.UserValidator = new UserValidator<ApplicationUser>(manager)
    //        {
    //            AllowOnlyAlphanumericUserNames = false,
    //            RequireUniqueEmail = true
    //        };

    //        // Configure validation logic for passwords
    //        manager.PasswordValidator = new PasswordValidator
    //        {
    //            RequiredLength = 6,
    //            RequireNonLetterOrDigit = true,
    //            RequireDigit = true,
    //            RequireLowercase = true,
    //            RequireUppercase = true,
    //        };

    //        // Configure user lockout defaults
    //        manager.UserLockoutEnabledByDefault = true;
    //        manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
    //        manager.MaxFailedAccessAttemptsBeforeLockout = 5;

    //        // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
    //        // You can write your own provider and plug it in here.
    //        manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
    //        {
    //            MessageFormat = "Your security code is {0}"
    //        });
    //        manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
    //        {
    //            Subject = "Security Code",
    //            BodyFormat = "Your security code is {0}"
    //        });
    //        manager.EmailService = new EmailService();
    //        manager.SmsService = new SmsService();
    //        var dataProtectionProvider = options.DataProtectionProvider;
    //        if (dataProtectionProvider != null)
    //        {
    //            manager.UserTokenProvider = 
    //                new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
    //        }
    //        return manager;
    //    }
    //}

    // Configure the application sign-in manager which is used in this application.
    //public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    //{
    //    public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
    //        : base(userManager, authenticationManager)
    //    {
    //    }

    //    public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
    //    {
    //        return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
    //    }

    //    public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
    //    {
    //        return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
    //    }
    //}

     public class ApplicationUserManager : UserManager<VistaUser>
    {
         public ApplicationUserManager(IUserStore<VistaUser> store)
             : base(store) 
        {
        }


         public override Task<VistaUser> FindAsync(string userName, string password)
         {
             //Logger.Log("ApplicationUserManager:FindAsync (userName = {0}, password = {1})", userName, password);
             return base.FindAsync(userName, password);
         }

         public override Task<VistaUser> FindByEmailAsync(string email)
         {
            // Logger.Log("ApplicationUserManager:FindAsync (email = {0})", email);
             return base.FindByEmailAsync(email);
         }

         public override Task<VistaUser> FindByNameAsync(string userName)
         {
             //Logger.Log("ApplicationUserManager:FindByNameAsync (userName = {0})", userName);
             return base.FindByNameAsync(userName);
         }

         protected override Task<bool> VerifyPasswordAsync(IUserPasswordStore<VistaUser, string> store, VistaUser user, string password)
         {
             //Logger.Log("ApplicationUserManager:VerifyPasswordAsync (user = {0}, password = {1})", user, password);
             //return base.VerifyPasswordAsync(store, user, password);

             bool retVal = false;

             retVal = user.PasswordHash == password;

             return Task.FromResult<bool>(retVal);
         }

         public override Task<bool> IsLockedOutAsync(string userId)
         {
             //Logger.Log("ApplicationUserManager:IsLockedOutAsync (userId = {0})", userId);
             //return base.IsLockedOutAsync(userId);
             return Task.FromResult<bool>(false);
         }

         public override Task<bool> GetTwoFactorEnabledAsync(string userId)
         {
             //Logger.Log("ApplicationUserManager:GetTwoFactorEnabledAsync (userId = {0})", userId);
             return Task.FromResult<bool>(false);
         }

         public override Task<string> GetSecurityStampAsync(string userId)
         {
             throw new NotImplementedException();
         }

         public override Task<IList<string>> GetRolesAsync(string userId)
         {
             throw new NotImplementedException();
         }

         public override Task<IList<Claim>> GetClaimsAsync(string userId)
         {
             throw new NotImplementedException();
         }

         public override Task<ClaimsIdentity> CreateIdentityAsync(VistaUser user, string authenticationType)
         {
             //Logger.Log("ApplicationUserManager:CreateIdentityAsync (user = {0}, authenticationType = {1})", user, authenticationType);
             ClaimsIdentity claims = new ClaimsIdentity(authenticationType);
             claims.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", user.Id));
             claims.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", user.UserName));
             claims.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", user.UserName));
             return Task.FromResult(claims);
         }

         public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
         {
             //Logger.Log("ApplicationUserManager:Create ()");
             string credfile = HttpContext.Current.Server.MapPath("~/App_Data/credentials.xml");
             var manager = new ApplicationUserManager(new UserStore());
             var dataProtectionProvider = options.DataProtectionProvider;
             if (dataProtectionProvider != null)
             {
                 manager.UserTokenProvider = new DataProtectorTokenProvider<VistaUser>(dataProtectionProvider.Create("ASP.NET Identity"));
             }
             return manager;
         }
    }


     // Configure the application sign-in manager which is used in this application.
     public class ApplicationSignInManager : SignInManager<VistaUser, string>
     {
         public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
             : base(userManager, authenticationManager)
         {
             //Logger.Log("ApplicationSignInManager:ApplicationSignInManager ()");
         }

         public override Task<ClaimsIdentity> CreateUserIdentityAsync(VistaUser user)
         {
             //Logger.Log("ApplicationSignInManager:CreateUserIdentityAsync (user = {0})", user);
             return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
         }

         public override Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout)
         {
             //Logger.Log("ApplicationSignInManager:PasswordSignInAsync (userName = {0}, password = {1}, isPersistent = {2}, shouldLockout = {3})",
                // userName, password, isPersistent, shouldLockout);
             return base.PasswordSignInAsync(userName,  password, isPersistent, shouldLockout);
         }

         public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
         {
             //Logger.Log("ApplicationSignInManager:Create ()");
             return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
         }
     }
}
