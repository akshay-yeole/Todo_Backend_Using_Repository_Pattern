using Todo.Contracts;
using Todo.Entities;

namespace Todo.Repository;

public class RepositoryWrapper(RepositoryContext repoContext) : IRepositoryWrapper
{
    private RepositoryContext _repoContext = repoContext;
    private ITodoRepository? _todo;

    public ITodoRepository Todo
    {
        get
        {
            if (_todo == null)
            {
                _todo = new TodoRepository(_repoContext);
            }
            return _todo;
        }
    }

    public void Save()
    {
        _repoContext.SaveChanges();
    }
}
