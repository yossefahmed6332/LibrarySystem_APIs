using LibrarySystem.DTOs.People.EmployeesDtos;
using LibrarySystem.DTOs.People.CustomerDtos;
using LibrarySystem.Models;
namespace LibrarySystem.Interfaces.PeopleIServices
{
    public interface IAuthService
    {
        public Task RegisterCustomerAsync(CreateCustomerDto dto );
        public Task RegisterEmployeeAsync(CreateEmployeeDto dto);
        public Task<string> LoginUserAsync(string email, string password);
        public Task<string> GenerateTokenAsync(User user);


    }
}
