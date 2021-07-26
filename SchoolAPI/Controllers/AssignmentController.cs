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
    [Route("api/v1/assignments")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public AssignmentController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "getAllAssignments")]
        public IActionResult GetAssignments()
        {
            var assignments = _repository.AssignmentManagement.GetAllAssignments(trackChanges: false);

            var AssignmentDto = _mapper.Map<IEnumerable<AssignmentDto>>(assignments);
                return Ok(AssignmentDto);
        }
        [HttpGet("{id}", Name = "getAssignmentById")]
        public IActionResult GetAssignments(Guid id)
        {
            var assignment = _repository.AssignmentManagement.GetAssignment(id, trackChanges: false);
            if (assignment == null)
                {
                    _logger.LogInfo($"Assignment with id: {id} doesn't exist in the database.");
                    return NotFound();
                }
                else
                {
                    var AssignmentDto = _mapper.Map<AssignmentDto>(assignment);
                    return Ok(AssignmentDto);
                }            
        }
        [HttpPost(Name = "createAssignment")]
        public IActionResult CreateAssignment([FromBody] AssignmentForCreationDto assignment)
        {
            if (assignment == null)
            {
                _logger.LogError("AssignmentForCreationDto object sent from client is null.");
                return BadRequest("AssignmentForCreationDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the AssignmentForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var assignmentEntity = _mapper.Map<AssignmentManagement>(assignment);

            _repository.AssignmentManagement.CreateAssignment(assignmentEntity);
            _repository.Save();

            var assignmentToReturn = _mapper.Map<AssignmentDto>(assignmentEntity);

            return CreatedAtRoute("getAssignmentById", new { id = assignmentToReturn.Id }, assignmentToReturn);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateAssignment(Guid id, [FromBody] AssignmentForUpdateDto assignment)
        {
            if (assignment == null)
            {
                _logger.LogError("AssignmentForUpdateDto object sent from client is null.");
                return BadRequest("AssignmentForUpdateDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the AssignmentForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }
            var assignmentEntity = _repository.AssignmentManagement.GetAssignment(id, trackChanges: true);
            if (assignmentEntity == null)
            {
                _logger.LogInfo($"Assignment with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(assignment, assignmentEntity);
            _repository.Save();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAssignmentForCompany(Guid id)
        {
            var assignment = _repository.AssignmentManagement.GetAssignment(id, trackChanges: false);
            if (assignment == null)
            {
                _logger.LogInfo($"Assignment with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.AssignmentManagement.DeleteAssignment(assignment);
            _repository.Save();

            return NoContent();
        }
        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateAssignment(Guid id, [FromBody] JsonPatchDocument<AssignmentForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                _logger.LogError("patchDoc object sent from client is null.");
                return BadRequest("patchDoc object is null");
            }

            var assignmentEntity = _repository.AssignmentManagement.GetAssignment(id, trackChanges: true);
            if (assignmentEntity == null)
            {
                _logger.LogInfo($"Course with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var assignmentToPatch = _mapper.Map<AssignmentForUpdateDto>(assignmentEntity);

            patchDoc.ApplyTo(assignmentToPatch);

            _mapper.Map(assignmentToPatch, assignmentEntity);

            _repository.Save();

            return NoContent();
        }
    }
}