using BookCatalog.Domain.Entities;
using BookCatalog.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Infrastructure.Repositories;

public class GenreRepository : IGenreRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<Genre>  _dbSet;
     
    public GenreRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<Genre>();
    }
    
    public async Task<IEnumerable<Genre>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<Genre?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task CreateAsync(Genre entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void UpdateAsync(Genre entity)
    {
        _dbSet.Update(entity);
    }

    public void DeleteAsync(Genre entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}