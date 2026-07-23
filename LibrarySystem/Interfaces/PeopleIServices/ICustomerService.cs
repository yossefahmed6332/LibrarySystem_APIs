using LibrarySystem.DTOs.People.CustomerDtos;
using LibrarySystem.Models;

namespace LibrarySystem.Interfaces.PeopleServices
{
    public interface ICustomerService 
    {
        public Task RegisterCustomerAsync(CreateCustomerDto dto);
        public Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();


        public Task<CustomerDto?> GetCustomerByIdAsync(int id);


        public Task<CustomerDto> UpdateCustomerAsync(int id, UpdateCustomerDto dto);

        public Task DeleteCustomerAsync(int id);

        public Task ChangeMembershipTypeAsync(int id, MembershipType type);
    }
}
