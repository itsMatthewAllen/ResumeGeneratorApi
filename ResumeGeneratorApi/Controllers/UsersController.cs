#pragma warning restore 1591

using Microsoft.AspNetCore.Mvc;
using ResumeGeneratorApi.DTOs;
using ResumeGeneratorApi.Mappings;
using ResumeGeneratorApi.Services;

namespace ResumeGeneratorApi.Controllers
{
    /// <summary>
    /// API endpoints for managing users.
    /// </summary>
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="userService">The user service instance to handle business logic.</param>
        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Retrieves a user by ID.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <returns>The user object, if found; otherwise, null.</returns>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> GetUser(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(UserMapper.ToDto(user));
        }

        /// <summary>
        /// Creates a user.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <returns>The newly created user.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] string email)
        {
            var user = await _userService.CreateAsync(email);

            return CreatedAtAction(
                nameof(GetUser),
                new { id = user.Id },
                UserMapper.ToDto(user)
            );
        }
    }
}
