// Defines the Expense class that represents an expense (e.g., groceries, rent).
public class Expense
{
    // Property to store the amount of the expense.
    public decimal Amount { get; set; }

    // Property to store the description of the expense (e.g., "Groceries", "Electricity Bill").
    public string Description { get; set; }

    // Constructor that initializes the Expense object with an amount and description.
    public Expense(decimal amount, string description)
    {
        Amount = amount;  // Set the Amount property with the provided amount.
        Description = description;  // Set the Description property with the provided description.
    }
}
