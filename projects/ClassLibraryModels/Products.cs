using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorAppSales.Data
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        //public List<string> Tags { get; set; } = new List<string>();
        public List<ProductTag>? ProductTags { get; set; }
        //public List<Product> RelatedProducts { get; set; }
        public ICollection<RelatedProduct> RelatedProducts { get; set; }
    }

    public class RelatedProduct
    {
        public int Id { get; set; }
        public string notes { get; set; } = "";
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Qty { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } = 0;
    }

    public class ProductTag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }

}
