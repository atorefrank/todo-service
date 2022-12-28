
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoApi.Application.Todos.Commands.CreateTodos;
using TodoApi.Application.Todos.Queries.GetTodo;
namespace TodoApi.Api.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoController(IMediator mediator) => _mediator = mediator;
        

        [HttpPost]
        public async Task<IActionResult> Create(CreateTodoCommand command)
        {
            // We shall use the mediator library to send the create command to it's handler. The commands intercepted by mediatr are configured in the program.cs file. 
            var result = await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            var todos = await _mediator.Send(new GetTodoQuery());
            return Ok(todos);
        }
    }
}