using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.DTOs.BookDtos
{
    public class BookDto
    {
        [Required, MaxLength(100)]
        public string Title { get; set; } = null!;

        [Required, MaxLength(50)]
        public string Size { get; set; } = null!;
        [Required]
        public int Pages { get; set; }
        [Required, MaxLength(1000)]
        public string Description { get; set; } = null!;
        [Required, MaxLength(50)]
        public string Language { get; set; } = null!;
        [Required, MaxLength(100)]
        public string AuthorName { get; set; } = null!;


    }
}
