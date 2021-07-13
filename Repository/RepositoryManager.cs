using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private ICourseManagementRepository _coursemanagementRepository;
        private IUserRepository _userRepository;
        private ICourseSectionManagementRepository _coursesectionmanagementRepository;
        private ISectionEnrollmentManagementRepository _sectionenrollmentmanagementRepository;
        private IAssignmentManagementRepository _assignmentmanagementRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public ICourseManagementRepository CourseManagement
        {
            get
            {
                if (_coursemanagementRepository == null)
                    _coursemanagementRepository = new CourseManagementRepository(_repositoryContext);

                return _coursemanagementRepository;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_repositoryContext);

                return _userRepository;
            }
        }
        public ICourseSectionManagementRepository CourseSectionManagement
        {
            get
            {
                if (_coursesectionmanagementRepository == null)
                    _coursesectionmanagementRepository = new CourseSectionManagementRepository(_repositoryContext);

                return _coursesectionmanagementRepository;
            }
        }
        public ISectionEnrollmentManagementRepository SectionEnrollmentManagement
        {
            get
            {
                if (_sectionenrollmentmanagementRepository == null)
                    _sectionenrollmentmanagementRepository = new SectionEnrollmentManagementRepository(_repositoryContext);

                return _sectionenrollmentmanagementRepository;
            }
        }
        public IAssignmentManagementRepository AssignmentManagement
        {
            get
            {
                if (_assignmentmanagementRepository == null)
                    _assignmentmanagementRepository = new AssignmentManagementRepository(_repositoryContext);

                return _assignmentmanagementRepository;
            }
        }

        public void Save() => _repositoryContext.SaveChanges();
    }
}