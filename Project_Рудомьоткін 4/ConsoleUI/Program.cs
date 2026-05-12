using Core;

// 1. BudgetController (Композиція + Агрегація)
Console.WriteLine("BudgetController");
BudgetController budget = new BudgetController(monthlyLimit: 10000, currency: "UAH");
Console.WriteLine($"  Limit: {budget.Config.MonthlyLimit} {budget.Config.Currency}");

var transactions = new List<Transaction>
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
foreach (var t in transactions) budget.Add(t);

// 2. foreach через IEnumerable
Console.WriteLine("\nTransactions (Describe)");
foreach (var t in budget)
    Console.WriteLine("  " + t.Describe());

// 3. Поліморфізм через ICalculable[]
Console.WriteLine("\nPolymorphism: ICalculable[]");
ICalculable[] items =
{
    new Transaction(11, "Subscription", 499, DateTime.Today, true,  3, ""),
    new Transaction(12, "Bonus",       2000, DateTime.Today, false, 2, ""),
    new RecurringTransaction(13, "Rent",      4500, DateTime.Today, true,  12, ""),
    new RecurringTransaction(14, "Dividends",  800, DateTime.Today, false,  6, ""),
};
foreach (var item in items)
    Console.WriteLine($"  {item.GetSummary()} = {item.Calculate():F2}");

// 4. Поліморфізм через BaseTransaction[]
Console.WriteLine("\nPolymorphism: BaseTransaction[]");
BaseTransaction[] allTx =
{
    new Transaction(1, "Food", 300, DateTime.Today, true, 1, ""),
    new RecurringTransaction(2, "Subscription", 150, DateTime.Today, true, 12, ""),
    new Transaction(3, "Salary", 20000, DateTime.Today, false, 2, ""),
};
foreach (var tx in allTx)
    Console.WriteLine($"  {tx.GetTypeLabel()} | {tx.Describe()}");

// 5. Баланс
Console.WriteLine("\nBalance");
Console.WriteLine($"  Balance: {budget.GetBalance():F2}");
Console.WriteLine($"  Over limit: {(budget.IsOverLimit() ? "YES" : "NO")}");