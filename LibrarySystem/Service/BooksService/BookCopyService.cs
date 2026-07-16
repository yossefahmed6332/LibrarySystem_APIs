using LibrarySystem.Data; 
using LibrarySystem.DTOs.BookCopyDtos;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Interfaces; 
using LibrarySystem.Models;
namespace LibrarySystem.Service.BookService
{
    public class BookCopyService:IBookCopyService
    {
        private readonly LibraryDbContext _context;
        public BookCopyService(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BookCopyDto>> GetAllBookCopiesAsync()
        {
            return await _context.TbBooksCopies
                .Select(bc => new BookCopyDto
                {
                    Id = bc.Id,
                    Barcode = bc.Barcode,
                    Price = bc.Price,
                    Status = bc.Status,
                    BookId = bc.BookId
                })
                .ToListAsync();
        }

        public async Task<BookCopyDto?> GetBookCopyByIdAsync(int id)
        {
           return await _context .TbBooksCopies
                .Where(bc => bc.Id == id)
                .Select(bc => new BookCopyDto
                {
                    Id = bc.Id,
                    Barcode = bc.Barcode,
                    Price = bc.Price,
                    Status = bc.Status,
                    BookId = bc.BookId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<BookCopyDto>> GetBookCopiesByBookIdAsync(int bookId)
        {
            return await _context.TbBooksCopies
                .Where(bc => bc.BookId == bookId)
                .Select(bc => new BookCopyDto
                {
                    Id = bc.Id,
                    Barcode = bc.Barcode,
                    Price = bc.Price,
                    Status = bc.Status,
                    BookId = bc.BookId
                })
                .ToListAsync();
        }

        public async Task<BookCopyDto> CreateBookCopyAsync(CreateBookCopyDto bookCopyDto)
        {
            var bookCopy = new BookCopy
            {
                Barcode = bookCopyDto.Barcode,
                Price = bookCopyDto.Price,
                Status = bookCopyDto.Status,
                BookId = bookCopyDto.BookId
            };
            _context.TbBooksCopies.Add(bookCopy);
            await _context.SaveChangesAsync();
            return new BookCopyDto
            {
                Id = bookCopy.Id,
                Barcode = bookCopy.Barcode,
                Price = bookCopy.Price,
                Status = bookCopy.Status,
                BookId = bookCopy.BookId
            };
        }

        public async Task<BookCopyDto> UpdateBookCopyAsync(int id, UpdateBookCopyDto bookCopyDto)
        {
            var bookCopy = await _context.TbBooksCopies.FindAsync(id);
            if (bookCopy == null)
            {
                throw new KeyNotFoundException($"Book copy with ID {id} not found.");
            }
            bookCopy.Barcode = bookCopyDto.Barcode;
            bookCopy.Price = bookCopyDto.Price;
            bookCopy.Status = bookCopyDto.Status;
            bookCopy.BookId = bookCopyDto.BookId;
            await _context.SaveChangesAsync();
            return new BookCopyDto
            {
                Id = bookCopy.Id,
                Barcode = bookCopy.Barcode,
                Price = bookCopy.Price,
                Status = bookCopy.Status,
                BookId = bookCopy.BookId
            };
        }

        public async Task DeleteBookCopyAsync(int id)
        {
            var bookCopy = await _context.TbBooksCopies.FindAsync(id);
            if (bookCopy == null)
            {
                throw new KeyNotFoundException($"Book copy with ID {id} not found.");
            }
            _context.TbBooksCopies.Remove(bookCopy);
            await _context.SaveChangesAsync();
        }
    }
}
