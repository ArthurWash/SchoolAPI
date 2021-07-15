using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface ICourseManagementRepository
    {
        IEnumerable<CourseManagement> GetAllCourses(bool trackChanges);
        CourseManagement GetCourse(Guid CourseManagementID, bool trackChanges);
    }
}