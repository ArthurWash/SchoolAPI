﻿using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class CourseManagementRepository : RepositoryBase<CourseManagement>, ICourseManagementRepository
    {
        public CourseManagementRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<CourseManagement> GetAllCourses(bool trackChanges) =>
        FindAll(trackChanges)
        .OrderBy(c => c.CourseTitle)
        .ToList();

        public CourseManagement GetCourse(Guid CourseManagementID, bool trackChanges) =>
         FindByCondition(c => c.Id.Equals(CourseManagementID), trackChanges)
        .SingleOrDefault();
        public void CreateCourse(CourseManagement courseManagement) => Create(courseManagement);

        public IEnumerable<CourseManagement> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.Id), trackChanges)
            .ToList();

        public void DeleteCourse(CourseManagement courseManagement)
        {
            Delete(courseManagement);
        }
    }
}