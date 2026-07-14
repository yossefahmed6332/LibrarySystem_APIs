using LibrarySystem.DTOs.People.EmployeesDtos;
using LibrarySystem.Models;
namespace LibrarySystem.Interfaces.PeopleServices
{
    public interface IEmployeeService 
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();

        Task<EmployeeDto?> GetByIdAsync(int id);

        Task<EmployeeDto> CreateAsync(CreateEmployeeDto dto);

        Task<EmployeeDto> UpdateAsync(int id, UpdateEmployeeDto dto);

        Task DeleteAsync(int id);

        Task ChangeRoleAsync(int id, Role role);

        Task ChangeSalaryPerHourAsync(int id, decimal salary);
    }
}
