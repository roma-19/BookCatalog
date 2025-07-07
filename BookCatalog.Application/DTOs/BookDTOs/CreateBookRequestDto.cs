namespace BookCatalog.Application.DTOs.BookDTOs;

public class CreateBookRequestDto
{
    public string Title { get; set; }
    public int AuthorId { get; set; }
}