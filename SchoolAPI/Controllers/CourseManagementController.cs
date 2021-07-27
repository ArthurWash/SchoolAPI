using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch;

namespace SchoolAPI.Controllers
{
    [Route("api/v1/courses")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
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

        [HttpGet(Name = "getAllCourses")]
        public IActionResult GetCourses()
        {
            var courses = _repository.CourseManagement.GetAllCourses(trackChanges: false);

            var CourseDto = _mapper.Map<IEnumerable<CourseDto>>(courses);
            //throw new Exception("Exception");
            return Ok(CourseDto);
        }

        [HttpGet("{id}", Name = "getCourseById")]
        public IActionResult GetCourse(Guid id)
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

        [HttpPost(Name = "createCourse")]
        public IActionResult CreateCourse([FromBody] CourseForCreationDto course)
        {
            if (course == null)
            {
                _logger.LogError("Course ForCreationDto object sent from client is null.");
                return BadRequest("Course ForCreationDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the CourseForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var courseEntity = _mapper.Map<CourseManagement>(course);

            _repository.CourseManagement.CreateCourse(courseEntity);
            _repository.Save();

            var courseToReturn = _mapper.Map<CourseDto>(courseEntity);

            return CreatedAtRoute("getCourseById", new { id = courseToReturn.Id }, courseToReturn);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCourse(Guid id, [FromBody] CourseForUpdateDto course)
        {
            if (course == null)
            {
                _logger.LogError("CourseForUpdateDto object sent from client is null.");
                return BadRequest("CourseForUpdateDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the CourseForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }
            var courseEntity = _repository.CourseManagement.GetCourse(id, trackChanges: true);
            if (courseEntity == null)
            {
                _logger.LogInfo($"Course with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(course, courseEntity);
            _repository.Save();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(Guid id)
        {
            var course = _repository.CourseManagement.GetCourse(id, trackChanges: false);
            if (course == null)
            {
                _logger.LogInfo($"Course with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.CourseManagement.DeleteCourse(course);
            _repository.Save();

            return NoContent();
        }
        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateCourse(Guid id, [FromBody] JsonPatchDocument<CourseForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                _logger.LogError("patchDoc object sent from client is null.");
                return BadRequest("patchDoc object is null");
            }

            var courseEntity = _repository.CourseManagement.GetCourse(id, trackChanges: true);
            if (courseEntity == null)
            {
                _logger.LogInfo($"Course with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var courseToPatch = _mapper.Map<CourseForUpdateDto>(courseEntity);

            patchDoc.ApplyTo(courseToPatch);

            _mapper.Map(courseToPatch, courseEntity);

            _repository.Save();

            return NoContent();
        }
    }
}