using System.Text.Json;

namespace Core;

public static class JsonStorage
{
    private static readonly JsonSerializerOptions Options = new()
    {
        WriteIndented = true
    };

    public static void Save(IEnumerable<Transaction> transactions, string path)
    {
        var dtos = transactions.Select(t => new TransactionDto(t)).ToList();
        using var stream = File.Create(path);
        JsonSerializer.Serialize(stream, dtos, Options);
        Console.WriteLine($"  [JSON] Saved {dtos.Count} records -> {path}");
    }

    public static List<Transaction> Load(string path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine($"  [JSON] File not found: {path}");
            return new List<Transaction>();
        }

        try
        {
            using var stream = File.OpenRead(path);
            var dtos = JsonSerializer.Deserialize<List<TransactionDto>>(stream, Options);
            var result = dtos?.Select(d => d.ToTransaction()).ToList() ?? new();
            Console.WriteLine($"  [JSON] Loaded {result.Count} records from {path}");
            return result;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"  [JSON] Error: {ex.Message}");
            return new List<Transaction>();
        }
    }
}