using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
    public class CourseSectionManagementConfiguration : IEntityTypeConfiguration<CourseSectionManagement>
    {
        public void Configure(EntityTypeBuilder<CourseSectionManagement> builder)
        {
            builder.HasData
            (
                new CourseSectionManagement
                {
                    Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479814"),
                    CourseID = "IS690",
                    StartDate = DateTime.Parse("09/01/2021"),
                    EndDate = DateTime.Parse("12/15/2021"),
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                                     
                },
                new CourseSectionManagement
                {
                    Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479815"),
                    CourseID = "IS601",
                    StartDate = DateTime.Parse("09/01/2021"),
                    EndDate = DateTime.Parse("12/15/2021"),
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                }
            ) ;
        }
    }
}