using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.DTOs.People.AddressDtos
{
    public class UpdateAddressDto
    {
        [Required, MaxLength(25)]
        public string Country { get; set; } = null!;
        [MaxLength(25)]
        public string? State { get; set; }
        [Required, MaxLength(25)]
        public string City { get; set; } = null!;
        [Required, Range(1, int.MaxValue)]
        public int StreetNum { get; set; }
        [Required, MaxLength(100)]
        public string StreetName { get; set; } = null!;
        [Required, Range(1, int.MaxValue)]
        public int Building { get; set; }
        [Range(1, int.MaxValue)]
        public int Floor { get; set; }
        [MaxLength(25)]
        public string? Flat { get; set; }
    }
}
