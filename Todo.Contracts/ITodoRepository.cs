using Todo.Entities;

namespace Todo.Contracts
{
    public interface ITodoRepository : IRepositoryBase<TodoItem>
    {
        IEnumerable<TodoItem> GetAllTodoItems();
        TodoItem GetTodoItemById(int id);
        void CreateTodoItem(TodoItem model);
        void UpdateTodoItem(TodoItem model);
        void DeleteTodoItem(TodoItem model);
    }
}
