using BlazorAppSales.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModels
{
    public class InventoryTransaction
    {
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
    }

    public class Site
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property
        public ICollection<InventoryTransaction> InventoryTransactions { get; set; }
        public ICollection<Warehouse> warehouses { get; set; }
    }

    public class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property
        public ICollection<InventoryTransaction> InventoryTransactions { get; set; }


        [ForeignKey("Site")]

        public int Site_Id { get; set; }
        public Site site { get; set; }

    }




    public class InventoryCoverage
    {
        public Product Product { get; set; }
        public decimal InventoryQuantity { get; set; }
        public decimal SalesQuantity { get; set; }

        public decimal CoverageDays => InventoryQuantity > 0 ? InventoryQuantity / SalesQuantity : 0;
    }

}
