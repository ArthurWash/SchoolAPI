using Entities.Configuration;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseManagementConfiguration());
            modelBuilder.ApplyConfiguration(new CourseSectionManagementConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new SectionEnrollmentManagementConfiguration());
            modelBuilder.ApplyConfiguration(new AssignmentManagementConfiguration());

        }

        public DbSet<CourseManagement> Organizations { get; set; }
        public DbSet<CourseSectionManagement> CourseSections { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SectionEnrollmentManagement> SectionEnrollment { get; set; }
        public DbSet<AssignmentManagement> Assignments { get; set; }

    }
}