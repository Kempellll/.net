namespace Core;

public abstract class BaseTransaction
{
    public int Id { get; set; }
    public string Title { get; set; }
    public double Amount { get; set; }
    public DateTime Date { get; set; }
    public string Note { get; set; }

    protected BaseTransaction(int id, string title, double amount, DateTime date, string note)
    {
        Id = id; Title = title; Amount = amount; Date = date; Note = note;
    }

    public virtual string GetTypeLabel() => "Transaction";

    public abstract bool IsExpense { get; }
    public abstract string Describe();
}