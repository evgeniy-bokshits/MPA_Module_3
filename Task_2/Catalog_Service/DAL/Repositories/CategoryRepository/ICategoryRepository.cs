using System.Collections.Generic;
using System.Threading.Tasks;

using Core.Infrastructure.Models;

namespace DAL.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategory(int id);
        Task<List<Category>> GetAllCategories();
        Task<Category> AddCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task DeleteCategory(int id);
    }
}
