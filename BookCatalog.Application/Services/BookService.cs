using AutoMapper;
using BookCatalog.Application.DTOs.BookDTOs;
using BookCatalog.Application.Interfaces;
using BookCatalog.Domain.Entities;
using BookCatalog.Domain.Interfaces;

namespace BookCatalog.Application.Services;

public class BookService :  IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public BookService(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<BookResponseDto> CreateAsync(CreateBookRequestDto request)
    {
        var book = _mapper.Map<Book>(request);
        await _bookRepository.CreateAsync(book);
        await _bookRepository.SaveChangesAsync();
        return _mapper.Map<BookResponseDto>(book);
    }

    public async Task<BookResponseDto> UpdateAsync(UpdateBookRequestDto request)
    {
        var book = _mapper.Map<Book>(request);
        _bookRepository.Update(book);
        await _bookRepository.SaveChangesAsync();
        return _mapper.Map<BookResponseDto>(book);
    }

    public async Task DeleteAsync(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        if (book == null)
            throw new ArgumentException($"Book with ID {id} not found");

        _bookRepository.Delete(book);
        await _bookRepository.SaveChangesAsync();
    }

    public async Task<BookResponseDto> GetByIdAsync(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        if (book == null)
            throw new ArgumentException($"Book with ID {id} not found");

        return _mapper.Map<BookResponseDto>(book);
    }

    public async Task<List<BookResponseDto>> GetAllAsync()
    {
        var books = await _bookRepository.GetAllAsync();
        return _mapper.Map<List<BookResponseDto>>(books);
    }
}