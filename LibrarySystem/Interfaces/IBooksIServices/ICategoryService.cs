using LibrarySystem.DTOs.CategoryDtos;
namespace LibrarySystem.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        public Task<CategoryDto?> GetCategoryByIdAsync(int id);
        public Task<IEnumerable<CategoryDto>> GetCategoriesByNameAsync(string name);
        public Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto categoryDto);
        public Task<CategoryDto> UpdateCategoryAsync(int id, UpdateCategoryDto categoryDto);
        public Task<bool> DeleteCategoryAsync(int id);
        public Task<bool> DeleteCategoryAsync(string id);
    }
}
