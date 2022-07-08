using System.Collections.Generic;
using System.Threading.Tasks;

using Core.Infrastructure.Models;

namespace DAL.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<Product> GetProduct(int id);
        Task<List<Product>> GetAllProducts();
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task DeleteProduct(int id);
    }
}
