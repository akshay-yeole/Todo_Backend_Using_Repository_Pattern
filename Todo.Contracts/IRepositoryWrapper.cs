namespace Todo.Contracts
{
    public interface IRepositoryWrapper
    {
        ITodoRepository Todo { get; }
        void Save();
    }
}
