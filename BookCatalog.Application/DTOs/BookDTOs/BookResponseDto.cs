namespace BookCatalog.Application.DTOs.BookDTOs;

public class BookResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int? PublicationYear { get; set; }
    public string AuthorName { get; set; }
    public string PublisherName { get; set; }
    public string GenreName { get; set; }
}