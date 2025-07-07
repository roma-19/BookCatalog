using AutoMapper;
using BookCatalog.Application.DTOs.PublisherDTOs;
using BookCatalog.Application.Interfaces;
using BookCatalog.Domain.Entities;
using BookCatalog.Domain.Interfaces;

namespace BookCatalog.Application.Services;

public class PublisherService : IPublisherService
{
    private readonly IPublisherRepository _publisherRepository;
    private readonly IMapper _mapper;

    public PublisherService(IPublisherRepository publisherRepository, IMapper mapper)
    {
        _publisherRepository = publisherRepository ?? throw new ArgumentNullException(nameof(publisherRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<PublisherResponseDto> CreateAsync(CreatePublisherRequestDto request)
    {
        var publisher = _mapper.Map<Publisher>(request);
        await _publisherRepository.CreateAsync(publisher);
        await _publisherRepository.SaveChangesAsync();
        return _mapper.Map<PublisherResponseDto>(publisher);
    }

    public async Task<PublisherResponseDto> UpdateAsync(UpdatePublisherRequestDto request)
    {
        var publisher = _mapper.Map<Publisher>(request);
        _publisherRepository.Update(publisher);
        await _publisherRepository.SaveChangesAsync();
        return _mapper.Map<PublisherResponseDto>(publisher);
    }

    public async Task DeleteAsync(int id)
    {
        var publisher = await _publisherRepository.GetByIdAsync(id);
        if (publisher == null)
            throw new ArgumentException($"Publisher with ID {id} not found");

        _publisherRepository.Delete(publisher);
        await _publisherRepository.SaveChangesAsync();
    }

    public async Task<PublisherResponseDto> GetByIdAsync(int id)
    {
        var publisher = await _publisherRepository.GetByIdAsync(id);
        if (publisher == null)
            throw new ArgumentException($"Publisher with ID {id} not found");

        return _mapper.Map<PublisherResponseDto>(publisher);
    }

    public async Task<List<PublisherResponseDto>> GetAllAsync()
    {
        var publishers = await _publisherRepository.GetAllAsync();
        return _mapper.Map<List<PublisherResponseDto>>(publishers);
    }
}