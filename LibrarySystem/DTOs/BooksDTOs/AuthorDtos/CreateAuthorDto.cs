using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.DTOs.AuthorDtos
{
    public class CreateAuthorDto
    {
        [Required,MaxLength(25)]
        public string FirstName { get; set; } = null!;
        [Required, MaxLength(25)]
        public string LastName { get; set; } = null!;
        [Required, MaxLength(1000)]
        public string Biography { get; set; } = null!;
    }
}
