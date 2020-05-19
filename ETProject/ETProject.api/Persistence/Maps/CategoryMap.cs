using ETProject.api.Features.Categorys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETProject.api.Persistence.Maps
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").ValueGeneratedOnAdd();
            builder.Property(x => x.Description).HasColumnName("Description").HasColumnType("varchar(50)").IsRequired(true);
            builder.Property(x => x.Type).HasColumnName("Type").HasColumnType("bit").IsRequired(true);    

            
        }
    }
}