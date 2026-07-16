using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.DTOs.CategoryDtos
{
    public class UpdateCategoryDto
    {

        [Required, MaxLength(50)]
        public string Name { get; set; } = null!; 

    }
}
