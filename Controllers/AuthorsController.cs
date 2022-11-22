using BookApi.Contracts;
using BookApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorRepository _authorRepository;
    public AuthorsController(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAuthorsAsync()
    {
        try
        {
            var authors = await _authorRepository.GetAuthorsAsync();

            if (!authors.Any())
                return NotFound("Authors not found.");

            return Ok(authors);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id}", Name = "GetAuthorById")]
    public async Task<IActionResult> GetAuthorAsync(int id)
    {
        try
        {
            var author = await _authorRepository.GetAuthorByIdAsync(id);

            if (author is null) return NotFound("Author not found.");

            return Ok(author);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id}/multipleResults")]
    public async Task<IActionResult> GetAuthorBooksMultipleResultsAsync(int id)
    {
        try
        {
            var author = await _authorRepository.GetAuthorBooksMultipleResultsAsync(id);

            if (author is null) return NotFound("Author not found.");

            return Ok(author);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("multipleMapping")]
    public async Task<IActionResult> GetAuthorsBooksMultipleMappingAsync()
    {
        try
        {
            var author = await _authorRepository.GetAuthorsBooksMultipleMappingAsync();

            return Ok(author);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateAuthorAsync(AuthorForCreationDTO author)
    {
        try
        {
            var createdAuthor = await _authorRepository.CreateAuthorAsync(author);

            return CreatedAtRoute("GetAuthorById", new { id = createdAuthor.Id }, createdAuthor);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAuthorAsync(int id, AuthorForUpdateDTO author)
    {
        try
        {
            var dbAuthor = await _authorRepository.GetAuthorByIdAsync(id);

            if (dbAuthor is null) return NotFound("Author not found.");

            await _authorRepository.UpdateAuthorAsync(id, author);

            return NoContent();
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAuthorAsync(int id)
    {
        try
        {
            var dbAuthor = await _authorRepository.GetAuthorByIdAsync(id);

            if (dbAuthor is null) return NotFound("Author not found.");

            await _authorRepository.DeleteAuthorAsync(id);

            return NoContent();
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
