using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Constants;

namespace Persistance.Configuration;

public class UserProfileConfiguration:IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.ToTable(TableNames.UserProfiles);
        builder.HasKey(i => i.UserProfileId);
            
        builder.Property(i => i.FirstName).HasColumnType(DbTypes.Nvarchar).HasMaxLength(60).IsRequired();
        builder.Property(i => i.LastName).HasColumnType(DbTypes.Nvarchar).HasMaxLength(60).IsRequired();
        builder.Property(i => i.PersonalNumber).HasColumnType(DbTypes.BigInt).IsRequired();
    }
}