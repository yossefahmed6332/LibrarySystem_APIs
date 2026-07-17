namespace LibrarySystem.Models
{
    public enum Role
    {
        Cleaner,
        Cashier,
        Guard,
        Librarian,
        Manager
    }

    public enum Status
    {
        Sold,
        Borrowed,
        Available,
        Broken
    }

    public enum PaymentMethod
    {
        Card,
        Cash
    }

    public enum MembershipType
    {
        Normal,
        Silver,
        Gold,
        Platinum
    }

    public enum OperationType
    {
        Borrow,
        Buy,
        Refund,
        Fine
    }

    public enum UserType
    {
        Employee,
        Customer,
        Admin
    }
}
