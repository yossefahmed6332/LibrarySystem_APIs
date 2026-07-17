using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace LibrarySystem.Data.Configurations
{
    public class AddressConfiguration: IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            //set properties
            builder.Property(a => a.Country)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(a => a.State)
                .HasMaxLength(100);
            builder.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(a => a.StreetNum)
                .IsRequired();
            builder.Property(a => a.Building)
                .IsRequired();
            builder.Property(a => a.Flat)
                .HasMaxLength(30);
            builder.Property(a=>a.StreetName)
                .IsRequired()
                .HasMaxLength(100);

         

        }
    }
}
