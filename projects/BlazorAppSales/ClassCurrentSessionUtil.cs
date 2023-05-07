using ClassLibraryModels;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Util
{
    public class ClassCurrentSessionUtil
    {


        //important
        /*        public static async Task<bool> CheckIfUserHasRole(
                    AuthenticationStateProvider authenticationStateProvider
                 , ApplicationDbContext dbContext,
                    string roleName)
                {
                    string email = "";
                    var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
                    System.Collections.Generic.ICollection<ApplicationUserRole> roles;
                    if (authState.User.Identity.IsAuthenticated)
                    {
                        email = authState.User.Identity.Name;
                        var c = dbContext.Users.Where(u => u.UserName == email)
                            .Include(u => u.UserRoles).ThenInclude(ur => ur.Role).ToList();
                        roles = c[0].UserRoles;
                        foreach (ApplicationUserRole ur in roles)
                        {
                            if (ur.Role.Name.Contains(roleName))
                                return true;
                        }
                    }
                    return false;
                }


              
  public static async Task<List<ApplicationUserRole>> getUserRolesAsync(
                 AuthenticationStateProvider authenticationStateProvider
              , ApplicationDbContext dbContext )
                {
                    string email = "";
                    var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
                    if (authState.User.Identity.IsAuthenticated)
                    {

                        email = authState.User.Identity.Name;
                        var c = dbContext.Users.Where(u => u.UserName == email).Include(u => u.UserRoles).ThenInclude(ur => ur.Role).ToList();
                        return c[0].UserRoles.ToList();
                    }
                    else return null ; // new  List<ApplicationRole>();
                }

        */

        // @inject AuthenticationStateProvider AuthenticationStateProvider
        //Util.ClassCurrentSessionUtil.GetUserEmail

        public static async Task<string> GetUserEmail(AuthenticationStateProvider authenticationStateProvider          )
        {
            // @inject AuthenticationStateProvider AuthenticationStateProvider
            string email = "";
            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            if (authState.User.Identity.IsAuthenticated)
            {
                email = authState.User.Identity.Name;
            }
            return email;
        }



        public static async Task<string> GetUserMobile(AuthenticationStateProvider authenticationStateProvider
          , ApplicationDbContext dbContext
           )
        {
            string email = "";
            string mobile = "";
            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            if (authState.User.Identity.IsAuthenticated)
            {
                email = authState.User.Identity.Name;
                var user = dbContext.Users.Where(u => u.Email == email).FirstOrDefault();
                if (user != null)
                    mobile = user.Mobile;
            }
            return mobile;
        }



       



        public static async Task<bool> GetUserIsActive(AuthenticationStateProvider authenticationStateProvider
        , ApplicationDbContext dbContext
         )
        {
            string email = "";
            bool result = false;
            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            if (authState.User.Identity.IsAuthenticated)
            {
                email = authState.User.Identity.Name;
                var user = dbContext.Users.Where(u => u.Email == email).FirstOrDefault();
                if (user != null)
                    result = user.isActive;
            }
            return result;
        }



        public static async Task<WebApp1User> GetUser(AuthenticationStateProvider authenticationStateProvider
        , ApplicationDbContext dbContext
         )
        {
            string email = "";
            WebApp1User result  =new WebApp1User();
            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            if (authState.User.Identity.IsAuthenticated)
            {
                email = authState.User.Identity.Name;
               // email = (new System.Collections.Generic.List<System.Security.Claims.ClaimsIdentity>(authState.User.Identities)[0]).Name;
                var user = dbContext.Users.Where(u => u.Email == email).FirstOrDefault();
                if (user != null)
                    result = user;
            }
            return result;
        }



     /*   public static async Task<string> GetUserDefaultContactNumber(AuthenticationStateProvider authenticationStateProvider
         , ApplicationDbContext dbContext
          )
        {
            string email = "";
            string result = "";
            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            if (authState.User.Identity.IsAuthenticated)
            {
                email = authState.User.Identity.Name;
                var user = dbContext.Users.Where(u => u.Email == email).FirstOrDefault();
                if (user != null)
                    result = user.ContactNumber;
            }
            return result;
        }*/



       /* public static async Task<string> GetUserDefaultCity(AuthenticationStateProvider authenticationStateProvider
         , ApplicationDbContext dbContext
          )
        {
            string email = "";
            string result = "";
            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            if (authState.User.Identity.IsAuthenticated)
            {
                email = authState.User.Identity.Name;
                var user = dbContext.Users.Where(u => u.Email == email).FirstOrDefault();
                if (user != null)
                    result = user.City;
            }
            return result;
        }*/



        


/*        public static async Task<string> GetUserAccountNumber(AuthenticationStateProvider authenticationStateProvider
           , ApplicationDbContext dbContext
            )
        {
            // @inject AuthenticationStateProvider AuthenticationStateProvider
            string email = "";
            string accountNumber = "";
            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            if (authState.User.Identity.IsAuthenticated)
            {
                email = authState.User.Identity.Name;
                var user = dbContext.Users.Where(u => u.Email == email).FirstOrDefault();
                if (user != null)
                    accountNumber = user.ERP_Account_Number;
                //db.Partners.Where(p => p.email == email).FirstOrDefault().accountNumber;
            }
            return accountNumber;
        }*/






        public static async Task<string> GetUserCompanyName(AuthenticationStateProvider authenticationStateProvider
         , ApplicationDbContext dbContext
          )
        {
            string email = "";
            string CompanyName = "";
            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            if (authState.User.Identity.IsAuthenticated)
            {
                email = authState.User.Identity.Name;
                var user = dbContext.Users.Where(u => u.Email == email).FirstOrDefault();
                if (user != null)
                    CompanyName = user.CompanyName;
                //db.Partners.Where(p => p.email == email).FirstOrDefault().accountNumber;
            }
            return CompanyName;
        }


  /*      public static async Task<string> GetUserIBAN(AuthenticationStateProvider authenticationStateProvider
         , ApplicationDbContext dbContext
          )
        {
            string email = "";
            string CompanyName = "";
            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            if (authState.User.Identity.IsAuthenticated)
            {
                email = authState.User.Identity.Name;
                var user = dbContext.Users.Where(u => u.Email == email).FirstOrDefault();
                if (user != null)
                    CompanyName = user.IBAN;
                //db.Partners.Where(p => p.email == email).FirstOrDefault().accountNumber;
            }
            return CompanyName;
        }*/

/*        public static string GetUserContactName(string email)
        {
            if (email == "") return "";

            string userContactName = "";
            ApplicationDbContext applicationDbContext = new ApplicationDbContext();
            userContactName = applicationDbContext.Users.Where(u => u.Email == email).FirstOrDefault().ContactName;
            return userContactName;
        }*/



 


    }
}
