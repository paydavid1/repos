using ETProject.api.Features.Category;
using ETProject.api.Persistence.Maps;
using Microsoft.EntityFrameworkCore;

namespace ETProject.api.Persistence.Data
{
    public class ETDbContext : DbContext
    {
        
        public ETDbContext(DbContextOptions<ETDbContext> options) : base(options) {}

        public DbSet<Category> Categories { get; set; }          

    }
}