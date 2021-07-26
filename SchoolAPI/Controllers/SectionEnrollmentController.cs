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
    [Route("api/v1/sectionenrollment")]
    [ApiController]
    public class SectionEnrollmentController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public SectionEnrollmentController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "getAllSectionEnrollments")]
        public IActionResult GetSectionEnrollments()
        {
            var sectionenrollments = _repository.SectionEnrollmentManagement.GetAllSectionEnrollments(trackChanges: false);

            var SectionEnrollmentDto = _mapper.Map<IEnumerable<SectionEnrollmentDto>>(sectionenrollments);
            return Ok(SectionEnrollmentDto);
        }
        [HttpGet("{id}", Name = "getSectionEnrollmentsById")]
        public IActionResult GetSectionEnrollments(Guid id)
        {
            var sectionenrollment = _repository.SectionEnrollmentManagement.GetSectionEnrollment(id, trackChanges: false); if (sectionenrollment == null)
            {
                _logger.LogInfo($"SectionEnrollment with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var SectionEnrollmentDto = _mapper.Map<SectionEnrollmentDto>(sectionenrollment);
                return Ok(SectionEnrollmentDto);
            }
        }
        [HttpPost(Name = "createSectionEnrollment")]
        public IActionResult CreateSectionEnrollment([FromBody] SectionEnrollmentForCreationDto sectionEnrollment)
        {
            if (sectionEnrollment == null)
            {
                _logger.LogError("SectionEnrollmentForCreationDto object sent from client is null.");
                return BadRequest("SectionEnrollmentForCreationDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the SectionEnrollmentForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var sectionenrollmentEntity = _mapper.Map<SectionEnrollmentManagement>(sectionEnrollment);

            _repository.SectionEnrollmentManagement.CreateSection(sectionenrollmentEntity);
            _repository.Save();

            var sectionToReturn = _mapper.Map<SectionEnrollmentDto>(sectionenrollmentEntity);

            return CreatedAtRoute("getSectionEnrollmentsById", new { id = sectionToReturn.Id }, sectionToReturn);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateSection(Guid id, [FromBody] SectionEnrollmentForUpdateDto sectionEnrollment)
        {
            if (sectionEnrollment == null)
            {
                _logger.LogError("SectionEnrollmentForUpdateDto object sent from client is null.");
                return BadRequest("SectionEnrollmentForUpdateDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the SectionEnrollmentForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }
            var sectionEntity = _repository.SectionEnrollmentManagement.GetSectionEnrollment(id, trackChanges: true);
            if (sectionEntity == null)
            {
                _logger.LogInfo($"Section with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(sectionEnrollment, sectionEntity);
            _repository.Save();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSection(Guid id)
        {
            var section = _repository.SectionEnrollmentManagement.GetSectionEnrollment(id, trackChanges: false);
            if (section == null)
            {
                _logger.LogInfo($"Section with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.SectionEnrollmentManagement.DeleteSection(section);
            _repository.Save();

            return NoContent();
        }
        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateSection(Guid id, [FromBody] JsonPatchDocument<SectionEnrollmentForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                _logger.LogError("patchDoc object sent from client is null.");
                return BadRequest("patchDoc object is null");
            }

            var sectionEntity = _repository.SectionEnrollmentManagement.GetSectionEnrollment(id, trackChanges: true);
            if (sectionEntity == null)
            {
                _logger.LogInfo($"Course with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var sectionToPatch = _mapper.Map<SectionEnrollmentForUpdateDto>(sectionEntity);

            patchDoc.ApplyTo(sectionToPatch);

            _mapper.Map(sectionToPatch, sectionEntity);

            _repository.Save();

            return NoContent();
        }
    }
}