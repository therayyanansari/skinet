using System.Text.Json;
using Core.Entities;
using SQLitePCL;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync (StoreContext context)
        {
            if (!context.Products.Any())
            {
                var allProducts = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(allProducts);
                context.Products.AddRange(products);
            }
            
            if (!context.ProductBrands.Any())
            {
                var allProductsBrands = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(allProductsBrands);
                context.ProductBrands.AddRange(brands);
            }
            
            if (!context.ProductTypes.Any())
            {
                var allProductsType = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var productsTypes = JsonSerializer.Deserialize<List<ProductType>>(allProductsType);
                context.ProductTypes.AddRange(productsTypes);
            }

            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }
    }
}