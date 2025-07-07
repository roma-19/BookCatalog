namespace BookCatalog.Application.DTOs.GenreDTOs;

public class GenreResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public List<int> BookIds { get; set; }
}