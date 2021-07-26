using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface ICourseSectionManagementRepository
    {
        IEnumerable<CourseSectionManagement> GetAllCourseSections(bool trackChanges);
        CourseSectionManagement GetCourseSection(Guid CourseSectionID, bool trackChanges);
        void CreateCourseSection(CourseSectionManagement coursesectionManagement);
        IEnumerable<CourseSectionManagement> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteCourseSection(CourseSectionManagement coursesectionManagement);
    }
}