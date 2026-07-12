namespace LibrarySystem.Models
{
    public class Employee : Person
    {
        public decimal SalaryPerHour { get; set; }
        public int HoursWorked { get; set; }
        public Role Role { get; set; }
    }
}
