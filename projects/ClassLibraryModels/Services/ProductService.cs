using Microsoft.EntityFrameworkCore;

namespace BlazorAppSales.Data
{




    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        //   Task<Product> UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
        /* Task<List<ProductTag>> GetProductTagsAsync();
         Task<List<Product>> GetProductsWithTagAsync(string tagName);
         Task<List<string>> GetProductTagNamesWithProductsAsync();
         Task<List<ProductVariantType>> GetProductVariantTypesAsync();
         Task<List<ProductVariantValue>> GetProductVariantValuesByTypeIdAsync(int typeId);
         Task<ProductVariantValue> GetProductVariantValueByIdAsync(int id);
         Task<ProductVariantValue> CreateProductVariantValueAsync(ProductVariantValue productVariantValue);
         Task<ProductVariantValue> UpdateProductVariantValueAsync(ProductVariantValue productVariantValue);
         Task DeleteProductVariantValueAsync(int id);*/
        /*        Task<List<ProductVariant>> GetProductVariantsByProductIdAsync(int productId);
                Task<List<ProductVariant>> GetProductVariantsByProductVariantTypeIdAsync(int productVariantTypeId);
                Task<ProductVariant> GetProductVariantByIdAsync(int id);
                Task<ProductVariant> CreateProductVariantAsync(ProductVariant productVariant);
                Task<ProductVariant> UpdateProductVariantAsync(ProductVariant productVariant);*/
        Task DeleteProductVariantAsync(int id);
    }




    public class ProductService : IProductService
    {
        private List<Product> products;
        private readonly DbContextMainData dbContext = new DbContextMainData();

        public async Task<List<Product>> GetProductsAsync()
        {
            // Your code to retrieve products from the database goes here
            // For example:
            products = await dbContext.Pos_Products
                .Include(p => p.ProductTags)
                .Include(p => p.RelatedProducts)
                .ToListAsync();
            return products;
        }


        public async Task<List<Product>> GetProductsAsNoTrackingAsync()
        {
            // Your code to retrieve products from the database goes here
            // For example:
            products = await dbContext.Pos_Products.AsNoTracking()
                .Include(p => p.ProductTags)
                .Include(p => p.RelatedProducts)
                .ToListAsync();
            return products;
        }

        public async Task<List<string>> GetProductsTagsAsync()
        {
            // Your code to retrieve products from the database goes here
            // For example:
            var productTags = await dbContext.Pos_ProductTags

                .Select(m => m.Name).Distinct().ToListAsync();
            return productTags;
        }

        public async Task<List<ProductTag>> GetProductTagsWithProducts()
        {
            var tags = await dbContext.Pos_ProductTags
                .Include(tag => tag.Products)
                .ToListAsync();

            var distinctTags = tags
                .SelectMany(tag => tag.Products.Select(product => tag))
                .Distinct()
                .ToList();

            return distinctTags;
        }


        public async Task UpdateProduct(Product product)
        {
            // Your code to update the product in the database goes here
            // For example:
            dbContext.Pos_Products.Attach(product);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            dbContext.Pos_Products.Add(product);
            await dbContext.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await dbContext.Pos_Products.FindAsync(id);
            dbContext.Pos_Products.Remove(product);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            //dbContext = new DbContextMainData();
            return await dbContext.Pos_Products
                .Where(p => p.Id == id)
    .FirstOrDefaultAsync();
        }

        public Task DeleteProductVariantAsync(int id)
        {
            throw new NotImplementedException();
        }
    }

}

