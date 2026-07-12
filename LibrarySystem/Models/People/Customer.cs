using System.Collections.Generic;

namespace LibrarySystem.Models
{
    public class Customer : Person
    {
        public MembershipType MembershipType { get; set; }

        // Navigation: operations made by this customer (Borrow / Buy / Refund / Fine)
    }
}
