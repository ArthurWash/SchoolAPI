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

        public AssignmentManagement GetAssignment(Guid CourseSectionID, bool trackChanges) =>
         FindByCondition(c => c.Id.Equals(CourseSectionID), trackChanges)
        .SingleOrDefault();

        public void CreateAssignment(AssignmentManagement assignment) => Create(assignment);

        public IEnumerable<AssignmentManagement> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(c => ids.Contains(c.Id), trackChanges)
            .ToList();

        public void DeleteAssignment(AssignmentManagement assignmentManagement)
        {
            Delete(assignmentManagement);
        }

    }
}