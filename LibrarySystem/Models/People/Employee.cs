namespace LibrarySystem.Models
{
    public class Employee : User
    {
        public decimal SalaryPerHour { get; set; }
        public int HoursWorked { get; set; }
        public Role Role { get; set; }
        public ICollection<Operation> Operations { get; set; } = new HashSet<Operation>();
    }
}
