using LibrarySystem.DTOs.People.CustomerDtos;
using LibrarySystem.DTOs.People.EmployeesDtos;
using LibrarySystem.Interfaces.PeopleIServices;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register/customer")]
        public async Task<IActionResult> RegisterCustomer([FromBody] CreateCustomerDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _authService.RegisterCustomerAsync(dto);

            return Ok(new
            {
                Message = "Customer registered successfully."
            });
        }

        [HttpPost("register/employee")]
        public async Task<IActionResult> RegisterEmployee([FromBody] CreateEmployeeDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _authService.RegisterEmployeeAsync(dto);

            return Ok(new
            {
                Message = "Employee registered successfully."
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] string email, [FromBody] string password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var token = await _authService.LoginUserAsync(email, password);

            return Ok(new
            {
                Token = token
            });
        }
    }
}