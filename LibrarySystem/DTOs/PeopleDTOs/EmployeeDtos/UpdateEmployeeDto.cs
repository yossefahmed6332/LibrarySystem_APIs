using LibrarySystem.DTOs.People.PersonDtos;
using LibrarySystem.Models;
using System.ComponentModel.DataAnnotations;
namespace LibrarySystem.DTOs.People.EmployeesDtos
{
    public class UpdateEmployeeDto : UpdateUserDto
    {
        [Required,Range(1.00,20000.00)]
        public decimal SalaryPerHour { get; set; }
        [Required,Range(1,int.MaxValue)]
        public int HoursWorked { get; set; }
        [Required, EnumDataType(typeof(Role))]
        public Role Role { get; set; }

    }
}
