using System.Collections.Generic;

namespace LibrarySystem.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; } = null!;
        public string? State { get; set; } 
        public string City { get; set; } = null!;
        public int StreetNum { get; set; }
        public int Building { get; set; }
        public int Floor { get; set; }
        public string Flat { get; set; } = null!;


        // one-to-many relation (PersonsAddresses in the diagram)
        public Person? Person { get; set; } 
    }
}
