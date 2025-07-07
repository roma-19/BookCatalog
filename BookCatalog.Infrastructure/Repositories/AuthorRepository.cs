using BookCatalog.Domain.Entities;
using BookCatalog.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Infrastructure.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly AppDbContext _context;

    public AuthorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Author>> GetAllAsync()
    {
        return await _context.Authors.ToListAsync();
    }

    public async Task<Author?> GetByIdAsync(int id)
    {
        return await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task CreateAsync(Author entity)
    {
        await _context.Authors.AddAsync(entity);
    }

    public void Update(Author entity)
    {
        _context.Authors.Update(entity);
    }

    public void Delete(Author entity)
    {
        _context.Authors.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}