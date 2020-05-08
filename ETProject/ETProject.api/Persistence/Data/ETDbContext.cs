using ETProject.api.Features.Category;
using Microsoft.EntityFrameworkCore;

namespace ETProject.api.Persistence.Data
{
    public class ETDbContext : DbContext
    {
        
        public ETDbContext(DbContextOptions<ETDbContext> options) : base(options) {}

        public DbSet<Category> Categories { get; set; }

        

    }
}