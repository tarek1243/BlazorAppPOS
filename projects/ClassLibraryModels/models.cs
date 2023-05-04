using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace BlazorAppSales.Data
{
    /*
    dotnet ef migrations add modDb120 --context    DbContextMainData
    dotnet ef database update --context DbContextMainData
    dotnet ef migrations remove --context DbContextMainData
    */

    public class DbContextMainData : DbContext
    {
        public DbContextMainData()
        {
        }
        public DbContextMainData(DbContextOptions<DbContextMainData> options)
    : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-H7EA1N4;Initial Catalog=blazorPos;Integrated Security=True;TrustServerCertificate=True");
            }
        }

        public virtual DbSet<Company> Pos_Companies { get; set; }
        public virtual DbSet<Product> Pos_Products { get; set; }
        public DbSet<ProductTag> Pos_ProductTags { get; set; }
        public virtual DbSet<Order> Pos_Orders { get; set; }
        public virtual DbSet<Customer> Pos_Customers { get; set; }
        public virtual DbSet<Shift> Pos_Shifts { get; set; }
        // Add a new table for storing the last invoice number used for each company
        public DbSet<CompanyInvoiceNumber> CompanyInvoiceNumbers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships and constraints
            // ...

            // Seed data for the company invoice numbers
            modelBuilder.Entity<CompanyInvoiceNumber>()
                .HasData(
                    new CompanyInvoiceNumber { Id = 1, CompanyId = 1, LastInvoiceNumber = 0 },
                    new CompanyInvoiceNumber { Id = 2, CompanyId = 2, LastInvoiceNumber = 0 }
                );

            // This allows for a many-to - many relationship between Product and ProductTag
            modelBuilder.Entity<ProductTag>()
    .HasKey(pt => pt.Id);

            modelBuilder.Entity<ProductTag>()
                .HasMany(pt => pt.Products)
                .WithMany(p => p.ProductTags)
                .UsingEntity(j => j.ToTable("ProductProductTag"));




            /*            modelBuilder.Entity<Product>()
                        .HasMany(e => e.RelatedProducts)
                        .WithOne(e => e.ParentProduct)
                        .OnDelete(DeleteBehavior.SetNull);*/
        }

        /* 
         * dotnet ef migrations add modDb099 --context DbContextMainData
  dotnet ef database update --context DbContextMainData
         */
    }

    // Company model
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; }
        //public List<string> Tags { get; set; } = new List<string>();
    }

    public class CompanyInvoiceNumber
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int LastInvoiceNumber { get; set; }
    }


    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total_With_VAT { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal VAT_Amount { get; set; } = 0;
        public List<CartItem> Items { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string customer_name { get; set; } = "";
        public Shift  shift { get; set; }
        [ForeignKey("shift")]
        public int shift_Id { get; set; }
        public int InvoiceNumber { get; set; }
        public Company  company { get; set; }
        [ForeignKey("company")]
        public int CompanyId { get; set; }
        public string company_name { get; set; } = "";
        public bool ShowLines { get; set; } = false;
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = "";
        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal LineAmount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
    }

    public class Shift
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime OpenedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalSales { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPayments { get; set; }
        public bool IsOpen { get; set; }
        public string EmployeeNumber { get; set; } = "";
        public string Branch { get; set; }
        public string CompanyName { get; set; }
        public List<Order> Orders { get; set; }
        public bool ShowLines { get; set; } = false;
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
        public int Id { get; set; }
        public string? Name { get; set; } = "";
        public string? Email { get; set; } = "";
        public string? Phone { get; set; } = "";
        public string? CustGroup { get; set; } = "";
        public List<Order> Orders { get; set; }
        //public List<string> Tags { get; set; } = new List<string>();

        public override string ToString()
        {
            return Id.ToString();
        }
    }

    public class CartItem
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
    }

}
