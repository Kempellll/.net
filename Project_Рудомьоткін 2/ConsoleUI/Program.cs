using System.Collections;
using System.Diagnostics;
using Core;

// 1. STRUCT
Console.WriteLine("Struct");
static void ModifyAmount(MoneyAmount m) { m.Value = 9999; Console.WriteLine($"  Inside: {m.Value}"); }
MoneyAmount price = new MoneyAmount { Value = 500, Currency = "UAH" };
Console.WriteLine($"  Before: {price.Value}");
ModifyAmount(price);
Console.WriteLine($"  After: {price.Value}");

// 2. BOXING
Console.WriteLine("\nArrayList vs List<int>");
object boxed = 42;
int unboxed = (int)boxed;
Console.WriteLine($"  Boxed: {boxed}, Unboxed: {unboxed}");
Stopwatch sw = Stopwatch.StartNew();
ArrayList al = new ArrayList();
for (int i = 0; i < 1_000_000; i++) al.Add(i);
sw.Stop(); long alMs = sw.ElapsedMilliseconds;
sw.Restart();
List<int> gl = new List<int>();
for (int i = 0; i < 1_000_000; i++) gl.Add(i);
sw.Stop();
Console.WriteLine($"  ArrayList: {alMs}ms | List<int>: {sw.ElapsedMilliseconds}ms");

// 3. Колекція
List<Transaction> t = new()
{
    new(1,  "Supermarket", 850.50,  new DateTime(2024,6,1),  true,  1, ""),
    new(2,  "Salary",      25000,   new DateTime(2024,6,5),  false, 2, ""),
    new(3,  "Cafe",        320,     new DateTime(2024,6,7),  true,  3, ""),
    new(4,  "Utilities",   1450,    new DateTime(2024,6,10), true,  4, ""),
    new(5,  "Freelance",   5000,    new DateTime(2024,6,12), false, 2, ""),
    new(6,  "Pharmacy",    215.75,  new DateTime(2024,6,14), true,  5, ""),
    new(7,  "Cinema",      380,     new DateTime(2024,6,15), true,  3, ""),
    new(8,  "Internet",    250,     new DateTime(2024,6,16), true,  4, ""),
    new(9,  "Sold items",  1200,    new DateTime(2024,6,18), false, 2, ""),
    new(10, "Market",      640,     new DateTime(2024,6,20), true,  1, ""),
};

// 4. WHERE
Console.WriteLine("\nWHERE: expenses > 500");
foreach (var x in t.Where(x => x.IsExpense && x.Amount > 500))
    Console.WriteLine($"  {x.Title} - {x.Amount:F2}");

// 5. ORDER BY
Console.WriteLine("\nOrderBy");
foreach (var x in t.OrderBy(x => x.IsExpense).ThenByDescending(x => x.Amount))
    Console.WriteLine($"  {x.Title} - {x.Amount:F2}");

// 6. SELECT
Console.WriteLine("\nSELECT");
foreach (var x in t.Select(x => x.Title))
    Console.WriteLine($"  - {x}");

// 7. FIRST OR DEFAULT
Console.WriteLine("\nFirstOrDefault");
var found = t.FirstOrDefault(x => !x.IsExpense && x.Amount > 4000);
Console.WriteLine(found != null ? $"  Found: {found.Title}" : "  Not found");
var notFound = t.FirstOrDefault(x => x.Amount > 100_000);
Console.WriteLine(notFound == null ? "  >100000: null" : notFound.Title);