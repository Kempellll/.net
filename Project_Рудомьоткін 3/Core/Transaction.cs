namespace Core;

public class Transaction
{
    public int Id { get; set; }
    public string Title { get; set; }
    public double Amount { get; set; }
    public DateTime Date { get; set; }
    public bool IsExpense { get; set; }
    public int CategoryId { get; set; }
    public string Note { get; set; }

    public Transaction(int id, string title, double amount, DateTime date, bool isExpense, int categoryId, string note)
    {
        Id = id;
        Title = title;
        Amount = amount;
        Date = date;
        IsExpense = isExpense;
        CategoryId = categoryId;
        Note = note;
    }
}