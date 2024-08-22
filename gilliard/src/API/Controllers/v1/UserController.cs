using Application.UseCases.Users.Commands.CreateUser;
using Application.UseCases.Users.Commands.DeleteUser;
using Application.UseCases.Users.Commands.UpdateUser;
using Application.UseCases.Users.Queries.GetAllUsers;
using Application.UseCases.Users.Queries.GetFilteredUsers;
using Application.UseCases.Users.Queries.GetUserById;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("v1/users")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;

        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Get a user based on the userId
        /// </summary>
        /// <param name="userId">the user id</param>
        /// <remarks>
        /// Retrieve information about a specific user with the given userId.
        /// </remarks>
        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetUserByIdResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetUserByIdResponse>> Get(string userId)
        {
            var response = await _mediator.Send(new GetUserByIdQuery(userId));
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <remarks>
        /// Retrieve information about all users.
        /// </remarks>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetAllUsersResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetAllUsersResponse>>> GetAll()
        {
            var response = await _mediator.Send(new GetAllUsersQuery());
            return Ok(response);
        }

        /// <summary>
        /// Get users filtered by criteria
        /// </summary>
        /// <param name="getFilteredUsers">Filter criteria</param>
        /// <remarks>
        /// Retrieve information about users based on provided filter criteria.
        /// </remarks>
        [HttpGet("filter")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetFilteredUsersResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetFilteredUsersResponse>>> GetFiltered([FromQuery] GetFilteredUsersQuery getFilteredUsers)
        {
            var response = await _mediator.Send(getFilteredUsers);
            return Ok(response);
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="createUser">User creation details</param>
        /// <remarks>
        /// Create a new user with the provided details.
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateUserResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateUserResponse>> Create([FromBody] CreateUserCommand createUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _mediator.Send(createUser);
            return CreatedAtAction(nameof(Get), new { userId = response.UserId }, response);
        }

        /// <summary>
        /// Update an existing user
        /// </summary>
        /// <param name="userId">the user id</param>
        /// <param name="updateUser">User update details</param>
        /// <remarks>
        /// Update the details of an existing user.
        /// </remarks>
        [HttpPut("{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(string userId, [FromBody] UpdateUserCommand updateUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _mediator.Send(updateUser);
            if (response == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Delete an existing user
        /// </summary>
        /// <param name="userId">the user id</param>
        /// <remarks>
        /// Delete an existing user based on the provided userId.
        /// </remarks>
        [HttpDelete("{userId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(string userId)
        {
            var response = await _mediator.Send(new DeleteUserCommand(userId));
            if (!response.Success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}