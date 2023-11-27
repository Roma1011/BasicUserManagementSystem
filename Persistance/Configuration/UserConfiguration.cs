using System.Collections.Generic;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            List<User> userList = new List<User>
            {
                new User
                {
                    UserId = 1,
                    UserName = "Admin",
                    Password = "Admin1",
                    Email = "Admin1@example.com",
                    IsActive = true
                },
                new User
                {
                    UserId = 2,
                    UserName = "AnotherUser1",
                    Password = "Password123",
                    Email = "user1@example.com",
                    IsActive = true
                },
                new User
                {
                    UserId = 3,
                    UserName = "User3",
                    Password = "SecurePassword",
                    Email = "user3@example.com",
                    IsActive = true
                },
                new User
                {
                    UserId = 4,
                    UserName = "TestUser4",
                    Password = "Test123",
                    Email = "testuser4@example.com",
                    IsActive = true
                },
                new User
                {
                    UserId = 5,
                    UserName = "NewUser5",
                    Password = "NewPassword",
                    Email = "newuser5@example.com",
                    IsActive = true
                },
                new User
                {
                    UserId = 6,
                    UserName = "DemoUser6",
                    Password = "DemoPassword",
                    Email = "demouser6@example.com",
                    IsActive = true
                },
                new User
                {
                    UserId = 7,
                    UserName = "AlphaUser7",
                    Password = "Alpha123",
                    Email = "alphauser7@example.com",
                    IsActive = true
                },
                new User
                {
                    UserId = 8,
                    UserName = "BetaUser8",
                    Password = "Beta456",
                    Email = "betauser8@example.com",
                    IsActive = true
                },
                new User
                {
                    UserId = 9,
                    UserName = "GammaUser9",
                    Password = "Gamma789",
                    Email = "gammauser9@example.com",
                    IsActive = true
                },
                new User
                {
                    UserId = 10,
                    UserName = "FinalUser10",
                    Password = "FinalPassword",
                    Email = "finaluser10@example.com",
                    IsActive = true
                }
            };

            builder.HasData(userList);
        }
    }
}