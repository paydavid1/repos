using ETProject.api.Features.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETProject.api.Persistence.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Userss");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("varchar(50)").IsRequired(true);
            builder.Property(x => x.UserId).HasColumnName("UserId").HasColumnType("varchar(50)").IsRequired(true);  
            builder.Property(x => x.PassHash).HasColumnName("PassHash").HasColumnType("varbinary(max)").IsRequired(true);  
            builder.Property(x => x.PassSalt).HasColumnName("PassSalt").HasColumnType("varbinary(max)").IsRequired(true);  
        }
    }
}    