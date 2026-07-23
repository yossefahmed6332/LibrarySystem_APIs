using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace LibrarySystem.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //set properties 
            builder.Property(a => a.FirstName)  //set first name
                .IsRequired()
                .HasMaxLength(50); 
            builder.Property(a => a.LastName)   //set last name
                .IsRequired()
                .HasMaxLength (50);
            builder.Property(a=>a.PhoneNumber)  //set phone number
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(a => a.Email)      //set email
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(a=>a.PasswordHash)     //set password
                .IsRequired();
            builder.Property(a => a.RegisterationDate)      //set registeration date
                .IsRequired();

            //set indexes 
            builder.HasIndex(a => a.Email) //set email index
                .IsUnique();
            builder.HasIndex(a => a.PhoneNumber)
                .IsUnique(); 

            //relations 
            builder.HasOne(a => a.Address) //set address
                .WithMany(a=> a.Users)
                .HasForeignKey(a => a.AddressId)
                .OnDelete(DeleteBehavior.Restrict);


        }
}
}
