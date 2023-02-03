using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Services;
using TodoApi.Services.Dto;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _TodoService;

        public TodosController(ITodoService todoService)
        {
            _TodoService = todoService;
        }

        [HttpGet]
        [Route("all")]
        public List<Todo> GetAllTodos() => _TodoService.GetAllTodos();

        [HttpGet]
        [Route("user/{id}")]
        public List<Todo> GetTodosByUserId(int id) => _TodoService.GetTodosForUser(id);

    }
}
