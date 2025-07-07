using BookCatalog.Domain.Entities;
using BookCatalog.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Infrastructure.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<Author>  _dbSet;
     
    public AuthorRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<Author>();
    }
    
    public async Task<IEnumerable<Author>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<Author?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task CreateAsync(Author entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void UpdateAsync(Author entity)
    {
        _dbSet.Update(entity);
    }

    public void DeleteAsync(Author entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}