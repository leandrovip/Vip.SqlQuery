# Vip.SqlQuery

[![License](https://img.shields.io/github/license/leandrovip/Vip.SqlQuery)](https://raw.githubusercontent.com/leandrovip/Vip.SqlQuery/master/LICENSE)
[![NuGet](https://img.shields.io/nuget/v/Vip.SqlQuery)](https://www.nuget.org/packages/Vip.SqlQuery) 
[![NuGet Downloads](https://img.shields.io/nuget/dt/Vip.SqlQuery.svg)](https://www.nuget.org/packages/Vip.SqlQuery) 

<br />

This is a very simple library to generate ***SELECT***  queries in SQL SERVER. It is possible generate queries with many columns, prefix, many possibles where´s clause, parameters and more. :v: :wink:

## Requirements

```
.Net Standard 2.0
```

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

## License
MIT
