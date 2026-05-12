namespace Core;

public class BudgetConfiguration
{
    public double MonthlyLimit { get; set; }
    public string Currency { get; set; }
    public bool AlertsEnabled { get; set; }

    public BudgetConfiguration(double monthlyLimit, string currency, bool alertsEnabled)
    {
        MonthlyLimit = monthlyLimit;
        Currency = currency;
        AlertsEnabled = alertsEnabled;
    }
}