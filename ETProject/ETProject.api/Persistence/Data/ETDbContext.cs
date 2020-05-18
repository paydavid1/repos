using System.Reflection;
using ETProject.api.Features.Categorys;
using ETProject.api.Features.User;
using ETProject.api.Persistence.Maps;
using Microsoft.EntityFrameworkCore;

namespace ETProject.api.Persistence.Data
{
    public class ETDbContext : DbContext
    {
        
        public ETDbContext(DbContextOptions<ETDbContext> options) : base(options) {}

        public DbSet<Category> Categories { get; set; } 
        public DbSet<User> Users {get; set;}   
        
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            
            // modelBuilder.ApplyConfiguration(new CategoryMap());
            // modelBuilder.ApplyConfiguration(new UserMap());

             modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            //base.OnModelCreating(modelBuilder);          

        
        }
              

    }
}