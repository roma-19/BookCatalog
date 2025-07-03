namespace BookCatalog.Domain.Entities;

public class Publisher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string? Contact { get; set; }
    public ICollection<Book> Books { get; set; } =  new List<Book>();
}