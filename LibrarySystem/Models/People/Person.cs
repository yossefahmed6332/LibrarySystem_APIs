using System;
using System.Collections.Generic;

namespace LibrarySystem.Models
{
    // Base class - Employee and Customer inherit from it (Extends relation in the diagram)
    public abstract class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime RegisterationDate { get; set; }

        // Many-to-many relation (PersonsAddresses in the diagram)
        public ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
    }
}
