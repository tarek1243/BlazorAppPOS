using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppSales.Data
{

    [TypeConverter(typeof(ProductTypeConverter))]

    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int? CompanyId { get; set; }
        public string? CompanyName { get; set; } = "";
        public Company Company { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        //public List<string> Tags { get; set; } = new List<string>();
        public List<ProductTag>? ProductTags { get; set; }
        //public List<Product> RelatedProducts { get; set; }

        [InverseProperty("Parent_Product")]
        public ICollection<RelatedProduct> RelatedProducts { get; set; }
        public byte[]? logo { get; set; }

        public bool ShowLines { get; set; } = false;


        // [InverseProperty("Parent_Product")]
        //public ICollection<RelatedProduct> ParentProducts { get; set; }
        public override string ToString()
        {
            return Id.ToString();
        }
    }

    public class RelatedProduct
    {
        public int Id { get; set; }
        public string notes { get; set; } = ""; 
        [ForeignKey("Parent_Product")]
        public int Parent_ProductId { get; set; }
        public Product Parent_Product { get; set; }


        [ForeignKey("Related_Product")]
        public int Related_ProductId { get; set; }
        public Product Related_Product { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Qty { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal RelatedTotal { get; set; } = 0;
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







    public class ProductTypeConverter : TypeConverter//<string, Product>
    {
        private readonly IProductService _productService;

        public ProductTypeConverter(IProductService productService)
        {
            _productService = productService;
        }
        public ProductTypeConverter( )
        {
            _productService = new ProductService();
        }
        /*        public override bool CanConvertFrom(Type sourceType)
                {
                    return sourceType == typeof(string);
                }*/

        //public override bool CanConvertTo(Type destinationType)
        //{
        //    return destinationType == typeof(Product);
        //}

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;

            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            int productId = int.Parse(value.ToString());
            return _productService.GetProductByIdAsync( productId);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value == null)
            {
                
                DbContextMainData dbContextMainData = new DbContextMainData();
                return dbContextMainData.Pos_Products.FirstOrDefault().ToString();

            }
            Product product = (Product)value;
            return product.Id.ToString();
        }
    }

}
