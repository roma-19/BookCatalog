using BookCatalog.Domain.Entities;
using BookCatalog.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Infrastructure.Repositories;

public class PublisherRepository : IPublisherRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<Publisher>  _dbSet;
     
    public PublisherRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<Publisher>();
    }
    
    public async Task<IEnumerable<Publisher>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<Publisher?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task CreateAsync(Publisher entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void UpdateAsync(Publisher entity)
    {
        _dbSet.Update(entity);
    }

    public void DeleteAsync(Publisher entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}