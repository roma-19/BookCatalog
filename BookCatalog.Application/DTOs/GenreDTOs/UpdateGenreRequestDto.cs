namespace BookCatalog.Application.DTOs.GenreDTOs;

public class UpdateGenreRequestDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}