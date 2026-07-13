using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibrarySystem.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)

        {
        // Configure the Book entity
            builder.Property(b => b.Title)          //Title
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(b => b.Size)           //Size
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(b => b.Pages)          //Pages
                .IsRequired();
            builder.Property(b => b.ISBN)           //ISBN
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(b => b.PublishDate)    //PublishDate
                .IsRequired();
            builder.Property(b => b.Publisher)      //Publisher
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(b => b.Language)       //Language
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(b => b.Description)    //Description
                .IsRequired()
                .HasMaxLength(1000);
                //Category


            //Set relations

           builder.HasOne(b => b.Category)      // Relation to Category
                .WithMany(c => c.Books);
           
        }
    }
}