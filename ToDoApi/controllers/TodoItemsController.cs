using Microsoft.AspNetCore.Mvc;
using MediatR;
using ToDoApi.Application.Commands.AddTodo;
using ToDoApi.Models;
using ToDoApi.Application.Queries.Todo.GetTodos;
using ToDoApi.Application.Commands.DeleteTodo;
using ToDoApi.Application.Commands.UpdateTodo;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        //private readonly ITodoService _service;
        private readonly IMediator _mediator;

        public TodoItemsController(IMediator mediator)
        {
            //_service = service;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var todos = await _mediator.Send(new GetTodosQuery());
            return Ok(todos);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetTodoByIdQuery(id));
            return result == null ? NotFound() : Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddTodoCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateTodoDto dto)
        {
            var command = new UpdateTodoCommand(id, dto.Title, dto.IsComplete, dto.CategoryId);

            var ok = await _mediator.Send(command);
            return ok ? NoContent() : NotFound();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _mediator.Send(new DeleteTodoCommand(id));
            return success ? NoContent() : NotFound();
        }

    }
}