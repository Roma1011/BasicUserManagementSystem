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
        private readonly IPasswordService _passwordService;

        public UserConfiguration(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(TableNames.Users);
            builder.HasKey(i => i.UserId);
            
            builder.Property(i => i.UserName).HasColumnType(DbTypes.Varchar).HasMaxLength(60).IsRequired();
            builder.Property(i => i.Email).HasColumnType(DbTypes.Varchar).HasMaxLength(50).IsRequired();
            builder.Property(i => i.IsActive).HasColumnType(DbTypes.Boolean).HasMaxLength(50).IsRequired();
            builder.Property(i => i.Password).HasColumnType(DbTypes.Varbinary).IsRequired();
            
            builder.HasOne(u => u.UserProfile)
                .WithOne()
                .HasForeignKey<User>(u => u.UserProfileId);
            
            builder.HasData(SeedDataGenerator(_passwordService));
        }
        private static IEnumerable<User> SeedDataGenerator(IPasswordService passwordService)
        {
            var users = Enumerable.Range(1, 10).Select(i => new User
            {
                UserId = i,
                UserName = $"User{i}",
                Password = passwordService.HashPassword($"Password{i}"),
                Email = $"user{i}@example.com",
                IsActive = true,
                UserProfile = new UserProfile
                {
                    FirstName = $"First{i}",
                    LastName = $"Last{i}",
                    PersonalNumber = 1000000000 + i
                }
            }).ToList();
            return users;
        }
    }
    
}