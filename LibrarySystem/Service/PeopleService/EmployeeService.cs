using LibrarySystem.Data;
using LibrarySystem.DTOs.People.EmployeesDtos;
using LibrarySystem.Interfaces.PeopleServices;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Models;
namespace LibrarySystem.Service.PeopleService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly LibraryDbContext _context;

        public EmployeeService(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employees = await _context.TbEmployees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                Role = e.Role,
                SalaryPerHour = e.SalaryPerHour,
            }).ToListAsync();
            return employees;
        }

        public async Task<EmployeeDto> GetByIdAsync(int id)
        {
            var employee = await _context.TbEmployees
                .Where(e => e.Id == id)
                .Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    PhoneNumber = e.PhoneNumber,
                    Role = e.Role,
                    SalaryPerHour = e.SalaryPerHour,
                })
                .FirstOrDefaultAsync();

            if (employee == null)
            {
                throw new Exception($"Employee with ID {id} not found.");
            }

            return employee;
        }
        public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
        {
            var employee = await _context.TbEmployees
                .Where(e => e.Id == id)
                .Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    PhoneNumber = e.PhoneNumber,
                    Role = e.Role,
                    SalaryPerHour = e.SalaryPerHour,
                })
                .FirstOrDefaultAsync();
            if (employee == null)
            {
                throw new Exception($"Employee with ID {id} not found.");
            }
            return employee;
        }

        public async Task<EmployeeDto> CreateEmployeeAsync(CreateEmployeeDto dto)
        {
            var employee = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Role = dto.Role,
                HoursWorked = dto.HoursWorked,
                SalaryPerHour = dto.SalaryPerHour,
            };
            _context.TbEmployees.Add(employee);
            await _context.SaveChangesAsync();
            return new EmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Role = employee.Role,
                SalaryPerHour = employee.SalaryPerHour,
                HoursWorked = employee.HoursWorked
            };

        }

        public async Task<EmployeeDto> UpdateEmployeeAsync(int id, UpdateEmployeeDto dto)
        {
            var employee = await _context.TbEmployees.FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null)
            {
                throw new Exception($"Employee with ID {id} not found.");
            }

            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.Email = dto.Email;
            employee.PhoneNumber = dto.PhoneNumber;
            employee.Role = dto.Role;
            employee.SalaryPerHour = dto.SalaryPerHour;

            await _context.SaveChangesAsync();
            return new EmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Role = employee.Role,
                SalaryPerHour = employee.SalaryPerHour,
                HoursWorked = employee.HoursWorked
            };
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _context.TbEmployees.FindAsync(id);
            if (employee == null)
            {
                throw new Exception($"Employee with ID {id} not found.");
            }
            _context.TbEmployees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeEmployeeRoleAsync(int id, Role role)
        {
            var employee = await _context.TbEmployees.FindAsync(id);
            if (employee == null)
            {
                throw new Exception($"Employee with ID {id} not found.");
            }
            employee.Role = role;
            await _context.SaveChangesAsync();
        }
        public async Task ChangeEmployeeSalaryPerHourAsync(int id, decimal salary)
        {
            var employee = await _context.TbEmployees.FindAsync(id);
            if (employee == null)
            {
                throw new Exception($"Employee with ID {id} not found.");
            }
            employee.SalaryPerHour = salary;
            await _context.SaveChangesAsync();
        }

        public async Task ChangeEmployeeHoursWorked(int id, int hoursWorked)
        {
            var employee = await _context.TbEmployees.FindAsync(id);
            if (employee == null)
            {
                throw new Exception($"Employee with ID {id} not found.");
            }
            employee.HoursWorked = hoursWorked;
            await _context.SaveChangesAsync();
        }
    }
}