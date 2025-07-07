using BookCatalog.Application.DTOs.AuthorDTOs;

namespace BookCatalog.Application.Interfaces;

public interface IAuthorService
{
    Task<AuthorResponseDto> CreateAsync(CreateAuthorRequestDto request);
    Task<AuthorResponseDto> UpdateAsync(UpdateAuthorRequestDto request);
    Task DeleteAsync(int id);
    Task<AuthorResponseDto> GetByIdAsync(int id);
    Task<List<AuthorResponseDto>> GetAllAsync();
}