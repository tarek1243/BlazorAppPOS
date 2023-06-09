﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ClassLibraryModels;

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
        public decimal Paid_Total_With_VAT { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]

        public decimal unPaid_remaining_Total_With_VAT { get; set; } = 0;


        [Column(TypeName = "decimal(18,2)")]
        public decimal VAT_Amount { get; set; } = 0;
        [ForeignKey("Customer")]

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
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



        [ForeignKey("user")]
        public string? userId { get; set; }
        public WebApp1User? user { get; set; }

        public string EmployeeNumber { get; set; } = "";
        public string EmployeeName { get; set; } = "";

    }



    public class OrderLine
    {
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int product_id { get; set; }
        public Product Product { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantity { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; } = 0;

        public bool IsSupplementary { get; set; } = false; 
    }



    public class Pos_OrderPayment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("order")]
        public int OrderId { get; set; }
        public Order order { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [ForeignKey("pos_MethodOfPayment")]
        public int MethodOfPaymentId { get; set; }
        public Pos_MethodOfPayment pos_MethodOfPayment { get; set; }

    }





    public class ProductVariantType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductVariantValue> Values { get; set; }
    }

    public class ProductVariantValue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int VariantTypeId { get; set; }
        public ProductVariantType VariantType { get; set; }
    }

}
