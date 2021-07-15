using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface ICourseSectionManagementRepository
    {
        IEnumerable<CourseSectionManagement> GetAllCourseSections(bool trackChanges);
        CourseSectionManagement GetCourseSection(Guid CourseSectionID, bool trackChanges);
    }
}