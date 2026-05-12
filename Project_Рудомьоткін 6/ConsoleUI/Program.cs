using Core;

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

string jsonPath = "transactions.json";
string xmlPath = "expenses.xml";
string logPath = "session.log";

// 1. IDisposable + using
Console.WriteLine("1. LogResourceManager (IDisposable)");
using (var log = new LogResourceManager(logPath))
{
    log.Log("Program started");
    log.Log($"Transactions in memory: {transactions.Count}");
}
Console.WriteLine();

// 2. JSON збереження
Console.WriteLine("2. JSON Save");
JsonStorage.Save(transactions, jsonPath);
Console.WriteLine();

// 3. JSON завантаження
Console.WriteLine("3. JSON Load");
var loaded = JsonStorage.Load(jsonPath);
foreach (var t in loaded)
    Console.WriteLine($"  {t.Id} | {t.Title} | {t.Amount:F2}");
Console.WriteLine();

// 4. Пошкоджений JSON
Console.WriteLine("4. Broken JSON");
File.WriteAllText("broken.json", "{ broken json }}}");
JsonStorage.Load("broken.json");
Console.WriteLine();

// 5. XML збереження
Console.WriteLine("5. XML Save");
XmlStorage.SaveExpenses(transactions, xmlPath);
Console.WriteLine();

// 6. XML завантаження
Console.WriteLine("6. XML Load");
var xmlLoaded = XmlStorage.LoadExpenses(xmlPath);
foreach (var t in xmlLoaded)
    Console.WriteLine($"  {t.Id} | {t.Title} | {t.Amount:F2} | {t.Date:dd.MM.yyyy}");
Console.WriteLine();

// 7. Неіснуючий файл
Console.WriteLine("7. File not found");
JsonStorage.Load("ghost.json");
XmlStorage.LoadExpenses("ghost.xml");