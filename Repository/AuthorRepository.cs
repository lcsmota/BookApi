using System.Data;
using BookApi.Context;
using BookApi.Contracts;
using BookApi.DTOs;
using BookApi.Models;
using Dapper;

namespace BookApi.Repository;

public class AuthorRepository : IAuthorRepository
{
    private readonly DapperContext _context;
    public AuthorRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<Author> GetAuthorByIdAsync(int id)
    {
        var query = @"SELECT 
                        Id, Name, Nationality, Occupation
                    FROM 
                        [dbo].[Authors]
                    WHERE 
                        Id = @Id";

        using var connection = _context.CreateConnection();

        var author = await connection.QuerySingleOrDefaultAsync<Author>(query, new { id });

        return author;
    }

    public async Task<IEnumerable<Author>> GetAuthorsAsync()
    {
        var query = @"SELECT 
                        Id, Name, Nationality, Occupation 
                    FROM 
                        [dbo].[Authors]";

        using var connection = _context.CreateConnection();

        var authors = await connection.QueryAsync<Author>(query);

        return authors;
    }

    public async Task<Author> CreateAuthorAsync(AuthorForCreationDTO author)
    {
        var query = @"INSERT INTO [dbo].[Authors](
                        Name, Nationality, Occupation)
                    VALUES(
                        @name, @nationality, @occupation);
                    
                    SELECT CAST(SCOPE_IDENTITY() AS int)";

        var parameters = new DynamicParameters();
        parameters.Add("name", author.Name, DbType.String);
        parameters.Add("nationality", author.Nationality, DbType.String);
        parameters.Add("occupation", author.Occupation, DbType.String);

        using var connection = _context.CreateConnection();

        var id = await connection.QuerySingleAsync<int>(query, parameters);

        var createdAuthor = new Author
        {
            Id = id,
            Name = author.Name,
            Nationality = author.Nationality,
            Occupation = author.Occupation
        };

        return createdAuthor;
    }
    public async Task UpdateAuthorAsync(int id, AuthorForUpdateDTO author)
    {
        var query = @"UPDATE 
                        [dbo].[Authors] 
                    SET 
                        Name = @name, Nationality = @nationality, Occupation = @occupation
                    WHERE 
                        Id = @Id";

        using var connection = _context.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("Id", id, DbType.Int32);
        parameters.Add("name", author.Name, DbType.String);
        parameters.Add("nationality", author.Nationality, DbType.String);
        parameters.Add("occupation", author.Occupation, DbType.String);

        await connection.ExecuteAsync(query, parameters);
    }

    public async Task DeleteAuthorAsync(int id)
    {
        var query = @"DELETE FROM 
                        [dbo].[Authors] 
                    WHERE 
                        Id = @Id";

        using var connection = _context.CreateConnection();

        await connection.ExecuteAsync(query, new { id });
    }

    public async Task<Author> GetAuthorBooksMultipleResultsAsync(int id)
    {
        var query = @"SELECT 
                        Id, Name, Nationality, Occupation 
                    FROM 
                        [dbo].[Authors] 
                    WHERE 
                        Id = @Id;
                    
                    SELECT 
                        Id, Title, Publisher, Pages, ISBN, PublishedAt, AuthorId 
                    FROM 
                        [dbo].[Books] 
                    WHERE 
                        AuthorId = @Id";

        using var connection = _context.CreateConnection();

        using var multi = await connection.QueryMultipleAsync(query, new { id });

        var author = await multi.ReadSingleOrDefaultAsync<Author>();
        if (author != null)
            author.Books = (await multi.ReadAsync<Book>()).ToList();

        return author;
    }

    public async Task<List<Author>> GetAuthorsBooksMultipleMappingAsync()
    {
        var query = @"SELECT
                        a.Id, Name, Nationality, Occupation,
                        b.Id, Title, Publisher, Pages, ISBN, PublishedAt, AuthorId 
                    FROM Authors a
                    JOIN Books b
                    ON a.Id = b.AuthorId";

        var connection = _context.CreateConnection();

        var authorDic = new Dictionary<int, Author>();

        var authors = await connection.QueryAsync<Author, Book, Author>(
            query,
            (author, book) =>
            {
                if (!authorDic.TryGetValue(author.Id, out var currentAuthor))
                {
                    currentAuthor = author;
                    authorDic.Add(currentAuthor.Id, currentAuthor);
                }

                currentAuthor.Books.Add(book);

                return currentAuthor;
            });

        return authors.Distinct().ToList();
    }
}
