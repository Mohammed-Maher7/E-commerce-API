using E_commerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_commerce.Repository.Data
{
    public static class StoreCotextSeed
    {
        public async static Task SeedAsync(StoreContext _dbContext) 
        {
            if (_dbContext.productBrands.Count() == 0) 
            {
                var brandsData = File.ReadAllText("../E-commerce.Repository/Data/DataSeed/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                if (brands?.Count() > 0)
                {
                    foreach (var brand in brands)
                    {
                        _dbContext.Set<ProductBrand>().Add(brand);
                    }
                    await _dbContext.SaveChangesAsync(); 
                }
            }

            if (_dbContext.productCategories.Count() == 0) 
            {
                var categoriesData = File.ReadAllText("../E-commerce.Repository/Data/DataSeed/categories.json");
                var categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoriesData);

                if (categories?.Count() > 0)
                {
                    foreach (var category in categories)
                    {
                        _dbContext.Set<ProductCategory>().Add(category);
                    }
                    await _dbContext.SaveChangesAsync(); 
                }
            }

            if (_dbContext.products.Count() == 0) 
            {
                var productsData = File.ReadAllText("../E-commerce.Repository/Data/DataSeed/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                if (products?.Count() > 0)
                {
                    foreach (var product in products)
                    {
                        _dbContext.Set<Product>().Add(product);
                    }
                    await _dbContext.SaveChangesAsync(); 
                }
            }
           
        }
    }
}
