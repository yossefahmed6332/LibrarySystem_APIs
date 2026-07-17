using Microsoft.AspNetCore.Mvc;
using LibrarySystem.Interfaces;
using LibrarySystem.DTOs.AuthorDtos;
namespace LibrarySystem.Controllers.BooksControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {   
            var authors = await _authorService.GetAllAuthorsAsync();
            return Ok(authors);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAuthorDto dto)
        {
            var author = await _authorService.CreateAuthorAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = author.Id }, author);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAuthorDto dto)
        {
            var author = await _authorService.UpdateAuthorAsync(id, dto);
            return Ok(author);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _authorService.DeleteAuthorAsync(id);
            return NoContent();
        }

    }
}
