﻿namespace BookCatalog.Application.DTOs.AuthorDTOs;

public class AuthorResponseDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Biography { get; set; }
    public List<int> BookIds { get; set; }
}