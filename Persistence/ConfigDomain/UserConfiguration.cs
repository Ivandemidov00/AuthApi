using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ConfigDomain
{
    public class UserConfiguration:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.FIO).HasMaxLength(60);
            builder.Property(p => p.Phone).IsRequired().HasMaxLength(40);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Password).HasMaxLength(16);
            builder.Property(p => p.LastLogin).HasMaxLength(12);
        }
    }
}