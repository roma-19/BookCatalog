using BookCatalog.Application.DTOs.BookDTOs;

namespace BookCatalog.Application.Interfaces;

public interface IBookService
{
    Task<BookResponseDto> CreateAsync(CreateBookRequestDto request);
    Task<BookResponseDto> UpdateAsync(UpdateBookRequestDto request);
    Task DeleteAsync(int id);
    Task<BookResponseDto> GetByIdAsync(int id);
    Task<List<BookResponseDto>> GetAllAsync();
}