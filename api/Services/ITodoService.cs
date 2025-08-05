namespace TodoApp.Services
{
    public interface ITodoService
    {
        IEnumerable<Todo> GetAllTodos();
        Todo AddTodo(Todo todo);
    }
}