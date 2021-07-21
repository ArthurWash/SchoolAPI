using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface ICourseManagementRepository
    {
        IEnumerable<CourseManagement> GetAllCourses(bool trackChanges);
        CourseManagement GetCourse(Guid CourseManagementID, bool trackChanges);
        void CreateCourse(CourseManagement courseManagement);
        IEnumerable<CourseManagement> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteCourse(CourseManagement courseManagement);
    }
}