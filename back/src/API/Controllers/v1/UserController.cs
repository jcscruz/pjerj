using Application.UseCases.Types.Queries.GetTypeByOrigin;
using Application.UseCases.Users.Commands.CreateUser;
using Application.UseCases.Users.Commands.DeleteUser;
using Application.UseCases.Users.Commands.UpdateUser;
using Application.UseCases.Users.Queries.GetAllUsers;
using Application.UseCases.Users.Queries.GetUserById;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("v1/users")]
    [Authorize]
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
        [HttpGet("{userId:long}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetUserByIdResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetUserByIdResponse>> Get(long userId)
        {
            var response = await _mediator.Send(new GetUserByIdQuery { UserID = userId });
            if (response.User is null)
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
        public async Task<ActionResult<IEnumerable<GetAllUsersResponse>>> GetAll(string? origin)
        {
            var response = await _mediator.Send(new GetAllUsersQuery(origin));
            return Ok(response.Users);
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateUserResponse>> Create([FromBody] CreateUserCommand createUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var query = await _mediator.Send(new GetTypeByOriginQuery(createUser.Origin));
            if (query.UserType is null)
            {
                return NotFound($"Type not found {createUser.Origin}");
            }
            createUser.SetType(query.UserType.Id);
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
        [HttpPut("{userId:long}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(Int64 userId, [FromBody] UpdateUserCommand updateUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            GetTypeByOriginResponse query = await _mediator.Send(new GetTypeByOriginQuery(updateUser.Origin));
            if (query.UserType is null)
            {
                return NotFound($"Type not found {updateUser.Origin}");
            }
            updateUser.SetUserId(userId);
            updateUser.SetTypeId(query.UserType.Id);
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
        [HttpDelete("{userId:long}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(long userId)
        {
            var response = await _mediator.Send(new DeleteUserCommand { UserId = userId });
            if (!response.Success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}