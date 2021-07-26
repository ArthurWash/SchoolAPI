using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace SchoolAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CourseManagement, CourseDto>();
            CreateMap<CourseForCreationDto, CourseManagement>();
            CreateMap<CourseForUpdateDto, CourseManagement>().ReverseMap();
            CreateMap<User, UserDto>();
            CreateMap<UserForCreationDto, User>();
            CreateMap<UserForUpdateDto, User>().ReverseMap();
            CreateMap<AssignmentManagement, AssignmentDto>();
            CreateMap<AssignmentForCreationDto, AssignmentManagement>();
            CreateMap<AssignmentForUpdateDto, AssignmentManagement>().ReverseMap();
            CreateMap<CourseSectionManagement, CourseSectionDto>();
            CreateMap<CourseSectionForCreationDto, CourseSectionManagement>();
            CreateMap<CourseSectionForUpdateDto, CourseSectionManagement>().ReverseMap();
            CreateMap<SectionEnrollmentManagement, SectionEnrollmentDto>();
            CreateMap<SectionEnrollmentForCreationDto, SectionEnrollmentManagement>();
            CreateMap<SectionEnrollmentForUpdateDto, SectionEnrollmentManagement>().ReverseMap();
        }
    }
}
