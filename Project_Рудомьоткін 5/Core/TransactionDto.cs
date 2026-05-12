namespace Core;

public class TransactionDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public double Amount { get; set; }
    public DateTime Date { get; set; }
    public bool IsExpense { get; set; }
    public int CategoryId { get; set; }
    public string Note { get; set; } = string.Empty;

    public TransactionDto() { }

    public TransactionDto(Transaction t)
    {
        Id = t.Id; Title = t.Title; Amount = t.Amount;
        Date = t.Date; IsExpense = t.IsExpense;
        CategoryId = t.CategoryId; Note = t.Note;
    }

    public Transaction ToTransaction() =>
        new(Id, Title, Amount, Date, IsExpense, CategoryId, Note);
}