using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibrarySystem.Interfaces.PeopleServices;
using LibrarySystem.DTOs.People.EmployeesDtos;
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
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            return Ok(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeDto dto)
        {
            var employee = await _employeeService.CreateEmployeeAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEmployeeDto dto)
        {
            var employee = await _employeeService.UpdateEmployeeAsync(id, dto);
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return NoContent();
        }

        [HttpPatch("{id}/role")]
        public async Task<IActionResult> ChangeRole(int id, [FromBody] Models.Role role)
        {
            await _employeeService.ChangeEmployeeRoleAsync(id, role);
            return NoContent();
        }
        [HttpPatch("{id}/salary")]
        public async Task<IActionResult> ChangeSalary(int id, [FromBody] decimal salary)
        {
            await _employeeService.ChangeEmployeeSalaryPerHourAsync(id, salary);
            return NoContent();
        }
        [HttpPatch("{id}/hours")]
        public async Task<IActionResult> ChangeHoursWorked(int id,[FromBody] int hoursWorked)
        {
            await _employeeService.ChangeEmployeeHoursWorked(id, hoursWorked);
            return NoContent();
        }

    }
}
