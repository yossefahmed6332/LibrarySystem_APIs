using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace LibrarySystem.Data.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            //set propqerties
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
            builder.Property(a=>a.Password)     //set password
                .IsRequired();
            builder.Property(a => a.RegisterationDate)      //set registeration date
                .IsRequired();


        }
}
}
