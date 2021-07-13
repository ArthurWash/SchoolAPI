using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData
            (
                new User
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    UserName = "awash",
                    Email = "ajw53@njit.edu",
                    Status = true,
                    SystemRoleID = "student",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new User
                {
                    Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                    UserName = "thupchick",
                    Email = "tjhupchick24@njit.edu",
                    Status = false,
                    SystemRoleID = "student",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                 new User
                 {
                     Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                     UserName = "kwilliams",
                     Email = "keith.a.williams@njit.edu",
                     Status = true,
                     SystemRoleID = "profesor",
                     CreatedDate = DateTime.Now,
                     UpdatedDate = DateTime.Now
                 }

            );
        }
    }
}