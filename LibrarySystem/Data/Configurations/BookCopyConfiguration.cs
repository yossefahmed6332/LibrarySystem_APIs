using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LibrarySystem.Models;
namespace LibrarySystem.Data.Configurations
{
    public class BookCopyConfiguration:IEntityTypeConfiguration<BookCopy>
    {

        public void Configure(EntityTypeBuilder<BookCopy> builder)
        {
            //set properties
           builder.Property(bc=> bc.Barcode).IsRequired().HasMaxLength(20);
           builder.Property(bc=> bc.Price).IsRequired().HasColumnType("decimal(18,2)");
           builder.Property(bc=> bc.Status).IsRequired().HasMaxLength(50);

            //set indexes 
            builder.HasIndex(bc => bc.Barcode)
                .IsUnique();


            //relationships
            builder.HasOne(bc => bc.Book)
                  .WithMany(b => b.BookCopies)
                  .HasForeignKey(bc => bc.BookId)
                  .OnDelete(DeleteBehavior.Cascade);
          
        }

    }
}
