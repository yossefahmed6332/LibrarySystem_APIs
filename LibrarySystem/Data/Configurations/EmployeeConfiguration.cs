using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LibrarySystem.Models;
namespace LibrarySystem.Data.Configurations
{
    public class EmployeeConfiguration:IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            //set properties
            builder.Property(e => e.SalaryPerHour)
                .IsRequired();
            builder.Property(e => e.HoursWorked)
                .IsRequired();
            builder.Property(e => e.Role)
                .IsRequired();

        }
    }
}
