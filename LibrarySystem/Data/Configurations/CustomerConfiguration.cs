using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LibrarySystem.Models;
namespace LibrarySystem.Data.Configurations
{
    public class CustomerConfiguration:IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            //set properties
            builder.Property(c => c.MembershipType)
                 .IsRequired();
                

        }
    
    }
}
