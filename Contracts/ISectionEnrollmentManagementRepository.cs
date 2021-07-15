using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface ISectionEnrollmentManagementRepository
    {
        IEnumerable<SectionEnrollmentManagement> GetAllSectionEnrollments(bool trackChanges);
        SectionEnrollmentManagement GetSectionEnrollment(Guid SectionID, bool trackChanges);
    }
}