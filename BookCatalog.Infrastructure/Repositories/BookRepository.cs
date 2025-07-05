using BookCatalog.Domain.Entities;
using BookCatalog.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Infrastructure.Repositories;

public class BookRepository :  IRepository<Book>
{
    private readonly AppDbContext _context;
    private readonly DbSet<Book>  _dbSet;
     
    public BookRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<Book>();
    }
    
    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task CreateAsync(Book entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void UpdateAsync(Book entity)
    {
        _dbSet.Update(entity);
    }

    public void DeleteAsync(Book entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}