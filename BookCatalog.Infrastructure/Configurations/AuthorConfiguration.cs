using BookCatalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookCatalog.Infrastructure.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("author");
        
        builder.HasKey(a => a.Id);
        
        builder.Property(a => a.FirstName)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(a => a.LastName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(a => a.DateOfBirth)
            .HasColumnType("date");

        builder.Property(a => a.Biography)
            .HasMaxLength(500);
        
        builder.HasMany(a => a.Books)
            .WithOne(b => b.Author)
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);;
    }
}