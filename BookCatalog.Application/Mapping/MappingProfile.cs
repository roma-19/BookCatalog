using AutoMapper;
using BookCatalog.Application.DTOs.AuthorDTOs;
using BookCatalog.Application.DTOs.BookDTOs;
using BookCatalog.Application.DTOs.GenreDTOs;
using BookCatalog.Application.DTOs.PublisherDTOs;
using BookCatalog.Domain.Entities;

namespace BookCatalog.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateAuthorRequestDto, Author>();
        CreateMap<UpdateAuthorRequestDto, Author>();
        CreateMap<Author, AuthorResponseDto>()
            .ForMember(dest => dest.BookIds, 
                opt => opt.MapFrom(src => src.Books.Select(b => b.Id).ToList()));
        
        CreateMap<CreateBookRequestDto, Book>();
        CreateMap<UpdateBookRequestDto, Book>();
        CreateMap<Book, BookResponseDto>()
            .ForMember(dest => dest.AuthorName, 
                opt => opt.MapFrom(src => $"{src.Author.FirstName} {src.Author.LastName}"))
            .ForMember(dest => dest.GenreName, 
                opt => opt.MapFrom(src => src.Genre.Name))
            .ForMember(dest => dest.PublisherName, 
                opt => opt.MapFrom(src => src.Publisher.Name));
        
        CreateMap<CreateGenreRequestDto, Genre>();
        CreateMap<UpdateGenreRequestDto, Genre>();
        CreateMap<Genre, GenreResponseDto>()
            .ForMember(dest => dest.BookIds, 
                opt => opt.MapFrom(src => src.Books.Select(b => b.Id).ToList()));
        
        CreateMap<CreatePublisherRequestDto, Publisher>();
        CreateMap<UpdatePublisherRequestDto, Publisher>();
        CreateMap<Publisher, PublisherResponseDto>()
            .ForMember(dest => dest.BookIds, 
                opt => opt.MapFrom(src => src.Books.Select(b => b.Id).ToList()));
    }
}