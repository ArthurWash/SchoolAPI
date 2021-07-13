using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
    public class CourseManagementConfiguration : IEntityTypeConfiguration<CourseManagement>
    {
        public void Configure(EntityTypeBuilder<CourseManagement> builder)
        {
            builder.HasData
            (
                new CourseManagement
                {
                    Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479812"),
                    CourseTitle = "Web Services and Middleware",
                    Description = "Web services enable integration of web-based applications and feature sets to any other web-based system in a modular way. Middleware is a set of functionality positioned in between and enabling interoperability among different, distributed enterprise and other computing applications. This course provides an introduction to web services and middleware in the context of digital libraries - large scale multimedia information repositories. Students will gain hands on experience in developing their own web services managing a complex distributed computing platform.",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now

                },
                new CourseManagement
                {
                    Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479813"),
                    CourseTitle = "Web Systems Development",
                    Description = "Students will gain experience in open source web development through an intensive hands-on project, applying real-world problem-solving skills to meeting information systems requirements. Students will learn Web development principles, as well as professionally relevant skills including industry standards, conventions, and procedures within large-scale programming projects. Also covered are the communication tools, technologies, and practices that individuals use to coordinate and collaborate within the open source software development community.",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                }
            );
        }
    }
}