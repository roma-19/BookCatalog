using BookCatalog.Domain.Entities;
using BookCatalog.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Infrastructure.Repositories;

public class PublisherRepository : IPublisherRepository
{
    private readonly AppDbContext _context;

    public PublisherRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Publisher>> GetAllAsync()
    {
        return await _context.Publishers.ToListAsync();
    }

    public async Task<Publisher?> GetByIdAsync(int id)
    {
        return await _context.Publishers.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task CreateAsync(Publisher entity)
    {
        await _context.Publishers.AddAsync(entity);
    }

    public void Update(Publisher entity)
    {
        _context.Publishers.Update(entity);
    }

    public void Delete(Publisher entity)
    {
        _context.Publishers.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}