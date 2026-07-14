using LibrarySystem.DTOs.People.PersonDtos;
using LibrarySystem.Models;
using LibrarySystem.DTOs.OperationDtos;
namespace LibrarySystem.DTOs.People.EmployeesDtos
{
    public class EmployeeDto:PersonDto
    {
        public decimal SalaryPerHour { get; set; }
        public int HoursWorked { get; set; }
        public Role Role { get; set; }
        public ICollection<OperationDto> Operations { get; set; } = new HashSet<OperationDto>();


    }
}
