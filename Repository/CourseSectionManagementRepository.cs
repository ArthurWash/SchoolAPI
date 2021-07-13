using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class CourseSectionManagementRepository : RepositoryBase<CourseSectionManagement>, ICourseSectionManagementRepository
    {
        public CourseSectionManagementRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}