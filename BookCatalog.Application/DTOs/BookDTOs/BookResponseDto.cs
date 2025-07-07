namespace BookCatalog.Application.DTOs.BookDTOs;

public class BookResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int? PublicationYear { get; set; }
    public int AuthorId { get; set; }
    public int? GenreId { get; set; }
    public int? PublisherId { get; set; }
}