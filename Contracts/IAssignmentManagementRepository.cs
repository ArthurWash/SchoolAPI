using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IAssignmentManagementRepository
    {
        IEnumerable<AssignmentManagement> GetAllAssignments(bool trackChanges);
        AssignmentManagement GetAssignment(Guid CourseSectionID, bool trackChanges);
        void CreateAssignment(AssignmentManagement assignment);
        IEnumerable<AssignmentManagement> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteAssignment(AssignmentManagement assignmentManagement);
    }
}