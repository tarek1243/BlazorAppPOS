using BlazorAppSales.Areas.Identity;
using BlazorAppSales.Data;
using ClassLibraryModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppSales
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ClassLibraryModels.ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();


            //builder.Services.AddDefaultIdentity<ClassLibraryModels.ApplicationUser/*IdentityUser*/>(options =>
            builder.Services.AddDefaultIdentity<WebApp1User>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.SignIn.RequireConfirmedAccount = false; // new email for confirmation
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            }

            ).AddEntityFrameworkStores<ClassLibraryModels.ApplicationDbContext>();
            //builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();








  


            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            /* builder.Services.AddSingleton<WeatherForecastService>();*/

           builder.Services.AddTransient<OrderService>();


            //.AddEntityFrameworkStores<ApplicationDbContext>()
            ///added for testing only
            //.AddDefaultTokenProviders()
            //.AddDefaultUI() ///to fix iemailSender issue
            ;

            //builder.Services.Configure<RazorPagesOptions>(options => options.RootDirectory = "/Pages");
            //builder.Services.Configure<RazorPagesOptions>(options => options.RootDirectory = "/BlazorAppSales/Pages");




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}