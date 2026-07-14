using LibrarySystem.Data;
using LibrarySystem.DTOs.AuthorDtos;
using LibrarySystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Models;
namespace LibrarySystem.Service.BookService
{
    public class AuthorService : IAuthorService { 

  
        private readonly LibraryDbContext _context;
        public AuthorService(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync()
        {
            try
            {

                var authors = _context.TbAuthors.Select(a => new AuthorDto
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    Biography = a.Biography,
                    LastName = a.LastName
                }).ToListAsync();

                return await (authors);




            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving authors: {ex.Message}");
            }


        }
        public async Task<AuthorDto?> GetAuthorByIdAsync(int id)
        {
            try
            {

                var author = await _context.TbAuthors
                    .Where(a => a.Id == id)
                    .Select(a => new AuthorDto
                    {
                        Id = a.Id,
                        FirstName = a.FirstName,
                        Biography = a.Biography,
                        LastName = a.LastName
                    })
                    .FirstOrDefaultAsync();

                if (author == null)
                {
                    throw new Exception($"Author with ID {id} not found.");
                }
                return author;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the author: {ex.Message}");
            }

        }
        public async Task<AuthorDto> GetAuthorByNameAsync(string name)
        {
            try
            {
                var author = await _context.TbAuthors
                    .Where(a => a.FirstName + " " + a.LastName == name)
                    .Select(a => new AuthorDto
                    {
                        Id = a.Id,
                        FirstName = a.FirstName,
                        Biography = a.Biography,
                        LastName = a.LastName
                    })
                    .FirstOrDefaultAsync();
                if (author == null)
                {
                    throw new Exception($"Author with name '{name}' not found.");
                }
                return author;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the author: {ex.Message}");
            }
        }

        public async Task<AuthorDto> CreateAuthorAsync(CreateAuthorDto authorDto)
        {
            var exists = await _context.TbAuthors.AnyAsync(a =>
                a.FirstName == authorDto.FirstName &&
                a.LastName == authorDto.LastName);

            if (exists)
            {
                throw new InvalidOperationException(
                    $"Author '{authorDto.FirstName} {authorDto.LastName}' already exists.");
            }

            var author = new Author
            {
                FirstName = authorDto.FirstName,
                LastName = authorDto.LastName,
                Biography = authorDto.Biography
            };

            await _context.TbAuthors.AddAsync(author);
            await _context.SaveChangesAsync();

            return new AuthorDto
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Biography = author.Biography
            };
        }

        public async Task<AuthorDto> UpdateAuthorAsync(int id, UpdateAuthorDto authorDto)
        {
            var author = await _context.TbAuthors.FindAsync(id);
            if (author == null)
            {
                throw new Exception($"Author with ID {id} not found.");
            }
            author.FirstName = authorDto.FirstName;
            author.LastName = authorDto.LastName;
            author.Biography = authorDto.Biography;
            _context.TbAuthors.Update(author);
            await _context.SaveChangesAsync();
            return new AuthorDto
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Biography = author.Biography
            };
        }
        public async Task<bool> DeleteAuthorAsync(int id)
        {
            var author = await _context.TbAuthors.FindAsync(id);
            if (author == null)
            {
                throw new Exception($"Author with ID {id} not found.");
            }
            _context.TbAuthors.Remove(author);
            await _context.SaveChangesAsync();
            return true;

        }







    } 
}
