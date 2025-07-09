using FlightManage.Application.UseCases.FlightUseCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightManage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FlightController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllFlightsQueryRequest(), cancellationToken);
            return Ok(result);
        }

        [HttpGet("by-id/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetByIdFlightsQueryRequest(id), cancellationToken);
            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpGet("by-number/{flightNumber}")]
        public async Task<IActionResult> GetByFlightNumber([FromRoute] string flightNumber, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetByFlightNumberFlightsQueryRequest(flightNumber), cancellationToken);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
