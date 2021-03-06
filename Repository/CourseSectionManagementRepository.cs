using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class CourseSectionManagementRepository : RepositoryBase<CourseSectionManagement>, ICourseSectionManagementRepository
    {
        public CourseSectionManagementRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<CourseSectionManagement> GetAllCourseSections(bool trackChanges) =>
        FindAll(trackChanges)
        .OrderBy(c => c.CourseID)
        .ToList();

        public CourseSectionManagement GetCourseSection(Guid CourseSectionID, bool trackChanges) =>
         FindByCondition(c => c.Id.Equals(CourseSectionID), trackChanges)
        .SingleOrDefault();
        public void CreateCourseSection(CourseSectionManagement coursesectionManagement) => Create(coursesectionManagement);

        public IEnumerable<CourseSectionManagement> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.Id), trackChanges)
            .ToList();

        public void DeleteCourseSection(CourseSectionManagement coursesectionManagement)
        {
            Delete(coursesectionManagement);
        }
    }
}