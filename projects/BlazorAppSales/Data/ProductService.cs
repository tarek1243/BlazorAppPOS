using BlazorAppSales.Data;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Services
{
    public class ProductService
    {
        private List<Product> products;
        private readonly DbContextMainData dbContext = new DbContextMainData();

        public async Task<List<Product>> GetProductsAsync()
        {
            // Your code to retrieve products from the database goes here
            // For example:
            products = await dbContext.Pos_Products.Include(p => p.ProductTags).ToListAsync();
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
             dbContext.Pos_Products.Attach (product);
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
    }
}

