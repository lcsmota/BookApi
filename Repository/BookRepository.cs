using System.Data;
using BookApi.Context;
using BookApi.Contracts;
using BookApi.DTOs;
using BookApi.Models;
using Dapper;

namespace BookApi.Repository;

public class BookRepository : IBookRepository
{
    private readonly DapperContext _context;
    public BookRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<Book> GetBookByIdAsync(int id)
    {
        var query = @"SELECT
                        Id, Title, Publisher, Pages, ISBN, PublishedAt, AuthorId
                    FROM 
                        Books
                    WHERE 
                        Id = @Id";

        using var connection = _context.CreateConnection();

        var book = await connection.QuerySingleOrDefaultAsync<Book>(query, new { id });

        return book;
    }

    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
        var query = @"SELECT 
                        Id, Title, Publisher, Pages, ISBN, PublishedAt, AuthorId
                    FROM 
                        Books";

        using var connection = _context.CreateConnection();

        var books = await connection.QueryAsync<Book>(query);

        return books.ToList();
    }
    public async Task<Book> CreateBookAsync(BookForCreationDTO book)
    {
        var query = @"INSERT INTO [dbo].[Books](
                        Title, Publisher, Pages, ISBN, PublishedAt, AuthorId)
                    VALUES(
                        @title, @publisher, @pages, @isbn, @publishedAt, @authorId);
                    
                    SELECT CAST(SCOPE_IDENTITY() as int)";

        var parameters = new DynamicParameters();
        parameters.Add("title", book.Title, DbType.String);
        parameters.Add("publisher", book.Publisher, DbType.String);
        parameters.Add("pages", book.Pages, DbType.Int16);
        parameters.Add("isbn", book.ISBN, DbType.String);
        parameters.Add("publishedAt", book.PublishedAt, DbType.DateTime);
        parameters.Add("authorId", book.AuthorId, DbType.Int32);

        var connection = _context.CreateConnection();

        var id = await connection.QuerySingleAsync<int>(query, parameters);

        var createdBook = new Book
        {
            Id = id,
            Title = book.Title,
            Publisher = book.Publisher,
            Pages = book.Pages,
            ISBN = book.ISBN,
            PublishedAt = book.PublishedAt,
            AuthorId = book.AuthorId
        };

        return createdBook;
    }

    public async Task UpdateBookAsync(int id, BookForUpdateDTO book)
    {
        var query = @"UPDATE 
                        [dbo].[Books] 
                    SET 
                        Title = @title, Publisher = @publisher, Pages = @pages, ISBN = @isbn, PublishedAt = @publishedAt, AuthorId = @authorId
                    WHERE 
                        Id = @Id";

        var parameters = new DynamicParameters();
        parameters.Add("Id", id, DbType.Int32);
        parameters.Add("title", book.Title, DbType.String);
        parameters.Add("publisher", book.Publisher, DbType.String);
        parameters.Add("pages", book.Pages, DbType.Int16);
        parameters.Add("isbn", book.ISBN, DbType.String);
        parameters.Add("publishedAt", book.PublishedAt, DbType.DateTime);
        parameters.Add("authorId", book.AuthorId, DbType.Int32);

        var connection = _context.CreateConnection();

        await connection.ExecuteAsync(query, parameters);
    }

    public async Task DeleteBookAsync(int id)
    {
        var query = @"DELETE FROM 
                        [dbo].[Books] 
                    WHERE 
                        Id = @Id";

        var connection = _context.CreateConnection();

        await connection.ExecuteAsync(query, new { id });
    }
}
