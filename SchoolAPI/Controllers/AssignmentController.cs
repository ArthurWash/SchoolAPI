using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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

        [HttpGet]
        public IActionResult GetAssignments()
        {
            try
            {
                var assignments = _repository.AssignmentManagement.GetAllAssignments(trackChanges: false);
                return Ok(assignments);
                /*var organizationDto = _mapper.Map<IEnumerable<OrganizationDto>>(organizations);
                return Ok(organizationDto);*/

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAssignments)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetAssignments(Guid id)
        {
            try
            {
                var assignment = _repository.AssignmentManagement.GetAssignment(id, trackChanges: false); if (assignment == null)
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
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAssignments)} action {ex}");
                return StatusCode(500, "Internal server error");
            }

        }
    }
}