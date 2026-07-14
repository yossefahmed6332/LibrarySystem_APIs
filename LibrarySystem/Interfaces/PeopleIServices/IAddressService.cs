using LibrarySystem.DTOs.People.AddressDtos; 
namespace LibrarySystem.Interfaces.PeopleServices
{
    public interface IAddressService
    {
        public Task<AddressDto> GetAddressByIdAsync(string addressId);
        public Task<AddressDto> GetAddressByDataAsycn(AddressDto addressDto);
        public Task<AddressDto> CreateAddressAsync(CreateAddressDto addressDto);
        public Task<AddressDto> UpdateAddressAsync(string addressId, UpdateAddressDto addressDto);
        public Task<AddressDto> DeleteAddressAsync(string addressId);

    }
}
