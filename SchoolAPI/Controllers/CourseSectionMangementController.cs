using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace SchoolAPI.Controllers
{
    [Route("api/v1/coursesections")]
    [ApiController]
    public class CourseSectionManagementController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CourseSectionManagementController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCourseSections()
        {
            try
            {
                var coursesections = _repository.CourseSectionManagement.GetAllCourseSections(trackChanges: false);
                return Ok(coursesections);
                /*var organizationDto = _mapper.Map<IEnumerable<OrganizationDto>>(organizations);
                return Ok(organizationDto);*/

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetCourseSections)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetCourseSections(Guid id)
        {
            try
            {
                var coursesection = _repository.CourseSectionManagement.GetCourseSection(id, trackChanges: false); if (coursesection == null)
                {
                    _logger.LogInfo($"CourseSection with id: {id} doesn't exist in the database.");
                    return NotFound();
                }
                else
                {
                    var CourseSectionDto = _mapper.Map<CourseSectionDto>(coursesection);
                    return Ok(CourseSectionDto);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetCourseSections)} action {ex}");
                return StatusCode(500, "Internal server error");
            }

        }
    }
}