using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class SectionEnrollmentManagementRepository : RepositoryBase<SectionEnrollmentManagement>, ISectionEnrollmentManagementRepository
    {
        public SectionEnrollmentManagementRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}