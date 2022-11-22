using BookApi.Contracts;
using BookApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookRepository _bookRepository;
    public BooksController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetBooksAsync()
    {
        try
        {
            var books = await _bookRepository.GetBooksAsync();

            if (!books.Any())
                return NotFound("Books not found.");

            return Ok(books);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id}", Name = "GetBookById")]
    public async Task<IActionResult> GetBookAsync(int id)
    {
        try
        {
            var book = await _bookRepository.GetBookByIdAsync(id);

            if (book is null) return NotFound("Book not found.");

            return Ok(book);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateBookAsync(BookForCreationDTO book)
    {
        try
        {
            var createdBook = await _bookRepository.CreateBookAsync(book);

            return CreatedAtRoute("GetBookById", new { id = createdBook.Id }, createdBook);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBookAsync(int id, BookForUpdateDTO book)
    {
        try
        {
            var dbBook = await _bookRepository.GetBookByIdAsync(id);

            if (dbBook is null) return NotFound("Book not found.");

            await _bookRepository.UpdateBookAsync(id, book);

            return NoContent();
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBookAsync(int id)
    {
        try
        {
            var dbBook = await _bookRepository.GetBookByIdAsync(id);

            if (dbBook is null) return NotFound("Book not found.");

            await _bookRepository.DeleteBookAsync(id);

            return NoContent();
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
