using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class AssignmentManagementRepository : RepositoryBase<AssignmentManagement>, IAssignmentManagementRepository
    {
        public AssignmentManagementRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}