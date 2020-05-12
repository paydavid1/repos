using ETProject.api.Features.User;
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
            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("INTEGER ").ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("TEXT").IsRequired(true);
            builder.Property(x => x.UserId).HasColumnName("UserId").HasColumnType("TEXT").IsRequired(true);  
            builder.Property(x => x.PassHash).HasColumnName("PassHash").HasColumnType("BLOB").IsRequired(true);  
            builder.Property(x => x.PassSalt).HasColumnName("PassSalt").HasColumnType("BLOB").IsRequired(true);  
        }
    }
}    