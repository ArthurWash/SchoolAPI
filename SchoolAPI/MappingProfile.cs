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
            CreateMap<CourseForUpdateDto, CourseManagement>();


        }
    }
}
