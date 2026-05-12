using System.Xml.Linq;

namespace Core;

public static class XmlStorage
{
    public static void SaveExpenses(IEnumerable<Transaction> transactions, string path)
    {
        var doc = new XDocument(
            new XDeclaration("1.0", "utf-8", null),
            new XElement("Transactions",
                transactions
                    .Where(t => t.IsExpense)
                    .OrderBy(t => t.Date)
                    .Select(t => new XElement("Transaction",
                        new XAttribute("id", t.Id),
                        new XElement("Title", t.Title),
                        new XElement("Amount", t.Amount),
                        new XElement("Date", t.Date.ToString("yyyy-MM-dd")),
                        new XElement("CategoryId", t.CategoryId),
                        new XElement("Note", t.Note)
                    ))
            )
        );
        doc.Save(path);
        Console.WriteLine($"  [XML] Saved -> {path}");
    }

    public static List<Transaction> LoadExpenses(string path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine($"  [XML] File not found: {path}");
            return new();
        }

        try
        {
            var doc = XDocument.Load(path);
            var result = doc.Root!
                .Elements("Transaction")
                .Select(e => new Transaction(
                    id: (int)e.Attribute("id")!,
                    title: (string)e.Element("Title")!,
                    amount: (double)e.Element("Amount")!,
                    date: DateTime.Parse((string)e.Element("Date")!),
                    isExpense: true,
                    categoryId: (int)e.Element("CategoryId")!,
                    note: (string)e.Element("Note")!
                ))
                .ToList();
            Console.WriteLine($"  [XML] Loaded {result.Count} records from {path}");
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  [XML] Error: {ex.Message}");
            return new();
        }
    }
}