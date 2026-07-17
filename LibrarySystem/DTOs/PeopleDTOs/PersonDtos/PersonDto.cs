using LibrarySystem.DTOs.People.AddressDtos;
namespace LibrarySystem.DTOs.People.PersonDtos { 
public abstract class PersonDto
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime RegisterationDate { get; set; }

    public AddressDto Address { get; set; } = null!;
    }
}
