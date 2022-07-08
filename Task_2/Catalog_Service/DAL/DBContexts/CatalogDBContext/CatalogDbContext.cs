using System.Data.Entity;
using Core.Infrastructure.Models;

namespace DAL.DBContexts.CatalogDBContext
{
    public class CatalogDbContext : DbContext
    {
        private const string DbConnection = "create it";

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
