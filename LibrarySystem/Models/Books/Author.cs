using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Biography { get; set; } = null!;
        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
