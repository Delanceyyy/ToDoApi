using Microsoft.AspNetCore.Mvc;
using ToDoApi.Services;
using ToDoApi.Models;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoService _service;

        public TodoItemsController(ITodoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _service.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        // ✅ Create uses CreateTodoDto
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTodoDto dto)
        {
            var item = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        // ✅ Update uses UpdateTodoDto
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateTodoDto dto)
        {
            var ok = await _service.UpdateAsync(id, dto);
            return ok ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            return ok ? NoContent() : NotFound();
        }
    }
}