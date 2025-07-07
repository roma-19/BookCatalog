using AutoMapper;
using BookCatalog.Application.Interfaces;
using BookCatalog.Application.Mapping;
using BookCatalog.Application.Services;
using BookCatalog.Domain.Interfaces;
using BookCatalog.Infrastructure;
using BookCatalog.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.API;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
        );
        
        services.AddAutoMapper(typeof(MappingProfile));
        
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped<IPublisherRepository, PublisherRepository>();
        
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IGenreService, GenreService>();
        services.AddScoped<IPublisherService, PublisherService>();
        
        return services;
    }
}