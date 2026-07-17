using Microsoft.AspNetCore.Mvc;
using LibrarySystem.Interfaces;
using LibrarySystem.DTOs.BookCopyDtos;
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
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bookCopies = await _bookCopyService.GetAllBookCopiesAsync();
            return Ok(bookCopies);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var bookCopy = await _bookCopyService.GetBookCopyByIdAsync(id);
            return Ok(bookCopy);
        }
        [HttpGet("book/{bookId}")]
        public async Task<IActionResult> GetByBookId(int bookId)
        {
            var bookCopies = await _bookCopyService.GetBookCopiesByBookIdAsync(bookId);
            return Ok(bookCopies);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookCopyDto dto)
        {
            var bookCopy = await _bookCopyService.CreateBookCopyAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = bookCopy.Id }, bookCopy);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateBookCopyDto dto)
        {
            var bookCopy = await _bookCopyService.UpdateBookCopyAsync(id, dto);
            return Ok(bookCopy);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookCopyService.DeleteBookCopyAsync(id);
            return NoContent();
        }
    }
}
