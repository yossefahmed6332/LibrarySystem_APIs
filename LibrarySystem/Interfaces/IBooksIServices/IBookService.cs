using LibrarySystem.DTOs.BookDtos;
namespace LibrarySystem.Interfaces
{
    public  interface IBookService
    {
        public Task<IEnumerable<BookDto>> GetAllBooksAsync();
        public Task<BookDto?> GetBookByIdAsync(int id);
        public Task<BookDto> GetBookByTitleAsync(string title);
        public Task<IEnumerable<BookDto>> GetBooksByAuthorAsync(string author);
        public Task <IEnumerable<BookDto>> GetBooksByAuthorIdAsync(int authorId);
        public Task<BookDto> CreateBookAsync(CreateBookDto bookDto);
        public Task<BookDto> UpdateBookAsync(int id, UpdateBookDto bookDto);
        public Task DeleteBookAsync(int id);
    }
}
