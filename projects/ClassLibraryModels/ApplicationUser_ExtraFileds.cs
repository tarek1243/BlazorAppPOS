using Microsoft.AspNetCore.Identity;

namespace ClassLibraryModels
{
    public class WebApp1User : IdentityUser
    {

        [PersonalData]
        public string Name { get; set; } = "";
        [PersonalData]
        public DateTime? DOB { get; set; }
        /*public string ContactNumber { get; set; } = "";
          public string City { get; set; } = "";
          public string ERP_Account_Number { get; set; } = "";
          public string IBAN { get; set; } = "";*/
        public string Mobile { get; set; } = "";
        public string CompanyName { get; set; } = "";
        public string VAT_number { get; set; } = "";
        public bool isActive { get; set; } = true;
        public string branch { get; set; } = "";
        public byte[] logo { get; set; }


    }

    // /// <summary>
    // /// /https://stackoverflow.com/questions/60254430/obtain-list-of-roles-in-ef-core-3-1
    // /// </summary>
     


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
