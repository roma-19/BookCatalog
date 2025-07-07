using BookCatalog.Domain.Entities;
using BookCatalog.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Infrastructure.Repositories;

public class BookRepository :  IBookRepository
{
    private readonly AppDbContext _context;
     
    public BookRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Book>> GetAllAsync()
    {
        return await _context.Books
            .Include(b => b.Genre)
            .Include(b => b.Author)
            .Include(b => b.Publisher)
            .ToListAsync();
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        return await _context.Books
            .Include(b => b.Genre)
            .Include(b => b.Author)
            .Include(b => b.Publisher)
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task CreateAsync(Book entity)
    {
        await _context.Books.AddAsync(entity);
    }

    public void Update(Book entity)
    {
        _context.Books.Update(entity);
    }

    public void Delete(Book entity)
    {
        _context.Books.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}