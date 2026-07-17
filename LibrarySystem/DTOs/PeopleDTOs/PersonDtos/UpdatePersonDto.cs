using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.DTOs.People.PersonDtos
{
    public abstract class UpdatePersonDto
    {
        [Required, MaxLength(25)]
        public string FirstName { get; set; } = null!;
        [Required, MaxLength(25)]
        public string LastName { get; set; } = null!;
        [Required, Phone]
        public string PhoneNumber { get; set; } = null!;
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required, MaxLength(100)]
        public string Password { get; set; } = null!;
        [Required, Range(1, int.MaxValue)]
        public int AddressId { get; set; }
    }
}
