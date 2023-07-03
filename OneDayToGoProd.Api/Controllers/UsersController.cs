using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OneDayToGoProd.Api.Dtos;
using OneDayToGoProd.Domain.Interfaces.Repository;
using OneDayToGoProd.Domain.Models;

namespace OneDayToGoProd.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repo;
        public UsersController(IMapper mapper, IUserRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _repo.GetUsersAsync();
            var usersView = _mapper.Map<List<UserDto>>(users);

            return Ok(usersView);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _repo.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userView = _mapper.Map<UserDto>(user);

            return Ok(userView);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto user)
        {
            var domainUser = _mapper.Map<User>(user);
            await _repo.CreateUserAsync(domainUser);
            var userView = _mapper.Map<UserDto>(domainUser);

            return CreatedAtAction(nameof(GetUserById), new { id = userView.Id }, userView);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto userUpdate)
        {
            var domainUser = _mapper.Map<User>(userUpdate);
            domainUser.Id = id;

            if (domainUser == null)
            {
                return NotFound();
            };

            await _repo.UpdateUserAsync(domainUser);

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _repo.DeleteUserAsync(id);

            if (user == null)
            {
                return NotFound();
            };

            return NoContent();
        }


        // User Profiles Controller

        [HttpGet]
        [Route("{userId}/profiles/{id}")]
        public async Task<IActionResult> GetUserProfile(int userId, int id)
        {
            var profile = await _repo.GetUserProfileByIdAsync(userId, id);

            if(profile == null) 
            {
                return NotFound();
            }

            var profileView = _mapper.Map<UserProfileDto>(profile);

            return Ok(profileView);
        }

        [HttpPost]
        [Route("{userId}/profiles")]
        public async Task<IActionResult> CreateUserProfile(int userId, [FromBody] CreateUserProfileDto profile)
        {
            var domainUserProfile = _mapper.Map<UserProfile>(profile);
            domainUserProfile.Id = userId;

            await _repo.CreateUserProfileAsync(userId, domainUserProfile);

            var profileView = _mapper.Map<UserProfileDto>(domainUserProfile);

            return CreatedAtAction(nameof(GetUserProfile), new { userId = userId, id = profileView.Id }, profileView);
        }

        [HttpPut]
        [Route("{userId}/profiles")]
        public async Task<IActionResult> UpdateUserProfile(int userId, [FromBody] UpdateUserProfileDto profile)
        {
            var domainUserProfile = _mapper.Map<UserProfile>(profile);
            domainUserProfile.Id = userId;

            await _repo.UpdateUserProfileAsync(userId, domainUserProfile);

            return NoContent();
        }

        [HttpDelete]
        [Route("{userId}/profiles{id}")]
        public async Task<IActionResult> DeleteUserProfile(int userId, int id)
        {
            var profile = await _repo.DeleteUserProfileAsync(userId, id);

            if (profile == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
