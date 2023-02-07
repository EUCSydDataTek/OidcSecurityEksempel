using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;
using TodoApi.Services.Dto;

namespace TodoApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _TodoService;

        public TodoController(ITodoService todoService)
        {
            _TodoService = todoService;
        }

        [HttpGet(Name = "GetTodoById")]
        public Todo GetTodo(int id) {
            return _TodoService.GetTodoById(id) ?? new Todo();
        }

        [HttpPost]
        public IActionResult CreateTodo(CreateTodoModel model)
        {
           var newtodo = _TodoService.CreateTodo(model.Title,model.Description);
           
           return CreatedAtRoute("GetTodoById",new { id = newtodo.Id }, newtodo);
        }
    }
}
