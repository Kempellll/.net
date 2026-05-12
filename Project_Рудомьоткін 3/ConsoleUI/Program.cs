using Core;

// 1. Методи розширення
Console.WriteLine("Extensions");
double salary = 25000.0;
Console.WriteLine($"  ToCurrencyString: {salary.ToCurrencyString()}");
Console.WriteLine($"  ToTypeLabel (true): {true.ToTypeLabel()}");
Console.WriteLine($"  ToTypeLabel (false): {false.ToTypeLabel()}");

// 2. Наповнення менеджера
TransactionManager manager = new();
var data = new List<Transaction>
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
foreach (var t in data) manager.Add(t);

// 3. foreach через IEnumerable
Console.WriteLine("\nforeach TransactionManager");
foreach (var t in manager)
    Console.WriteLine($"  {t.Id} | {t.Title} | {t.IsExpense.ToTypeLabel()} | {t.Amount.ToCurrencyString()}");
Console.WriteLine($"  Expense count: {manager.ExpenseCount()}");

// 4. Dictionary пошук
Console.WriteLine("\nDictionary FindById");
var found = manager.FindById(5);
Console.WriteLine(found != null ? $"  Found: {found.Title} - {found.Amount.ToCurrencyString()}" : "  Not found");
var notFound = manager.FindById(99);
Console.WriteLine(notFound != null ? $"  Found: {notFound.Title}" : "  Id 99: not found (null)");

// 5. LINQ по Dictionary
Console.WriteLine("\nLINQ on Dictionary: expenses > 500");
foreach (var t in manager.FindExpensesOver(500))
    Console.WriteLine($"  {t.Title} - {t.Amount.ToCurrencyString()}");

// 6. HashSet
Console.WriteLine("\nHashSet");
HashSet<string> categoriesJune = new() { "Food", "Salary", "Cafe", "Utilities", "Pharmacy" };
HashSet<string> categoriesJuly = new() { "Food", "Salary", "Transport", "Cafe", "Sport" };

bool added = categoriesJune.Add("Food");
Console.WriteLine($"  Add duplicate 'Food': {(added ? "added" : "not added")}");
Console.WriteLine($"  Count: {categoriesJune.Count}");

HashSet<string> intersection = new(categoriesJune);
intersection.IntersectWith(categoriesJuly);
Console.WriteLine($"  Intersection: {string.Join(", ", intersection)}");

HashSet<string> union = new(categoriesJune);
union.UnionWith(categoriesJuly);
Console.WriteLine($"  Union: {string.Join(", ", union)}");