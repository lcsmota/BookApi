using BookApi.Context;
using BookApi.Contracts;
using BookApi.Repository;

var builder = WebApplication.CreateBuilder(args);
{

    builder.Services.AddSingleton<DapperContext>();
    builder.Services.AddScoped<IBookRepository, BookRepository>();
    builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}