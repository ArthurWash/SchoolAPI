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
    }
}