using System.Collections.Generic;
using Domain.Entities;
using Domain.IServices.ISecuriyServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Constants;

namespace Persistance.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(TableNames.Users);
            builder.HasKey(i => i.UserId);
            
            builder.Property(i => i.UserName).HasColumnType(DbTypes.Nvarchar).HasMaxLength(60).IsRequired();
            builder.Property(i => i.Email).HasColumnType(DbTypes.Nvarchar).HasMaxLength(60).IsRequired();
            builder.Property(i => i.IsActive).HasColumnType(DbTypes.Boolean).HasMaxLength(50).IsRequired();
            builder.Property(i => i.Password).HasColumnType(DbTypes.Varbinary).HasMaxLength(500).IsRequired();
            
            builder.HasOne(u => u.UserProfile)
                .WithOne()
                .HasForeignKey<User>(u => u.UserProfileId);
        }
    }
    
}