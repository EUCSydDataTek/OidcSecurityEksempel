using TodoApi.Services.Dto;

namespace TodoApi.Services
{
    public interface ITodoService
    {
        Todo? EditTodo(Todo todo);
        List<Todo> GetAllTodos();
        Todo? GetTodoById(int Id);
        List<Todo> GetTodosForUser(int userid);

        public Todo CreateTodo(string Title, string Description);

        bool RemoveTodo(int id);
    }
}