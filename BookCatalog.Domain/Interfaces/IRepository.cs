namespace BookCatalog.Domain.Interfaces;

public interface IRepository<T>  where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task CreateAsync(T entity);
    void UpdateAsync(T entity);
    void DeleteAsync(T  entity);
    Task SaveChangesAsync();
}