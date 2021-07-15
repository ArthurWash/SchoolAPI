using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class AssignmentManagementRepository : RepositoryBase<AssignmentManagement>, IAssignmentManagementRepository
    {
        public AssignmentManagementRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<AssignmentManagement> GetAllAssignments(bool trackChanges) =>
        FindAll(trackChanges)
        .OrderBy(c => c.AssignmentTitle)
        .ToList();

        public AssignmentManagement GetAssignment(Guid AssignmentID, bool trackChanges) =>
         FindByCondition(c => c.Id.Equals(AssignmentID), trackChanges)
        .SingleOrDefault();
    }
}