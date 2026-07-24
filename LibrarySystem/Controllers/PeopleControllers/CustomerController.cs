using LibrarySystem.DTOs.People.CustomerDtos;
using LibrarySystem.Interfaces.PeopleServices;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            return Ok(customer);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCustomerDto dto)
        {
            var customer = await _customerService.UpdateCustomerAsync(id, dto);

            return Ok(customer);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _customerService.DeleteCustomerAsync(id);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("{id}/membership")]
        public async Task<IActionResult> ChangeMembershipType(
            int id,
            [FromBody] MembershipType membershipType)
        {
            await _customerService.ChangeMembershipTypeAsync(id, membershipType);

            return NoContent();
        }
    }
}