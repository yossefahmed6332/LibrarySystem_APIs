using LibrarySystem.Data;
using LibrarySystem.Interfaces.PeopleServices;
using LibrarySystem.DTOs.People.CustomerDtos;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Models; 
namespace LibrarySystem.Service.PeopleService
{
    public class CustomerService : ICustomerService
    {
        private readonly LibraryDbContext _context;
        public CustomerService(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await  _context.TbCustomers.Select(c => new CustomerDto
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email= c.Email,
                PhoneNumber = c.PhoneNumber,
                MembershipType = c.MembershipType,
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
            }).FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null)
            {
                throw new Exception($"Customer with ID {id} not found.");
            }

            return customer;
        }

        public async Task<CustomerDto> CreateCustomerAsync(CreateCustomerDto dto)
        {
            var customer = new Models.Customer
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                MembershipType = dto.MembershipType,
            };
            _context.TbCustomers.Add(customer);
            await _context.SaveChangesAsync();
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

        public async Task<CustomerDto> UpdateCustomerAsync(int id, UpdateCustomerDto dto)
        {
            var customer = _context.TbCustomers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                throw new Exception($"Customer with ID {id} not found.");
            }
            customer.FirstName = dto.FirstName;
            customer.LastName = dto.LastName;
            customer.Email = dto.Email;
            customer.PhoneNumber = dto.PhoneNumber;
            customer.MembershipType = dto.MembershipType;
            _context.TbCustomers.Update(customer);
            await _context.SaveChangesAsync();

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
            var customer = _context.TbCustomers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                throw new Exception($"Customer with ID {id} not found.");
            }
            _context.TbCustomers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeMembershipTypeAsync(int id, MembershipType type)
        {
            var customer = _context.TbCustomers.FirstOrDefault(c => c.Id == id);
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