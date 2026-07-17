using LibrarySystem.Data;
using LibrarySystem.DTOs.People.AddressDtos;
using LibrarySystem.Interfaces.PeopleServices;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Models;
namespace LibrarySystem.Service.PeopleService
{
    public class AddressService : IAddressService
    {

        private readonly LibraryDbContext _context;
        public AddressService(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AddressDto>> GetAllAddressesAsync()
        {
            var addresses = await _context.TbAddresses
                .Select(a => new AddressDto
                {
                    Id = a.Id,
                    Country = a.Country,
                    State = a.State,
                    City = a.City,
                    StreetNum = a.StreetNum,
                    StreetName = a.StreetName,
                    Building = a.Building,
                    Floor = a.Floor,
                    Flat = a.Flat,

                }).ToListAsync();
            return addresses;
        }
        public async Task<AddressDto> GetAddressByIdAsync(int addressId)
        {
            var address = await _context.TbAddresses
                .Where(a => a.Id == addressId)
                .Select(a => new AddressDto
                {
                    Id = a.Id,
                    Country = a.Country,
                    State = a.State,
                    City = a.City,
                    StreetNum = a.StreetNum,
                    StreetName = a.StreetName,
                    Building = a.Building,
                    Floor = a.Floor,
                    Flat = a.Flat
                })
                .FirstOrDefaultAsync();
            if (address == null)
            {
                throw new Exception($"Address with ID {addressId} not found.");
            }
            return address;


        }





        public async Task<AddressDto> GetAddressByDataAsync(AddressDto addressDto)
        {
            var address = await _context.TbAddresses
                .Where(a =>
                    a.Country == addressDto.Country &&
                    a.State == addressDto.State &&
                    a.City == addressDto.City &&
                    a.StreetNum == addressDto.StreetNum &&
                    a.StreetName == addressDto.StreetName &&
                    a.Building == addressDto.Building &&
                    a.Floor == addressDto.Floor &&
                    a.Flat == addressDto.Flat)
                .Select(a => new AddressDto
                {
                    Id = a.Id,
                    Country = a.Country,
                    State = a.State,
                    City = a.City,
                    StreetNum = a.StreetNum,
                    StreetName = a.StreetName,
                    Building = a.Building,
                    Floor = a.Floor,
                    Flat = a.Flat
                })
                .FirstOrDefaultAsync();

            if (address == null)
            {
                throw new Exception("Address not found.");
            }

            return address;
        }

        public async Task<AddressDto> GetAddressByNonableDataAsync(AddressDto addressDto)
        {
            var address = await _context.TbAddresses
                .Where(a =>
                    a.Country == addressDto.Country &&
                    a.State == addressDto.State &&
                    a.City == addressDto.City &&
                    a.StreetNum == addressDto.StreetNum &&
                    a.StreetName == addressDto.StreetName &&
                    a.Building == addressDto.Building
                    )
                .Select(a => new AddressDto
                {
                    Id = a.Id,
                    Country = a.Country,
                    State = a.State,
                    City = a.City,
                    StreetNum = a.StreetNum,
                    StreetName = a.StreetName,
                    Building = a.Building,

                })
                .FirstOrDefaultAsync();
            if (address == null)
            {
                throw new Exception("Address not found.");
            }
            return address;


        }

        public async Task<AddressDto> CreateAddressAsync(CreateAddressDto addressDto)
        {
            var address = new Address
            {
                Country = addressDto.Country,
                State = addressDto.State,
                City = addressDto.City,
                StreetNum = addressDto.StreetNum,
                StreetName = addressDto.StreetName,
                Building = addressDto.Building,
                Floor = addressDto.Floor,
                Flat = addressDto.Flat
            };
            _context.TbAddresses.Add(address);
            await _context.SaveChangesAsync();
            return new AddressDto
            {
                Id = address.Id,
                Country = address.Country,
                State = address.State,
                City = address.City,
                StreetNum = address.StreetNum,
                StreetName = address.StreetName,
                Building = address.Building,
                Floor = address.Floor,
                Flat = address.Flat
            };

        }


        public async Task<AddressDto> UpdateAddressAsync(int id, UpdateAddressDto addressDto)
        {
            var address = await _context.TbAddresses.FindAsync(id);
            if (address == null)
            {
                throw new Exception($"Address with ID {id} not found.");
            }
            address.Country = addressDto.Country;
            address.State = addressDto.State;
            address.City = addressDto.City;
            address.StreetNum = addressDto.StreetNum;
            address.StreetName = addressDto.StreetName;
            address.Building = addressDto.Building;
            address.Floor = addressDto.Floor;
            address.Flat = addressDto.Flat;
            await _context.SaveChangesAsync();
            return new AddressDto
            {
                Id = address.Id,
                Country = address.Country,
                State = address.State,
                City = address.City,
                StreetNum = address.StreetNum,
                StreetName = address.StreetName,
                Building = address.Building,
                Floor = address.Floor,
                Flat = address.Flat
            };


        }


        public async Task DeleteAddressAsync(int id)
        {
            var address = await _context.TbAddresses.FindAsync(id);
            if (address == null)
            {
                throw new Exception($"Address with ID {id} not found.");
            }
            _context.TbAddresses.Remove(address);
            await _context.SaveChangesAsync();


        }
    }
}