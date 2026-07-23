
using Microsoft.AspNetCore.Identity;

namespace LibrarySystem.Models
{
    // Base class - Employee and Customer inherit from it (Extends relation in the diagram)
    public abstract class User : IdentityUser<int>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime RegisterationDate { get; set; }

        public Address Address { get; set; } = null!;
        public int AddressId { get; set; } // Foreign key for Address
    }
}
