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
        public IEnumerable<SectionEnrollmentManagement> GetAllSectionEnrollments(bool trackChanges) =>
        FindAll(trackChanges)
        .OrderBy(c => c.SectionID)
        .ToList();

        public SectionEnrollmentManagement GetSectionEnrollment(Guid SectionID, bool trackChanges) =>
         FindByCondition(c => c.Id.Equals(SectionID), trackChanges)
        .SingleOrDefault();
    }
}