using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Globalization;

namespace BlazorAppSales.Data
{


    public class Pos_MethodOfPayment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? CompanyName { get; set; } = "";

        /*       public bool AllowsPartialPayment { get; set; }
               public bool IsChangeProvider { get; set; }*/
    }

    public class CustomerTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            /* var strValue = value as string;
             if (strValue != null)
             {
                 var parts = strValue.Split(',');
                 if (parts.Length == 3)
                 {
                     db.Customers.Where
                     return new Customer
                     {
                         Id = int.Parse(parts[0]),
                         Name = parts[1],
                         Email = parts[2]
                     };
                 }
             }*/

            DbContextMainData db = new DbContextMainData();
            Customer customer = null;
            customer = db.Pos_Customers.Where(c => c.Id == int.Parse(value.ToString())).FirstOrDefault();

            return customer; //  return (Customer)value; ///base.ConvertFrom(context, culture, value);
        }
    }

    // Customer model
    [TypeConverter(typeof(CustomerTypeConverter))]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; } = "";
        public string? Email { get; set; } = "";
        public string? Phone { get; set; } = "";
        public string? CustGroup { get; set; } = "";
        public string? CompanyName { get; set; } = "";
        public List<Order> Orders { get; set; }
        //public List<string> Tags { get; set; } = new List<string>();
        public DateTime? created_Date { get; set; } = DateTime.Now;
        public bool ShowLines { get; set; } = false;
        public int LoyaltyPoints { get; set; } = 0; // new field for loyalty points


        public override string ToString()
        {
            return Id.ToString();
        }
    }

}
