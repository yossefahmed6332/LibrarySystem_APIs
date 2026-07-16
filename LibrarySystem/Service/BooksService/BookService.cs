using LibrarySystem.Data;
using LibrarySystem.DTOs.BookDtos;
using LibrarySystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Models;

namespace LibrarySystem.Service.BookService
{
   
    public class BookService:IBookService
    {
        private readonly LibraryDbContext _context;
        public BookService(LibraryDbContext context)
        {
            _context = context;
        }
        private BookDto CreateBookDto(Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Size = book.Size,
                Pages = book.Pages,
                Language = book.Language,
                Description = book.Description,
            };

        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var books = await _context.TbBooks
                .AsNoTracking()
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Pages = b.Pages,
                    Description = b.Description,
                    Language = b.Language
                })
                .ToListAsync();
            if (books.Count==0 )
            {
                throw new Exception("No books found.");
            }

            return books;
        }
        public async Task<BookDto?> GetBookByIdAsync(int id)
        {
            var book = await _context.TbBooks
                .AsNoTracking()
                .Where(b => b.Id == id)
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Pages = b.Pages,
                    Description = b.Description,
                    Language = b.Language
                })
                .FirstOrDefaultAsync();
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with ID {id} not found.");
            }
            return book;
        }

        public async Task<BookDto> GetBookByTitleAsync(string title)
        {
            var book = await _context.TbBooks
                .AsNoTracking()
                .Where(b => b.Title == title)
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Pages = b.Pages,
                    Description = b.Description,
                    Language = b.Language
                })
                .FirstOrDefaultAsync();
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with title '{title}' not found.");
            }
            return book;
        }

        public async Task<IEnumerable<BookDto>> GetBooksByAuthorAsync(string author)
        {
            var books = await _context.TbBooks
                .AsNoTracking()
                .Where(b => (b.Author.FirstName + " " + b.Author.LastName) == author)
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Pages = b.Pages,
                    Description = b.Description,
                    Language = b.Language
                })
                .ToListAsync();
            if (books.Count==0 )
            {
                throw new KeyNotFoundException($"No books found for author '{author}'.");
            }
            return books;
        }

        public async Task<IEnumerable<BookDto>> GetBooksByAuthorIdAsync(int authorId)
        {
            var books = await _context.TbBooks
                .AsNoTracking()
                .Where(b => b.Author.Id == authorId)
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Pages = b.Pages,
                    Description = b.Description,
                    Language = b.Language
                })
                .ToListAsync();
            if (books.Count==0)
            {
                throw new KeyNotFoundException($"No books found for author with ID {authorId}.");
            }
            return books;
        }

        public async Task<BookDto> CreateBookAsync(CreateBookDto bookDto)
        {
            var author = await _context.TbAuthors.FindAsync(bookDto.AuthorId);
            if (author == null)
            {
                throw new KeyNotFoundException($"Author with ID {bookDto.AuthorId} not found , " +
                    $"Add the author first.");
            }
            var category = await _context.TbCategories.FindAsync(bookDto.CategoryId);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with ID {bookDto.CategoryId} not found , " +
                    $"Add the category first."); 
            }
            Book book = new Book
            {
                Title = bookDto.Title,
                Size = bookDto.Size,
                Pages = bookDto.Pages,
                ISBN = bookDto.ISBN,
                PublishDate = bookDto.PublishDate,
                Publisher = bookDto.Publisher,
                Language = bookDto.Language,
                Description = bookDto.Description,
                Author = author,
                Category = category,


            };
            _context.TbBooks.Add(book);
            await _context.SaveChangesAsync();

            return CreateBookDto(book);
        }
        public async Task<BookDto> UpdateBookAsync(int id, UpdateBookDto bookDto)
        {
            var book = await _context.TbBooks.FindAsync(id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with ID {id} not found.");
            }
            var author = await _context.TbAuthors.FindAsync(bookDto.AuthorId);
            if (author == null)
            {
                throw new KeyNotFoundException($"Author with ID {bookDto.AuthorId} not found , " +
                    $"Add the author first.");
            }
            var category = await _context.TbCategories.FindAsync(bookDto.CategoryId);
            if (category == null)
            {
            
            throw new KeyNotFoundException($"Category with ID {bookDto.CategoryId} not found , " +
                $"Add the category first.");
        }

            book.Title = bookDto.Title;
            book.Size = bookDto.Size;
            book.Pages = bookDto.Pages;
            book.ISBN = bookDto.ISBN;
            book.PublishDate = bookDto.PublishDate;
            book.Publisher = bookDto.Publisher;
            book.Language = bookDto.Language;
            book.Description = bookDto.Description;
            book.Author = author;
            book.Category = category;


           
            await _context.SaveChangesAsync();
            return CreateBookDto(book);
        }
        public async Task DeleteBookAsync(int id)
        {
            var book = await _context.TbBooks.FindAsync(id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with ID {id} not found.");
            }
            _context.TbBooks.Remove(book);
            await _context.SaveChangesAsync();

        }




    }
}
