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
    }
}