using System.Collections;

namespace Core;

public class BudgetController : IEnumerable<Transaction>
{
    public BudgetConfiguration Config { get; }

    private readonly List<Transaction> _transactions = new();

    public BudgetController(double monthlyLimit, string currency = "UAH")
    {
        Config = new BudgetConfiguration(monthlyLimit, currency, alertsEnabled: true);
    }

    public void Add(Transaction t) => _transactions.Add(t);

    public double GetBalance() =>
        _transactions.Sum(t => t.IsExpense ? -t.Amount : t.Amount);

    public bool IsOverLimit() =>
        _transactions.Where(t => t.IsExpense).Sum(t => t.Amount) > Config.MonthlyLimit;

    public IEnumerator<Transaction> GetEnumerator()
    {
        foreach (var t in _transactions)
            yield return t;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}