# Basic HotChocolate application

This repo is just a basic usage of HotChocolate package to run a GraphQL server for dotnet.

As for this moment, there isn't a method to add a book nor an author.

## Types
```csharp
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public Author Author { get; set; }
}

public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
}
```

#### Querying books with filters:
```GraphQL
query {
    books(where: { title: { contains: "C#" }, author: { id: {eq: 1} }}) {
        id,
        title
        author {
            id
            name
        }
    }
}
```

#### Result
```json
{
  "data": {
    "books": [
      {
        "id": 1,
        "title": "C# Book",
        "author": {
          "id": 1,
          "name": "Some random lad"
        }
      },
      {
        "id": 3,
        "title": "C# and Design Patterns Book",
        "author": {
          "id": 1,
          "name": "Some random lad"
        }
      }
    ]
  }
}
```

#### Querying all books
```GraphQL
query {
  books {
    id,
    title,
    author {
      name
    }
  }
}
```

#### Result
```json
{
  "data": {
    "books": [
      {
        "id": 1,
        "title": "C# Book",
        "author": {
          "name": "Some random lad"
        }
      },
      {
        "id": 2,
        "title": "HotChocolate GraphQL Book",
        "author": {
          "name": "Other random lad"
        }
      },
      {
        "id": 3,
        "title": "C# and Design Patterns Book",
        "author": {
          "name": "Some random lad"
        }
      }
    ]
  }
}
```