using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModels
{

    public class WebApp1User : IdentityUser
    {

        [PersonalData]
        public string Name { get; set; } = "";
        [PersonalData]
        public DateTime? DOB { get; set; }
        /*  public string ContactNumber { get; set; } = "";
          public string City { get; set; } = "";
          public string ERP_Account_Number { get; set; } = "";
          public string IBAN { get; set; } = "";
  */
        public string Mobile { get; set; } = "";
        public string CompanyName { get; set; } = "";
        public bool isActive { get; set; } = true;
        public string branch { get; set; } = "";



    }

    // /// <summary>
    // /// /https://stackoverflow.com/questions/60254430/obtain-list-of-roles-in-ef-core-3-1
    // /// </summary>
    // public class ApplicationUser : IdentityUser
    // {
    //     public string NickName { get; set; }
    //     public string address { get; set; }
    //     public string CR { get; set; }
    //     public string VAT { get; set; }
    //     [Required]
    //     [StringLength(30)]
    //     public string Mobile { get; set; }
    //     public string Mobile2 { get; set; }
    //     public string UserType { get; set; }
    //     public string ERP_Account_Number { get; set; }
    //     public string ERP_partner_Name { get; set; }
    //     public string IBAN { get; set; }
    //     public double CreditLimit { get; set; }
    //     public string WhatsAppNumber { get; set; }
    //     public byte[] logo { get; set; }
    //     public string WebsiteURL { get; set; }
    //     public string AgencyEmail { get; set; }
    //     public string PreferredLanguage { get; set; } = "en-US";
    //     public bool isAdmin { get; set; }
    //     public string CompanyName { get; set; }
    //     public string CompanyLandLine { get; set; }
    //     public string ContactName { get; set; }
    //     public string ContactNumber { get; set; }
    //     public string userTypeVendorCustomer { get; set; }
    //     public string Country { get; set; }
    //     public string City { get; set; }
    //     public string IDNumber { get; set; }
    //     public string cashierDefaultShop { get; set; }
    //     public string cashierDefaultMall { get; set; }
    //     // public ICollection<ApplicationUserRole> UserRoles { get; set; }
    //     public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }

    //     public bool isActive { get; set; } = true;
    //     public string txtSmsOnDeliveringToCustomer_customerMessage { get; set; }
    //     public string txtSmsOnDeliveringToCustomer_vendorMessage { get; set; }
    //     public string ExternalPassword { get; set; }
    //     public string fullNameHidden { get; set; }

    //     public bool sendMeNotificationsWithSms { get; set; } = true;
    //     public bool sendMeNotificationsWithEmail { get; set; } = true;
    //     public bool sendMeNotificationsWithTelegram { get; set; } = true;

    // }


    //// [TypeConverter(typeof(MyTypeConverter_ApplicationRole))]
    // public class ApplicationRole : IdentityRole
    // {
    //     // public ICollection<ApplicationUserRole> UserRoles { get; set; }
    //     public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    //     public override string ToString()
    //     {
    //         return base.ToString();
    //     }
    // }

    // public class MyTypeConverter_ApplicationRole : TypeConverter
    // {
    //     public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    //     {
    //         if (sourceType == typeof(string))
    //             return true;
    //         return base.CanConvertFrom(context, sourceType);
    //     }

    //     public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
    //     {
    //         object o_result;
    //         ApplicationDbContext db = new ApplicationDbContext();
    //         if (value.GetType() == typeof(string))
    //         {
    //             o_result = db.Roles.Where(r => r.Name == value).FirstOrDefault();
    //             return o_result;
    //         }
    //         return base.ConvertFrom(context, culture, value);
    //     }
    // }

    // public class ApplicationUserRole : IdentityUserRole<string>
    // {
    //     public virtual ApplicationUser User { get; set; }
    //     public virtual ApplicationRole Role { get; set; }

    //     public override string ToString()
    //     {
    //         return Role.ToString();
    //     }
    // }




}
