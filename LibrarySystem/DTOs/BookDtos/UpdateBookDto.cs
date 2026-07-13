using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.DTOs.BookDtos
{
    public class UpdateBookDto
    {
        [Required, MaxLength(100)]
        public string Title { get; set; } = null!;
        [Required, MaxLength(50)]
        public string Size { get; set; } = null!;
        [Required]
        public int Pages { get; set; }
        [Required, MaxLength(20)]
        public string ISBN { get; set; } = null!;
        [Required]
        public DateTime PublishDate { get; set; }
        [Required, MaxLength(100)]
        public string Publisher { get; set; } = null!;
        [Required, MaxLength(50)]
        public string Language { get; set; } = null!;   
        [Required,MaxLength(1000)]
        public string? Description { get; set; } 
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int CategoryId { get; set; }


    }
}
