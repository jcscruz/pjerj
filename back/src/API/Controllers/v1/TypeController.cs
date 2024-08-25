using Application.UseCases.Types.Commands;
using Application.UseCases.Types.Queries.GetAllTypes;
using Application.UseCases.Types.Queries.GetTypeById;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("v1/types")]
    [Authorize]
    public class TypeController : ControllerBase
    {
        private readonly ILogger<TypeController> _logger;
        private readonly IMediator _mediator;

        public TypeController(ILogger<TypeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("{typeId:long}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTypeByIdResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetTypeByIdResponse>> Get(long typeId)
        {
            var response = await _mediator.Send(new GetTypeByIdQuery(typeId));
            if (response.UserType is null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateTypeResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateTypeResponse>> Create([FromBody] CreateTypeCommand createType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _mediator.Send(createType);
            return CreatedAtAction(nameof(Get), new { typeId = response.TypeId }, response);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetAllTypesResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetAllTypesResponse>>> GetAll()
        {
            var response = await _mediator.Send(new GetAllTypesQuery());
            return Ok(response.Items);
        }
    }
}