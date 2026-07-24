using Microsoft.AspNetCore.Mvc;
using LibrarySystem.Interfaces;
using LibrarySystem.DTOs.BookCopyDtos;
using Microsoft.AspNetCore.Authorization;
namespace LibrarySystem.Controllers.BooksControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCopyController : ControllerBase
    {
        private readonly IBookCopyService _bookCopyService;
        public BookCopyController(IBookCopyService bookCopyService)
        {
            _bookCopyService = bookCopyService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bookCopies = await _bookCopyService.GetAllBookCopiesAsync();
            return Ok(bookCopies);
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var bookCopy = await _bookCopyService.GetBookCopyByIdAsync(id);
            return Ok(bookCopy);
        }

        [Authorize]
        [HttpGet("book/{bookId}")]
        public async Task<IActionResult> GetByBookId(int bookId)
        {
            var bookCopies = await _bookCopyService.GetBookCopiesByBookIdAsync(bookId);
            return Ok(bookCopies);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookCopyDto dto)
        {
            var bookCopy = await _bookCopyService.CreateBookCopyAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = bookCopy.Id }, bookCopy);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateBookCopyDto dto)
        {
            var bookCopy = await _bookCopyService.UpdateBookCopyAsync(id, dto);
            return Ok(bookCopy);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookCopyService.DeleteBookCopyAsync(id);
            return NoContent();
        }
    }
}
