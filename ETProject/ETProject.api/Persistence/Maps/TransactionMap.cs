using ETProject.api.Features.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETProject.api.Persistence.Maps
{
    public class TransactionMap : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").UseIdentityColumn();
            builder.Property(x => x.Description).HasColumnName("Description").HasColumnType("varchar(50)").IsRequired(true);
            builder.Property(x => x.DateTransaction).HasColumnName("DateTransaction").HasColumnType("datetime").IsRequired(true);    
            builder.Property(x => x.Total).HasColumnName("Total").HasColumnType("decimal(18, 2)").IsRequired(true);    
            builder.Property(x => x.UserId).HasColumnName("UserId").HasColumnType("int").IsRequired(true);    
            builder.Property(x => x.CategoryId).HasColumnName("CategoryId").HasColumnType("int").IsRequired(true);    
           
            
           
        }
    }
}