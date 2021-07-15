using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CourseManagement.Controllers
{
    [Route("api/v1/courses")]
    [ApiController]
    public class CourseManagementController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CourseManagementController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCourses()
        {
            try
            {
                var courses = _repository.CourseManagement.GetAllCourses(trackChanges: false);
                return Ok(courses);
                /*var organizationDto = _mapper.Map<IEnumerable<OrganizationDto>>(organizations);
                return Ok(organizationDto);*/

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetCourses)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetCourses(Guid id)
        {
            try
            {
                var course = _repository.CourseManagement.GetCourse(id, trackChanges: false); if (course == null)
                {
                    _logger.LogInfo($"Course with id: {id} doesn't exist in the database.");
                    return NotFound();
                }
                else
                {
                    var CourseDto = _mapper.Map<CourseDto>(course);
                    return Ok(CourseDto);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetCourses)} action {ex}");
                return StatusCode(500, "Internal server error");
            }

        }
    }
}