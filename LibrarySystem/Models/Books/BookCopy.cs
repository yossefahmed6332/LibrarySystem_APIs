using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
namespace LibrarySystem.Models
{
    public class BookCopy
    {
        public int Id { get; set; }
        
        public string Barcode { get; set; } = null!;
        public decimal Price { get; set; }
        public Status Status { get; set; }

        // Relation to Book
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;
        public ICollection<Operation> Operations { get; set; } = new HashSet<Operation>();
    }
}
