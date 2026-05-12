namespace Core;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsExpense { get; set; }
    public DateTime CreatedAt { get; set; }

    public Category(int id, string name, string description, bool isExpense, DateTime createdAt)
    {
        Id = id;
        Name = name;
        Description = description;
        IsExpense = isExpense;
        CreatedAt = createdAt;
    }
}