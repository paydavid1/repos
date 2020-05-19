using System.Linq;
using System.Reflection;
using ETProject.api.Features.Categorys;
using ETProject.api.Features.Transactions;
using ETProject.api.Features.Users;
using ETProject.api.Persistence.Maps;
using Microsoft.EntityFrameworkCore;

namespace ETProject.api.Persistence.Data
{
    public class ETDbContext : DbContext
    {
        
        public ETDbContext(DbContextOptions<ETDbContext> options) : base(options) {}

        public DbSet<Category> Categories { get; set; } 
        public DbSet<User> Users {get; set;}   

        public DbSet<Transaction> Transactions { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TransactionMap());

            
            base.OnModelCreating(modelBuilder);        
            
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                    relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }


        
        }
              

    }
}