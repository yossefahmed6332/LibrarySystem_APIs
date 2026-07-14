using LibrarySystem.DTOs.People.CustomerDtos;
using LibrarySystem.Models;

namespace LibrarySystem.Interfaces.PeopleServices
{
    public interface ICustomerService 
    {
        Task<IEnumerable<CustomerDto>> GetAllAsync();

        Task<CustomerDto?> GetByIdAsync(int id);

        Task<CustomerDto> CreateAsync(CreateCustomerDto dto);

        Task<CustomerDto> UpdateAsync(int id, UpdateCustomerDto dto);

        Task DeleteAsync(int id);

        Task ChangeMembershipTypeAsync(int id, MembershipType type);
    }
}
