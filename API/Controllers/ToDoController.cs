using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Commands.CreateToDo;
using Application.Commands.DeleteToDo;
using Application.Queries.GetToDoList;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly ILogger<ToDoController> _logger;
        private readonly IMediator _mediator;   

        public ToDoController(ILogger<ToDoController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] GetToDoListQuery req, CancellationToken ct)
        {
            var result = await _mediator.Send(req, ct);
            return Ok(new
            {
                items = result
            });
        }

        [HttpPost(Name = "AddToDoItem")]
        public async Task<ActionResult<CreateToDoCommandResponse>> Add([FromBody] CreateToDoCommand createToDoCommand, CancellationToken ct)
        {
            var response = await _mediator.Send(createToDoCommand, ct);
            return response;
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            _ = await _mediator.Send(new DeleteToDoCommand { Id = id }, ct);
            return NoContent();
        }
    }
}
