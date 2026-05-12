namespace Core;

public static class Extensions
{
    public static string ToCurrencyString(this double amount, string currency = "UAH")
        => $"{amount:F2} {currency}";

    public static string ToTypeLabel(this bool isExpense)
        => isExpense ? "Expense" : "Income";

    public static int ExpenseCount(this IEnumerable<Transaction> transactions)
        => transactions.Count(t => t.IsExpense);
}