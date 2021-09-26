using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clarity.Application.Users.Command;
using Clarity.Application.Users.Queries;
using Clarity.Domain.Entities;
using Clarity.Presentation.Controllers.Base;
using Clarity.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Clarity.Presentation.Controllers
{
    [ApiController]
    [Route("api/User/Profile")]
    public class UserController : BaseController
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                List<User> users = await Mediator.Send(new GetAllUsersQuery());

                if (!users.Any())
                {
                    _logger.LogError(404, "GetAllUser - no user found");
                    return NotFound();
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(400, $"GetAllUser - Error: { ex.Message }");
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserProfileByIdentifier(Guid id)
        {
            try
            {
                User user = new User();

                user = await Mediator.Send(new GetUserProfileByIdQuery { Id = id });


                if (user == null)
                {
                    _logger.LogError(404, "GetUserProfileById - No Profile Found");

                    return NotFound();
                }

                GetUserProfileResponse userProfileResponse = new GetUserProfileResponse
                {
                    Name = user.Name,
                    Age = user.Age
                };

                return Ok(userProfileResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(400, $"GetuserProfileById - Error: {ex.Message}");
                return BadRequest();
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateUserProfile(SaveUserProfileRequest userProfileRequest)
        {
            try
            {
                if (userProfileRequest is null)
                {
                    throw new Exception("Invalid Request or Null ");
                }

                User user = new User
                {
                    Name = userProfileRequest.Name,
                    Age = userProfileRequest.Age
                };

                user = await Mediator.Send(new CreateUserProfileCommand { User = user });
                await WriteOnlyDbContext.SaveChangesAsync();

                return Accepted(user.UID);
            }
            catch (Exception ex)
            {
                _logger.LogError(400, $"CreateUserProfile Error {ex.Message}");
                return BadRequest();
            }
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateUserProfile(SaveUserProfileRequest updateUserProfileRequest)
        {
            try
            {
                if (updateUserProfileRequest.UID != Guid.Empty)
                {
                    User userProfile = await Mediator.Send(new GetUserProfileByIdQuery { Id = updateUserProfileRequest.UID });

                    if (userProfile != null)
                    {
                        userProfile.Name = updateUserProfileRequest.Name;
                        userProfile.Age = updateUserProfileRequest.Age;

                        userProfile = await Mediator.Send(new UpdateUserProfileCommand { User = userProfile });
                        await WriteOnlyDbContext.SaveChangesAsync();

                        _logger.LogInformation(100, "UpdateUserProfile - Profile Updated");

                        return Accepted(userProfile);
                    }
                    else
                    {
                        _logger.LogError(400, "UpdateUserProfile - No Profile found");
                        return NotFound();
                    }
                }
                else
                {
                    _logger.LogError(400, "UpdateUserProfile - no Identifier found");
                    return BadRequest();
                }
          
            } 
            catch(Exception ex)
            {
                _logger.LogError(400, $"UpdateUserProfile Error {ex.Message}");
                return BadRequest();
            }
        }


    }
}