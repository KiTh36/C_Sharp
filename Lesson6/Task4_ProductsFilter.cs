using System;
using System.Collections.Generic;
using System.Linq;

public record Product(int Id, string Name, string Category, decimal Price, bool IsActive);

var products = new List<Product>
{
    new(1, "The Sultana disaster", "Books", 40m, true),
    new(2, "C# for psychopaths", "Books", 55m, true),
    new(3, "90s TV set", "Electronics", 900m, true),
    new(4, "How to not build trains", "Books", 15m, false),
    new(5, "Butter that flies", "Books", 30m, true),
};

decimal minPrice = 20m;
decimal maxPrice = 50m;

Func<Product, bool> filter = p =>
    p.IsActive &&
    p.Category == "Books" &&
    p.Price >= minPrice &&
    p.Price <= maxPrice;

var result = products
    .Where(filter)
    .OrderBy(p => p.Price)
    .ThenBy(p => p.Name)
    .Select(p => new
    {
        p.Id,
        p.Name,
        p.Price
    })
    .ToList();

foreach (var item in result)
{
    Console.WriteLine($"{item.Id}: {item.Name} - {item.Price}");
}
