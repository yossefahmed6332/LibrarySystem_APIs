namespace LibrarySystem.DTOs.People.AddressDtos
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string Country { get; set; } = null!;
        public string? State { get; set; }
        public string City { get; set; } = null!;
        public int StreetNum { get; set; }
        public string StreetName { get; set; } = null!;
        public int Building { get; set; }
        public int Floor { get; set; }
        public string? Flat { get; set; }

    }
}
