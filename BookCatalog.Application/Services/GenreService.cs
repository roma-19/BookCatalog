using AutoMapper;
using BookCatalog.Application.DTOs.GenreDTOs;
using BookCatalog.Application.Interfaces;
using BookCatalog.Domain.Entities;
using BookCatalog.Domain.Interfaces;

namespace BookCatalog.Application.Services;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _genreRepository;
    private readonly IMapper _mapper;

    public GenreService(IGenreRepository genreRepository, IMapper mapper)
    {
        _genreRepository = genreRepository ?? throw new ArgumentNullException(nameof(genreRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<GenreResponseDto> CreateAsync(CreateGenreRequestDto request)
    {
        var genre = _mapper.Map<Genre>(request);
        await _genreRepository.CreateAsync(genre);
        await _genreRepository.SaveChangesAsync();
        return _mapper.Map<GenreResponseDto>(genre);
    }

    public async Task<GenreResponseDto> UpdateAsync(UpdateGenreRequestDto request)
    {
        var genre = _mapper.Map<Genre>(request);
        _genreRepository.Update(genre);
        await _genreRepository.SaveChangesAsync();
        return _mapper.Map<GenreResponseDto>(genre);
    }

    public async Task DeleteAsync(int id)
    {
        var genre = await _genreRepository.GetByIdAsync(id);
        if (genre == null)
            throw new ArgumentException($"Genre with ID {id} not found");

        _genreRepository.Delete(genre);
        await _genreRepository.SaveChangesAsync();
    }

    public async Task<GenreResponseDto> GetByIdAsync(int id)
    {
        var genre = await _genreRepository.GetByIdAsync(id);
        if (genre == null)
            throw new ArgumentException($"Genre with ID {id} not found");

        return _mapper.Map<GenreResponseDto>(genre);
    }

    public async Task<List<GenreResponseDto>> GetAllAsync()
    {
        var genres = await _genreRepository.GetAllAsync();
        return _mapper.Map<List<GenreResponseDto>>(genres);
    }
}