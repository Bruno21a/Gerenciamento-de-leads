using MediatR;
using Microsoft.AspNetCore.Mvc;
using LeadsAPI.CQRS.Queries;
using LeadsAPI.CQRS.Commands;
using LeadsAPI.Dtos;
using System.Threading.Tasks;

namespace LeadsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeadsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LeadsController(IMediator mediator) { _mediator = mediator; }

        [HttpGet("invited")]
        public async Task<IActionResult> GetInvited()
        {
            var result = await _mediator.Send(new GetInvitedLeadsQuery());
            return Ok(result);
        }

        [HttpGet("accepted")]
        public async Task<IActionResult> GetAccepted()
        {
            var result = await _mediator.Send(new GetAcceptedLeadsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _mediator.Send(new GetLeadByIdQuery(id));
            if (res == null) return NotFound();
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LeadCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _mediator.Send(new CreateLeadCommand(dto));
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LeadCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _mediator.Send(new UpdateLeadCommand(id, dto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLeadCommand(id));
            return NoContent();
        }

        [HttpPost("{id}/accept")]
        public async Task<IActionResult> Accept(int id)
        {
            var accepted = await _mediator.Send(new AcceptLeadCommand(id));
            if (accepted == null) return NotFound();
            return Ok(accepted);
        }

        [HttpPost("{id}/decline")]
        public async Task<IActionResult> Decline(int id)
        {
            await _mediator.Send(new DeclineLeadCommand(id));
            return NoContent();
        }
    }
}
