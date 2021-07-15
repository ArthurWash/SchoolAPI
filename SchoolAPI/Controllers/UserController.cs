using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Users.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public UsersController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            try
            {
                var users = _repository.User.GetAllUsers(trackChanges: false);
                return Ok(users);
                /*var organizationDto = _mapper.Map<IEnumerable<OrganizationDto>>(organizations);
                return Ok(organizationDto);*/

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetUsers)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetUsers(Guid id)
        {
            try
            {
                var user = _repository.User.GetUser(id, trackChanges: false); if (user == null)
                {
                    _logger.LogInfo($"User with id: {id} doesn't exist in the database.");
                    return NotFound();
                }
                else
                {
                    var UserDto = _mapper.Map<UserDto>(user);
                    return Ok(UserDto);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetUsers)} action {ex}");
                return StatusCode(500, "Internal server error");
            }

        }
    }
}