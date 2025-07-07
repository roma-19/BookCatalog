using BookCatalog.Application.DTOs.GenreDTOs;

namespace BookCatalog.Application.Interfaces;

public interface IGenreService
{
    Task<GenreResponseDto> CreateAsync(CreateGenreRequestDto request);
    Task<GenreResponseDto> UpdateAsync(UpdateGenreRequestDto request);
    Task DeleteAsync(int id);
    Task<GenreResponseDto> GetByIdAsync(int id);
    Task<List<GenreResponseDto>> GetAllAsync();
}