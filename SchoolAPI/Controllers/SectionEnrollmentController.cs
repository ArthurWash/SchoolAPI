using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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

        [HttpGet]
        public IActionResult GetSectionEnrollments()
        {
            try
            {
                var sectionenrollments = _repository.SectionEnrollmentManagement.GetAllSectionEnrollments(trackChanges: false);
                return Ok(sectionenrollments);
                /*var organizationDto = _mapper.Map<IEnumerable<OrganizationDto>>(organizations);
                return Ok(organizationDto);*/

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetSectionEnrollments)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetSectionEnrollments(Guid id)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetSectionEnrollments)} action {ex}");
                return StatusCode(500, "Internal server error");
            }

        }
    }
}