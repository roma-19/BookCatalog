using AutoMapper;
using BookCatalog.Application.DTOs.AuthorDTOs;
using BookCatalog.Application.Interfaces;
using BookCatalog.Domain.Entities;
using BookCatalog.Domain.Interfaces;

namespace BookCatalog.Application.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
    {
        _authorRepository = authorRepository ?? throw new ArgumentNullException(nameof(authorRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<AuthorResponseDto> CreateAsync(CreateAuthorRequestDto request)
    {
        var author = _mapper.Map<Author>(request);
        await _authorRepository.CreateAsync(author);
        await _authorRepository.SaveChangesAsync();
        return _mapper.Map<AuthorResponseDto>(author);
    }

    public async Task<AuthorResponseDto> UpdateAsync(UpdateAuthorRequestDto request)
    {
        var author = _mapper.Map<Author>(request);
        _authorRepository.Update(author);
        await _authorRepository.SaveChangesAsync();
        return _mapper.Map<AuthorResponseDto>(author);
    }

    public async Task DeleteAsync(int id)
    {
        var author = await _authorRepository.GetByIdAsync(id);
        if (author == null)
            throw new ArgumentException($"Author with ID {id} not found");

        _authorRepository.Delete(author);
        await _authorRepository.SaveChangesAsync();
    }

    public async Task<AuthorResponseDto> GetByIdAsync(int id)
    {
        var author = await _authorRepository.GetByIdAsync(id);
        if (author == null)
            throw new ArgumentException($"Author with ID {id} not found");

        return _mapper.Map<AuthorResponseDto>(author);
    }

    public async Task<List<AuthorResponseDto>> GetAllAsync()
    {
        var authors = await _authorRepository.GetAllAsync();
        return _mapper.Map<List<AuthorResponseDto>>(authors);
    }
}