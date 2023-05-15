using BlazorAppSales.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibraryModels
{
    public class InventoryTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductId { get; set; }
        [Column(TypeName = "decimal(18,2)")]

        public decimal Quantity { get; set; }
        public DateTime TransactionDate { get; set; }

        // Foreign key relationships
        [ForeignKey("Site")]

        public int SiteId { get; set; }
        [ForeignKey("Warehouse")]

        public int WarehouseId { get; set; }

        // Navigation properties
        public Site Site { get; set; }
        public Warehouse Warehouse { get; set; }
        public Product Product { get; set; }

        public string? CompanyName { get; set; } = "";
        public string? created_by_user_email { get; set; } = "";

    }

    public class Site
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property
        public ICollection<InventoryTransaction> InventoryTransactions { get; set; }
        public ICollection<Warehouse> warehouses { get; set; }
        public string? CompanyName { get; set; } = "";
        public string? created_by_user_email { get; set; } = "";

    }

    public class Warehouse
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property
        public ICollection<InventoryTransaction> InventoryTransactions { get; set; }


        [ForeignKey("Site")]

        public int Site_Id { get; set; }
        public Site site { get; set; }
        public string? CompanyName { get; set; } = "";
        public string? created_by_user_email { get; set; } = "";


    }



/*
    public class InventoryCoverage
    {
        public Product Product { get; set; }
        public decimal InventoryQuantity { get; set; }
        public decimal SalesQuantity { get; set; }

        public decimal CoverageDays => InventoryQuantity > 0 ? InventoryQuantity / SalesQuantity : 0;
        public string? CompanyName { get; set; } = "";
        public string? created_by_user_email { get; set; } = "";


    }*/

}
