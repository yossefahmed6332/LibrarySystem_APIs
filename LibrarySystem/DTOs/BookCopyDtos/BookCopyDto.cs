using LibrarySystem.Models;

namespace LibrarySystem.DTOs.BookCopyDtos
{
    public class BookCopyDto
    {
        public int Id { get; set; }
        public string Barcode { get; set; } = null!;
        public decimal Price { get; set; }
        public Status Status { get; set; }
        public int BookId { get; set; }
    }
}
