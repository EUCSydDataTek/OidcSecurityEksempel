using TodoApi.Services.Dto;

namespace TodoApi.Services
{
    public class TodoService : ITodoService
    {
        private static int IdCount = 0;

        private List<Todo> _Todos = new List<Todo>();

        public TodoService()
        {
            SeedTodos();
        }

        public List<Todo> GetAllTodos() => _Todos;

        public List<Todo> GetTodosForUser(int userid) => _Todos.Where(t => t.UserId == userid).ToList();

        public Todo? GetTodoById(int Id) => _Todos.FirstOrDefault(t => t.Id == Id);

        public Todo CreateTodo(string Title, string Description)
        {
            Todo newtodo = new Todo() { Title = Title, Description = Description, Id = IdCount };
            IdCount++;
            return newtodo;
        }

        public Todo? EditTodo(Todo todo)
        {
            Todo TodoToBeEdited = _Todos.Where(t => t.Id == todo.Id).FirstOrDefault();

            if (TodoToBeEdited == null)
            {
                return null;
            }

            TodoToBeEdited.Title = todo.Title;
            TodoToBeEdited.Description = todo.Description;

            return TodoToBeEdited;
        }

        public bool RemoveTodo(int id)
        {
            Todo TodoToBeDeleted = _Todos.Where(t => t.Id == id).FirstOrDefault();

            if (TodoToBeDeleted != null)
            {
                _Todos.Remove(TodoToBeDeleted);
                return true;
            }

            return false;
        }

        public void SeedTodos()
        {
            _Todos.Add(new Todo()
            {
                Id = 1,
                Title = "Test1",
                CreatedDate = DateTime.Now,
                Description = "Test1",
                UserId = 1
            });
            _Todos.Add(new Todo()
            {
                Id = 2,
                Title = "Test2",
                CreatedDate = DateTime.Now,
                Description = "Test2",
                UserId = 2
            });
            _Todos.Add(new Todo()
            {
                Id = 3,
                Title = "Test3",
                CreatedDate = DateTime.Now,
                Description = "Tes3t",
                UserId = 2
            });
            _Todos.Add(new Todo()
            {
                Id = 4,
                Title = "Test4",
                CreatedDate = DateTime.Now,
                Description = "Test4",
                UserId = 1
            });
            IdCount = 5;
        }

    }
}
