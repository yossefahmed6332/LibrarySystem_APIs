using LibrarySystem.DTOs.CategoryDtos;
namespace LibrarySystem.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        public Task<CategoryDto?> GetCategoryByIdAsync(int id);
        public Task<CategoryDto> GetCategoryByNameAsync(string name);
        public Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto categoryDto);
        public Task<CategoryDto> UpdateCategoryAsync(int id, UpdateCategoryDto categoryDto);
        public Task DeleteCategoryAsync(int id);
    }
}
