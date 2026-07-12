using System;

namespace LibrarySystem.Models
{
    public class Operation
    {
        public int Id { get; set; }

        // Relation to Customer
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!; 

        // Relation to Employee
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        // Relation to BookCopy
        public int BookCopyId { get; set; }
        public BookCopy BookCopy { get; set; } = null!;

        public DateTime DeadLine { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public OperationType OperationType { get; set; }
    }
}
