using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibrarySystem.Data.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            // Configure the Author entity
            builder.Property(a => a.FirstName)      //FirstName
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(a => a.LastName)       //LastName
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(a => a.Biography)      //Biography
                .IsRequired()
                .HasMaxLength(1000);

            //set relations 
            builder.HasMany(a => a.Books)
                .WithMany(b => b.Authors)
                .UsingEntity(j => j.ToTable("AuthorBooks")); // Specify the join table name
           
        }
    }
}