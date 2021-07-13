using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
    public class SectionEnrollmentManagementConfiguration : IEntityTypeConfiguration<SectionEnrollmentManagement>
    {
        public void Configure(EntityTypeBuilder<SectionEnrollmentManagement> builder)
        {
            builder.HasData
            (
                new SectionEnrollmentManagement
                {
                    Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479820"),
                    SectionID = "IS690-001",
                    StartDate = DateTime.Parse("09/01/2021"),
                    EndDate = DateTime.Parse("12/15/2021"),
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    UserName = "awash",
                    UserID = new Guid("80abbca8-664d-4b20-b5de-024705497d4a")

                },
                new SectionEnrollmentManagement
                {
                    Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479821"),
                    SectionID = "IS601-001",
                    StartDate = DateTime.Parse("09/01/2021"),
                    EndDate = DateTime.Parse("12/15/2021"),
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    UserID = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                    UserName = "thupchick",
                }

            );
        }
    }
}