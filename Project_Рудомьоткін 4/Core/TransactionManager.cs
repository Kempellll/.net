using System.Collections;

namespace Core;

public class TransactionManager : IEnumerable<Transaction>
{
    private readonly List<Transaction> _transactions = new();
    private readonly Dictionary<int, Transaction> _index = new();

    public void Add(Transaction t)
    {
        _transactions.Add(t);
        _index[t.Id] = t;
    }

    public IEnumerator<Transaction> GetEnumerator()
    {
        foreach (var t in _transactions)
            yield return t;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public Transaction? FindById(int id)
        => _index.TryGetValue(id, out var t) ? t : null;

    public IEnumerable<Transaction> FindExpensesOver(double amount)
        => _index.Values.Where(t => t.IsExpense && t.Amount > amount);
}