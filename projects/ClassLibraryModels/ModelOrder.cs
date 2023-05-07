using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorAppSales.Data
{
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
        public DateTime? created_Date { get; set; } = DateTime.Now;

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
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string customer_name { get; set; } = "";
        public Shift shift { get; set; }
        [ForeignKey("shift")]
        public int shift_Id { get; set; }
        public int InvoiceNumber { get; set; }
        public Company company { get; set; }
        [ForeignKey("company")]
        public int CompanyId { get; set; }
        public string company_name { get; set; } = "";
        public bool ShowLines { get; set; } = false;
        public DateTime? created_Date { get; set; } = DateTime.Now;
        public int LoyaltyPointsEarned { get; set; }

        public List<OrderLine> OrderLines { get; set; }
        public List<Pos_OrderPayment>  Pos_OrderPayments { get; set; }

        public bool IsPaid { get; set; } = false;
        public DateTime? PaidAt { get; set; } 




    }



    public class OrderLine
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



    public class Pos_OrderPayment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order order { get; set; }
        public decimal Amount { get; set; }
        public int MethodOfPaymentId { get; set; }
        public Pos_MethodOfPayment pos_MethodOfPayment { get; set; }
    }
}
