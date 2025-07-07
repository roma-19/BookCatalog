using BookCatalog.Application.DTOs.PublisherDTOs;

namespace BookCatalog.Application.Interfaces;

public interface IPublisherService
{
    Task<PublisherResponseDto> CreateAsync(CreatePublisherRequestDto request);
    Task<PublisherResponseDto> UpdateAsync(UpdatePublisherRequestDto request);
    Task DeleteAsync(int id);
    Task<PublisherResponseDto> GetByIdAsync(int id);
    Task<List<PublisherResponseDto>> GetAllAsync();
}