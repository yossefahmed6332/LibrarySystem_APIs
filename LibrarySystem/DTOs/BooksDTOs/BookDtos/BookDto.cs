using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.DTOs.BookDtos
{
    public class BookDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Size { get; set; } = null!;
        public int Pages { get; set; }
        public string Description { get; set; } = null!;
        public string Language { get; set; } = null!;
        public string AuthorName { get; set; } = null!;


    }
}
