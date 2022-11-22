using BookApi.DTOs;
using BookApi.Models;

namespace BookApi.Contracts;
public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAuthorsAsync();
    Task<Author> GetAuthorByIdAsync(int id);
    Task<Author> CreateAuthorAsync(AuthorForCreationDTO author);
    Task UpdateAuthorAsync(int id, AuthorForUpdateDTO author);
    Task DeleteAuthorAsync(int id);
    Task<Author> GetAuthorBooksMultipleResultsAsync(int id);
    Task<List<Author>> GetAuthorsBooksMultipleMappingAsync();
}
