using LibrarySystem.Models;
using System.ComponentModel.DataAnnotations;
namespace LibrarySystem.DTOs.BookCopyDtos
{
    public class CreateBookCopyDto
    {

        [Required,MaxLength(50)]
        public string Barcode { get; set; } = null!;
        [Required]
        public decimal Price { get; set; }
        [Required]
        public Status Status { get; set; } = Status.Available;
        [Required,Range(1,int.MaxValue)]
        public int BookId { get; set; }


    }
}
