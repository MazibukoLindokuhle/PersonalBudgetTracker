// Defines the Income class that represents an income source (e.g., salary, freelance).
public class Income
{
    // Property to store the amount of income.
    public decimal Amount { get; set; }

    // Property to store the description of the income (e.g., "Salary" or "Freelance Work").
    public string Description { get; set; }

    // Constructor that initializes the Income object with an amount and description.
    public Income(decimal amount, string description)
    {
        Amount = amount;  // Set the Amount property with the provided amount.
        Description = description;  // Set the Description property with the provided description.
    }
}
