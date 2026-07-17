using LibrarySystem.DTOs.People.AddressDtos; 
namespace LibrarySystem.Interfaces.PeopleServices
{
    public interface IAddressService
    {
        public Task<IEnumerable<AddressDto>> GetAllAddressesAsync();

        public Task<AddressDto> GetAddressByIdAsync(int addressId);
        public Task<AddressDto> GetAddressByDataAsync(AddressDto addressDto);
        public Task<AddressDto> GetAddressByNonableDataAsync(AddressDto addressDto);
        public Task<AddressDto> CreateAddressAsync(CreateAddressDto addressDto);
        public Task<AddressDto> UpdateAddressAsync(int addressId, UpdateAddressDto addressDto);
        public Task DeleteAddressAsync(int addressId);

    }
}
