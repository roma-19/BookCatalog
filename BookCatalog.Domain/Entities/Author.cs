﻿namespace BookCatalog.Domain.Entities;

public class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Biography  { get; set; }
    public ICollection<Book> Books { get; set; } =  new List<Book>();
}