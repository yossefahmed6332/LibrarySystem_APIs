using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
namespace LibrarySystem.Models
{
    public class BookCopy
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(20)]
        
        public string Barcode { get; set; } = null!;
        [Required, DeniedValues(18, 2)]
        public decimal Price { get; set; }
        [Required]
        public Status Status { get; set; }

        // Relation to Book
        [Required]
        public int BookId { get; set; }
        [Required]
        public Book Book { get; set; } = null!;
        public ICollection<Operation> Operations { get; set; } = new HashSet<Operation>();
    }
}
