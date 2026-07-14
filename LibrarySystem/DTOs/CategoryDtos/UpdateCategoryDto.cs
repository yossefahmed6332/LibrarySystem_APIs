using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.DTOs.CategoryDtos
{
    public class UpdateCategoryDto
    {
        [Required]
        public int CategoryId { get; set; }
        [Required, MaxLength(50)]
        public string CategoryName { get; set; } = null!; 

    }
}
