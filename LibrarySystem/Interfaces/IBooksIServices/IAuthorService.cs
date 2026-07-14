using LibrarySystem.DTOs.AuthorDtos;
namespace LibrarySystem.Interfaces
{
    public interface IAuthorService
    {
        public Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync();
        public Task<AuthorDto?> GetAuthorByIdAsync(int id);
        public Task<AuthorDto> GetAuthorByNameAsync(string name);
        public Task<AuthorDto> CreateAuthorAsync(CreateAuthorDto authorDto);
        public Task<AuthorDto> UpdateAuthorAsync(int id, UpdateAuthorDto authorDto);
        public Task<bool> DeleteAuthorAsync(int id);
    }
}
