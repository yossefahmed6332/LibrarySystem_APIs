using LibrarySystem.Data;
using LibrarySystem.DTOs.People.CustomerDtos;
using LibrarySystem.Interfaces.PeopleServices;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace LibrarySystem.Service.PeopleService
{
    public class CustomerService : ICustomerService
    {
        private readonly LibraryDbContext _context;
        private readonly IAddressService _addressService;
        private readonly UserManager<User> _userManager;


        public CustomerService(LibraryDbContext context, IAddressService addressService, UserManager<User> userManager)
        {
            _context = context;
            _addressService = addressService;
            _userManager = userManager;
        }


        


       

        public async Task< Address> GetAddressAsync(int id)
        {
            var address = await _context.TbAddresses.Where(a => a.Id == id).Select(a => new Address
            {
                Id = a.Id,
                Country = a.Country,
                State = a.State,
                City = a.City,
                StreetNum = a.StreetNum,
                StreetName = a.StreetName,
                Building = a.Building,
                Flat = a.Flat,
                Floor = a.Floor,
            }).FirstOrDefaultAsync();

            if (address == null)
            {
                throw new Exception($"Address with Id{id} not found");
            }

            return address;
        }






        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _context.TbCustomers.Select(c => new CustomerDto
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                MembershipType = c.MembershipType,
                Address = _addressService.GetAddressByIdAsync(c.AddressId).Result,

            }).ToListAsync();



            return customers;


        }

        public async Task<CustomerDto?> GetCustomerByIdAsync(int id)
        {

            var customer = await _context.TbCustomers.Select(c => new CustomerDto
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                MembershipType = c.MembershipType,
                Address = _addressService.GetAddressByIdAsync(c.AddressId).Result,
            }).FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null)
            {
                throw new Exception($"Customer with ID {id} not found.");
            }

            return customer;
        }

     

        public async Task<CustomerDto> UpdateCustomerAsync(int id, UpdateCustomerDto dto)
        {

            var address = await GetAddressAsync(dto.Address.Id);

            var customer = await _context.TbCustomers.FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null)
            {
                throw new Exception($"Customer with ID {id} not found.");
            }

            customer.FirstName = dto.FirstName;
            customer.LastName = dto.LastName;
            customer.Email = dto.Email;
            customer.PhoneNumber = dto.PhoneNumber;
            customer.MembershipType = dto.MembershipType;
            customer.AddressId = address.Id;
            

            var result = await _userManager.UpdateAsync(customer);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
            }
            return new CustomerDto
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                MembershipType = customer.MembershipType,
            };

        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _context.TbCustomers.FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null)
            {
                throw new Exception($"Customer with ID {id} not found.");
            }
            _context.TbCustomers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeMembershipTypeAsync(int id, MembershipType type)
        {
            var customer = await _context.TbCustomers.FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null)
            {
                throw new Exception($"Customer with ID {id} not found.");
            }
            customer.MembershipType = type;
            _context.TbCustomers.Update(customer);
            await _context.SaveChangesAsync();
        }

    }
}