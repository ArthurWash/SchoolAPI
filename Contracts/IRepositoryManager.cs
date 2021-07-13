namespace Contracts
{
    public interface IRepositoryManager
    {
        ICourseManagementRepository CourseManagement { get; }
        IUserRepository User { get; }
        ICourseSectionManagementRepository CourseSectionManagement { get; }
        ISectionEnrollmentManagementRepository SectionEnrollmentManagement { get; }
        IAssignmentManagementRepository AssignmentManagement { get; }

        void Save();
    }
}