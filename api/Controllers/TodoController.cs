using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private static List<TodoItem> _todos = new List<TodoItem>
        {
            new TodoItem { Id = 1, Task = "Learn .NET", IsDone = false },
            new TodoItem { Id = 2, Task = "Build Todo App", IsDone = false }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_todos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TodoItem item)
        {
            if (item == null || string.IsNullOrWhiteSpace(item.Task))
            {
                return BadRequest("Task cannot be empty");
            }

            item.Id = _todos.Count > 0 ? _todos.Max(t => t.Id) + 1 : 1;
            _todos.Add(item);
            
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }
    }
}