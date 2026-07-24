using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibrarySystem.Interfaces.PeopleServices;
using LibrarySystem.DTOs.People.EmployeesDtos;
using Microsoft.AspNetCore.Authorization;
namespace LibrarySystem.Controllers.PeopleControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            return Ok(employee);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEmployeeDto dto)
        {
            var employee = await _employeeService.UpdateEmployeeAsync(id, dto);
            return Ok(employee);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("{id}/role")]
        public async Task<IActionResult> ChangeRole(int id, [FromBody] Models.Role role)
        {
            await _employeeService.ChangeEmployeeRoleAsync(id, role);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("{id}/salary")]
        public async Task<IActionResult> ChangeSalary(int id, [FromBody] decimal salary)
        {
            await _employeeService.ChangeEmployeeSalaryPerHourAsync(id, salary);
            return NoContent();
        }
        [Authorize(Roles = "Admin")]
        [HttpPatch("{id}/hours")]
        public async Task<IActionResult> ChangeHoursWorked(int id,[FromBody] int hoursWorked)
        {
            await _employeeService.ChangeEmployeeHoursWorked(id, hoursWorked);
            return NoContent();
        }

    }
}
