using Core;

Console.WriteLine("System Info");
Console.WriteLine($"OS: {System.Environment.OSVersion}");
Console.WriteLine($"Memory: {System.GC.GetTotalMemory(false)} bytes");

var category = new Category(1, "Food", "Food expenses", true, new DateTime(2024, 1, 1));
Console.WriteLine($"Category: {category.Name}");

var transaction = new Transaction(1, "Supermarket", 850.50, new DateTime(2024, 6, 15), true, 1, "Weekly");
Console.WriteLine($"Transaction: {transaction.Title}, Amount: {transaction.Amount}");

var user = new UserProfile(1, "Ivan", "UAH", 15000.00, true, new DateTime(2024, 1, 10));
Console.WriteLine($"User: {user.FullName}, Budget: {user.MonthlyBudget}");