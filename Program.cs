using HotChocolate.Data;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services
        .AddGraphQLServer()
        .AddQueryType<Query>()
        .AddFiltering();

}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.MapGraphQL();

    app.UseHttpsRedirection();
    app.Run();
}

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public Author Author { get; set; }
}

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
}


public class Query
{
    [UseFiltering]
    public List<Book> GetBooks() =>
        [
            new()
            {
                Id = 1,
                Title = "C# Book",
                Author = new Author
                {
                    Id = 1,
                    Name = "Some random lad",
                }
            },
            new()
            {
                Id = 2,
                Title = "HotChocolate GraphQL Book",
                Author = new Author
                {
                    Id = 3,
                    Name = "Other random lad",
                }
            },
            new()
            {
                Id = 3,
                Title = "C# and Design Patterns Book",
                Author = new Author
                {
                    Id = 1,
                    Name = "Some random lad",
                }
            }
        ];

    public Book GetBook(int id) =>
        GetBooks().SingleOrDefault(book => book.Id == id)!;
}