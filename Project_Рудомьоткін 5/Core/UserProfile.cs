namespace Core;

public class UserProfile
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Currency { get; set; }
    public double MonthlyBudget { get; set; }
    public bool NotificationsEnabled { get; set; }
    public DateTime RegisteredAt { get; set; }

    public UserProfile(int id, string fullName, string currency, double monthlyBudget, bool notificationsEnabled, DateTime registeredAt)
    {
        Id = id;
        FullName = fullName;
        Currency = currency;
        MonthlyBudget = monthlyBudget;
        NotificationsEnabled = notificationsEnabled;
        RegisteredAt = registeredAt;
    }
}