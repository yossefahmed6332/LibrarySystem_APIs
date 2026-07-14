using LibrarySystem.Models;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.DTOs.BookCopyDtos
{
    public class UpdateBookCopyDto
    {
        [Required]
        public string Barcode { get; set; } = null!;
        [Required]
        public decimal Price { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required,Range(1,int.MaxValue)]
        public int BookId { get; set; }


    }
}
