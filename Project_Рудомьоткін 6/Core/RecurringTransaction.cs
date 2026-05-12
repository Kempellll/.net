namespace Core;

public class RecurringTransaction : BaseTransaction, ICalculable
{
    public override bool IsExpense { get; }
    public int RepeatMonths { get; set; }

    public RecurringTransaction(int id, string title, double amount, DateTime date,
                                bool isExpense, int repeatMonths, string note)
        : base(id, title, amount, date, note)
    {
        IsExpense = isExpense;
        RepeatMonths = repeatMonths;
    }

    public override string GetTypeLabel() => IsExpense ? "Recurring Expense" : "Recurring Income";

    public override string Describe() =>
        $"[{Id}] {Title} | {GetTypeLabel()} | {Amount:F2} x {RepeatMonths} months";

    public double Calculate() => (IsExpense ? -Amount : Amount) * RepeatMonths;

    public string GetSummary() =>
        $"{Title} (x{RepeatMonths}): {(IsExpense ? "-" : "+")}{Amount * RepeatMonths:F2}";
}