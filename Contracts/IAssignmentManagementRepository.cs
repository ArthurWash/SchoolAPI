using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IAssignmentManagementRepository
    {
        IEnumerable<AssignmentManagement> GetAllAssignments(bool trackChanges);
        AssignmentManagement GetAssignment(Guid AssignmentID, bool trackChanges);
    }
}