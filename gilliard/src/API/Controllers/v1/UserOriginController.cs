using Application.UseCases.UserOrigin.Commands.CreateUserOrigin;
using Application.UseCases.UserOrigin.Commands.DeleteUserOrigin;
using Application.UseCases.UserOrigin.Commands.UpdateUserOrigin;
using Application.UseCases.UserOrigin.Queries.GetAllUserOrigin;
using Application.UseCases.UserOrigin.Queries.GetFilteredUserOrigin;
using Application.UseCases.UserOrigin.Queries.GetUserOriginById;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("v1/userOrigins")]
    public class UserOriginController : ControllerBase
    {
        private readonly ILogger<UserOriginController> _logger;
        private readonly IMediator _mediator;

        public UserOriginController(ILogger<UserOriginController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Get a userOrigin based on the userOriginId
        /// </summary>
        /// <param name="userOriginId">the userOrigin id</param>
        /// <remarks>
        /// Retrieve information about a specific userOrigin with the given userOriginId.
        /// </remarks>
        [HttpGet("{userOriginId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetUserOriginByIdResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetUserOriginByIdResponse>> Get(string userOriginId)
        {
            var response = await _mediator.Send(new GetUserOriginByIdQuery(userOriginId));
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        /// <summary>
        /// Get all userOrigins
        /// </summary>
        /// <remarks>
        /// Retrieve information about all userOrigins.
        /// </remarks>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetAllUserOriginResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetAllUserOriginResponse>>> GetAll()
        {
            var response = await _mediator.Send(new GetAllUserOriginQuery());
            return Ok(response);
        }

        /// <summary>
        /// Get userOrigins filtered by criteria
        /// </summary>
        /// <param name="getFilteredUserOrigin">Filter criteria</param>
        /// <remarks>
        /// Retrieve information about userOrigins based on provided filter criteria.
        /// </remarks>
        [HttpGet("filter")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetFilteredUserOriginResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetFilteredUserOriginResponse>>> GetFiltered([FromQuery] GetFilteredUserOriginQuery getFilteredUserOrigin)
        {
            var response = await _mediator.Send(getFilteredUserOrigin);
            return Ok(response);
        }

        /// <summary>
        /// Create a new userOrigin
        /// </summary>
        /// <param name="createUserOrigin">UserOrigin creation details</param>
        /// <remarks>
        /// Create a new userOrigin with the provided details.
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateUserOriginResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateUserOriginResponse>> Create([FromBody] CreateUserOriginCommand createUserOrigin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _mediator.Send(createUserOrigin);
            return CreatedAtAction(nameof(Get), new { userOriginId = response.UserOriginId }, response);
        }

        /// <summary>
        /// Update an existing userOrigin
        /// </summary>
        /// <param name="userOriginId">the userOrigin id</param>
        /// <param name="updateUserOrigin">UserOrigin update details</param>
        /// <remarks>
        /// Update the details of an existing userOrigin.
        /// </remarks>
        [HttpPut("{userOriginId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(string userOriginId, [FromBody] UpdateUserOriginCommand updateUserOrigin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _mediator.Send(updateUserOrigin);
            if (response == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Delete an existing userOrigin
        /// </summary>
        /// <param name="userOriginId">the userOrigin id</param>
        /// <remarks>
        /// Delete an existing userOrigin based on the provided userOriginId.
        /// </remarks>
        [HttpDelete("{userOriginId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(string userOriginId)
        {
            var response = await _mediator.Send(new DeleteUserOriginCommand(userOriginId));
            // if (!response.Success)
            // {
            //     return NotFound();
            // }

            return NoContent();
        }
    }
}