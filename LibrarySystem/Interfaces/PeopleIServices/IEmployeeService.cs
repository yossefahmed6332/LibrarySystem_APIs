using LibrarySystem.DTOs.People.EmployeesDtos;
using LibrarySystem.Models;
namespace LibrarySystem.Interfaces.PeopleServices
{
    public interface IEmployeeService 
    {
        public Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();

        public Task<EmployeeDto> GetEmployeeByIdAsync(int id);

        public  Task<EmployeeDto> UpdateEmployeeAsync(int id, UpdateEmployeeDto dto);

        public Task DeleteEmployeeAsync(int id);

        public Task ChangeEmployeeRoleAsync(int id, Role role);

        public Task ChangeEmployeeSalaryPerHourAsync(int id, decimal salary);

        public Task ChangeEmployeeHoursWorked(int id, int hoursWorked);
    }
}

