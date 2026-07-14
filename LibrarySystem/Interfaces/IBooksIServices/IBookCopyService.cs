using LibrarySystem.DTOs.BookCopyDtos;
namespace LibrarySystem.Interfaces
{
    public interface IBookCopyService
    {
        public Task<IEnumerable<BookCopyDto>> GetAllBookCopiesAsync();
        public Task<BookCopyDto?> GetBookCopyByIdAsync(int id);
        public Task<IEnumerable<BookCopyDto>> GetBookCopiesByBookIdAsync(int bookId);
        public Task<BookCopyDto> CreateBookCopyAsync(CreateBookCopyDto bookCopyDto);
        public Task<BookCopyDto> UpdateBookCopyAsync(int id, UpdateBookCopyDto bookCopyDto);
        public Task<bool> DeleteBookCopyAsync(int id);

    }
}
