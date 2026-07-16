using LibrarySystem.Interfaces; 
using LibrarySystem.DTOs.CategoryDtos;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Data;
namespace LibrarySystem.Service.BookService
{
    public class CategoryService: ICategoryService
    {
        private readonly LibraryDbContext _context;
        public CategoryService(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _context.TbCategories
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();

            return categories;
        }
        public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
        {
            var category = await _context.TbCategories.FindAsync(id);
            if (category == null)
            {
                throw new Exception($"Category with ID {id} not found.");
            }
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public async Task<CategoryDto> GetCategoryByNameAsync(string name)
        {
            var category = await _context.TbCategories.FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
            if (category == null)
            {
                throw new Exception($"Category with name {name} not found.");
            }
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }
        public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto categoryDto)
        {
            var category = new Category
            {
                Name = categoryDto.Name
            };
            _context.TbCategories.Add(category);
            await _context.SaveChangesAsync();
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }
        public async Task<CategoryDto> UpdateCategoryAsync(int id, UpdateCategoryDto categoryDto)
        {
            var category = await _context.TbCategories.FindAsync(id);
            if (category == null)
            {
                throw new Exception($"Category with ID {id} not found.");
            }
            category.Name = categoryDto.Name;
            await _context.SaveChangesAsync();
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }
        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.TbCategories.FindAsync(id);
            if (category == null)
            {
                throw new Exception($"Category with ID {id} not found.");
            }
            _context.TbCategories.Remove(category);
            await _context.SaveChangesAsync();
        }


    }
}
