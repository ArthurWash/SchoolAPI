using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class CourseManagementRepository : RepositoryBase<CourseManagement>, ICourseManagementRepository
    {
        public CourseManagementRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}