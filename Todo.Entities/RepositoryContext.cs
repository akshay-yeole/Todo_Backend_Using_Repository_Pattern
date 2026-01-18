using Microsoft.EntityFrameworkCore;

namespace Todo.Entities;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
    {
    }

    public DbSet<TodoItem> MyProperty { get; set; } = null!;
}
