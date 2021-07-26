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

        [HttpGet(Name = "getAllCourseSections")]
        public IActionResult GetCourseSections()
        {
             var coursesections = _repository.CourseSectionManagement.GetAllCourseSections(trackChanges: false);

             var CourseSectionDto = _mapper.Map<IEnumerable<CourseSectionDto>>(coursesections);
                return Ok(CourseSectionDto);
        }
        [HttpGet("{id}", Name = "getCourseSectionById")]
        public IActionResult GetCourseSections(Guid id)
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

        [HttpPost(Name = "createCourseSection")]
        public IActionResult CreateCourseSection([FromBody] CourseSectionForCreationDto coursesection)
        {
            if (coursesection == null)
            {
                _logger.LogError("CourseSectionForCreationDto object sent from client is null.");
                return BadRequest("CourseSectionForCreationDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the CourseSectionForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var coursesectionEntity = _mapper.Map<CourseSectionManagement>(coursesection);

            _repository.CourseSectionManagement.CreateCourseSection(coursesectionEntity);
            _repository.Save();

            var coursesectionToReturn = _mapper.Map<CourseSectionDto>(coursesectionEntity);

            return CreatedAtRoute("getCourseSectionById", new { id = coursesectionToReturn.Id }, coursesectionToReturn);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCourseSection(Guid id, [FromBody] CourseSectionForUpdateDto coursesection)
        {
            if (coursesection == null)
            {
                _logger.LogError("CourseSectionForUpdateDto object sent from client is null.");
                return BadRequest("CourseSectionForUpdateDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the CourseSectionForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }
            var coursesectionEntity = _repository.CourseSectionManagement.GetCourseSection(id, trackChanges: true);
            if (coursesectionEntity == null)
            {
                _logger.LogInfo($"Course with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(coursesection, coursesectionEntity);
            _repository.Save();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCourseSection(Guid id)
        {
            var coursesection = _repository.CourseSectionManagement.GetCourseSection(id, trackChanges: false);
            if (coursesection == null)
            {
                _logger.LogInfo($"Course section with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.CourseSectionManagement.DeleteCourseSection(coursesection);
            _repository.Save();

            return NoContent();
        }
        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateCourseSection(Guid id, [FromBody] JsonPatchDocument<CourseSectionForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                _logger.LogError("patchDoc object sent from client is null.");
                return BadRequest("patchDoc object is null");
            }

            var coursesectionEntity = _repository.CourseSectionManagement.GetCourseSection(id, trackChanges: true);
            if (coursesectionEntity == null)
            {
                _logger.LogInfo($"Course Section with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var coursesectionToPatch = _mapper.Map<CourseSectionForUpdateDto>(coursesectionEntity);

            patchDoc.ApplyTo(coursesectionToPatch);

            _mapper.Map(coursesectionToPatch, coursesectionEntity);

            _repository.Save();

            return NoContent();
        }
    }
}