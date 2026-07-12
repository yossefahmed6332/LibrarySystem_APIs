using System.Collections.Generic;

namespace LibrarySystem.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; } = null!;
        public string State { get; set; } = null!;
        public string City { get; set; } = null!;
        public int StreetNum { get; set; }
        public int Building { get; set; }
        public int Floor { get; set; }
        public string Flat { get; set; } = null!;


        // Many-to-many relation (PersonsAddresses in the diagram)
        public ICollection<Person>Persons { get; set; } = new List<Person>();
    }
}
