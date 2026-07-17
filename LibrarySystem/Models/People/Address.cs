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
        public string StreetName { get; set; } = null!;
        public int Building { get; set; }
        public int Floor { get; set; }
        public string? Flat { get; set; }


        // one-to-one relation (PersonsAddresses in the diagram)

        public ICollection<Person> Persons { get; set; } = new HashSet<Person>();
    }
}
