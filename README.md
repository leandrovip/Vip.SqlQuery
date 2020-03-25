# Vip.SqlQuery

This is a very simple library to generate ***SELECT***  queries in SQL SERVER. It is possible generate queries with many columns, prefix, many possibles where´s clause, parameters and more. :v: :wink:

_Package write in C#, framework .Net 4.8_

## How to use ?

Declare a using:

```csharp
using Vip.SqlQuery;
```

Code:

```csharp
var query = SqlQuery.New()
    .Select(new[] {"ProductId" "Product", "Description", "Price", "p"})
    .From("Product p")
    .OrderBy("p.ProdutoId")
    .Build();
```

Query return:

```csharp
Console.Write(query.Command)

/*
SELECT [p].[ProductId], [p].[Product], [p].[Description], [p].[Price]
FROM [Product] [p]
ORDER BY [p].[ProdutoId]
*/
```

# License
MIT
