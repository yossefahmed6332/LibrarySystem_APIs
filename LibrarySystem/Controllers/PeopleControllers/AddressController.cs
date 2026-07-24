using LibrarySystem.DTOs.People.AddressDtos;
using LibrarySystem.Interfaces.PeopleServices;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var addresses = await _addressService.GetAllAddressesAsync();
            return Ok(addresses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var address = await _addressService.GetAddressByIdAsync(id);
            return Ok(address);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(AddressDto dto)
        {
            var address = await _addressService.GetAddressByDataAsync(dto);
            return Ok(address);
        }

        [HttpPost("search-nonable")]
        public async Task<IActionResult> SearchNonable(AddressDto dto)
        {
            var address = await _addressService.GetAddressByNonableDataAsync(dto);
            return Ok(address);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAddressDto dto)
        {
            var address = await _addressService.CreateAddressAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = address.Id },
                address);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateAddressDto dto)
        {
            var address = await _addressService.UpdateAddressAsync(id, dto);
            return Ok(address);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _addressService.DeleteAddressAsync(id);

            return NoContent();
        }
    }
}