namespace Core;

public class Transaction : BaseTransaction, ICalculable
{
    public override bool IsExpense { get; }
    public int CategoryId { get; set; }

    public Transaction(int id, string title, double amount, DateTime date,
                       bool isExpense, int categoryId, string note)
        : base(id, title, amount, date, note)
    {
        IsExpense = isExpense;
        CategoryId = categoryId;
    }

    public override string GetTypeLabel() => IsExpense ? "Expense" : "Income";

    public override string Describe() =>
        $"[{Id}] {Title} | {GetTypeLabel()} | {Amount:F2} | {Date:dd.MM.yyyy}";

    public double Calculate() => IsExpense ? -Amount : Amount;

    public string GetSummary() =>
        $"{Title}: {(IsExpense ? "-" : "+")}{Amount:F2}";
}