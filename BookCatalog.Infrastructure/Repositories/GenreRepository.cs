using BookCatalog.Domain.Entities;
using BookCatalog.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Infrastructure.Repositories;

public class GenreRepository : IGenreRepository
{
    private readonly AppDbContext _context;

    public GenreRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Genre>> GetAllAsync()
    {
        return await _context.Genres.ToListAsync();
    }

    public async Task<Genre?> GetByIdAsync(int id)
    {
        return await _context.Genres.FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task CreateAsync(Genre entity)
    {
        await _context.Genres.AddAsync(entity);
    }

    public void Update(Genre entity)
    {
        _context.Genres.Update(entity);
    }

    public void Delete(Genre entity)
    {
        _context.Genres.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}