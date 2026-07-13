using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.DTOs.AuthorDtos
{
    public class AuthorDto
    {
        public int Id { get; set; } 
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Biography { get; set; } = null!;
    }
}
