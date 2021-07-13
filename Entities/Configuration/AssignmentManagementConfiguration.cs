using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
    public class AssignmentManagementConfiguration : IEntityTypeConfiguration<AssignmentManagement>
    {
        public void Configure(EntityTypeBuilder<AssignmentManagement> builder)
        {
            builder.HasData
            (
                new AssignmentManagement
                {
                    Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479816"),
                    AssignmentTitle = "Module 1",
                    Description = "Create a website that can receive user input",
                    CourseSectionID = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479814"),
                    CourseID = "IS690"

                },
                new AssignmentManagement
                {
                    Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479830"),
                    AssignmentTitle = "Module 1",
                    Description = "Create a website that can receive user input",
                    CourseSectionID = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479815"),
                    CourseID = "IS601"

                }

            );
        }
    }
}