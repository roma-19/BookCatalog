namespace BookCatalog.Application.DTOs.PublisherDTOs;

public class UpdatePublisherRequestDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string? Contact { get; set; }
}