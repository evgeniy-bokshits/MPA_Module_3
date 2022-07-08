using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;

using Core.Infrastructure.Models;
using DAL.DBContexts.CatalogDBContext;

namespace DAL.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogDbContext _dbContext;

        public ProductRepository(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(a => a.Id == id);
            if (product is null)
            {
                throw new Exception("Product was not found");
            }

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public Task<Product> GetProduct(int id)
        {
            return _dbContext.Products.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Product> UpdateProduct(Product category)
        {
            _dbContext.Products.AddOrUpdate(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }
    }
}
