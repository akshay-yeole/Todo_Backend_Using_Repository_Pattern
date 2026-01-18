using Todo.Contracts;
using Todo.Entities;

namespace Todo.Repository
{
    public class TodoRepository(RepositoryContext context) : RepositoryBase<TodoItem>(context), ITodoRepository
    {
        public void CreateTodoItem(TodoItem model)
        {
            Create(model);
        }

        public void DeleteTodoItem(TodoItem model)
        {
            Delete(model);
        }

        public IEnumerable<TodoItem> GetAllTodoItems()
        {
            return FindAll().OrderBy(x => x.Id).ToList();
        }

        public TodoItem GetTodoItemById(int id)
        {
            return FindByCondition(x => x.Id == id).FirstOrDefault();
        }

        public void UpdateTodoItem(TodoItem model)
        {
            Update(model);
        }
    }
}
