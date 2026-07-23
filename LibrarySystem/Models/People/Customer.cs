
namespace LibrarySystem.Models
{
    public class Customer : User
    {
        public MembershipType MembershipType { get; set; }

        // Navigation: operations made by this customer (Borrow / Buy / Refund / Fine)
        public ICollection<Operation> Operations { get; set; } = new HashSet<Operation>();
    }
}
