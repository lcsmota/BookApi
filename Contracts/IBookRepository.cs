using BookApi.DTOs;
using BookApi.Models;

namespace BookApi.Contracts;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetBooksAsync();
    Task<Book> GetBookByIdAsync(int id);
    Task<Book> CreateBookAsync(BookForCreationDTO book);
    Task UpdateBookAsync(int id, BookForUpdateDTO book);
    Task DeleteBookAsync(int id);
}
