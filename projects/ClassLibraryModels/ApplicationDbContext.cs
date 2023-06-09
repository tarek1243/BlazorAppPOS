
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClassLibraryModels
{
    /*
    dotnet ef --startup-project ../BlazorAppSales/ migrations add myMigration01
    dotnet ef --startup-project ../BlazorAppSales/ database update

    dotnet ef database update
dotnet ef migrations add appdb1 --context    DbContextMainData
dotnet ef database update --context DbContextMainData
dotnet ef migrations remove --context DbContextMainData

*/


/*
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>*/
   
    public class ApplicationDbContext : IdentityDbContext<WebApp1User>
    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
/*    public class ApplicationDbContext : IdentityDbContext*/
    {
        public ApplicationDbContext()
        {        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-H7EA1N4;Initial Catalog=blazorPos;Integrated Security=True;TrustServerCertificate=True");
                optionsBuilder.UseSqlServer("Data Source=atsqll.database.windows.net;Initial Catalog=NamaaBlazor;Persist Security Info=True;User ID=at;Password=Adminpass@$");
            }
        }
    }

/* 
   public class ApplicationUserRole : IdentityUserRole<string>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual IdentityRole Role { get; set; }

        public override string ToString()
        {
            return Role.ToString();
        }
    }*/

}