using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LibrarySystem.Models;
namespace LibrarySystem.Data.Configurations
{
    public class OperationConfiguration:IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> builder)
        {
            //set properties
            builder.Property(a => a.CustomerId)
                .IsRequired();
            builder.Property(a => a.EmployeeId)
                .IsRequired();
            builder.Property(a => a.BookCopyId)
                .IsRequired();
            builder.Property(a => a.DeadLine)
                .IsRequired();
            builder.Property(a => a.PaymentMethod)
                .IsRequired();
            builder.Property(a => a.OperationType)
                .IsRequired();
            builder.Property(a => a.IsReturned)
                .IsRequired();

            //set relations 
            builder.HasOne(a => a.Customer)
                .WithMany(c => c.Operations)
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Employee)
                .WithMany(e => e.Operations)
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.BookCopy)
                .WithMany(bc => bc.Operations)
                .HasForeignKey(a => a.BookCopyId)
                .OnDelete(DeleteBehavior.Restrict); 


        }

    }
}
