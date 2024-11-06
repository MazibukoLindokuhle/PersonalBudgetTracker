using System;
using System.Collections.Generic;

namespace PersonalBudgetTracker
{
    // Income class to store income details
    public class Income
    {
        public decimal Amount { get; set; }  // The amount of the income
        public string Description { get; set; }  // The description of the income (e.g., "Salary", "Freelance")

        // Constructor to initialize the income object
        public Income(decimal amount, string description)
        {
            Amount = amount;
            Description = description;
        }
    }

    // BudgetManager class to handle adding income and calculating total
    public class BudgetManager
    {
        private List<Income> incomes = new List<Income>();  // List to store all incomes

        // Method to add income
        public void AddIncome(decimal amount, string description)
        {
            // Create a new income object and add it to the list
            Income income = new Income(amount, description);
            incomes.Add(income);
            Console.WriteLine($"Income added: {description} - Amount: {amount}");
        }

        // Method to calculate total income
        public decimal GetTotalIncome()
        {
            decimal total = 0;
            foreach (var income in incomes)  // Sum all income amounts
            {
                total += income.Amount;
            }
            return total;
        }
    }

    // Main Program
class Program
{
    static void Main(string[] args)
    {
        BudgetManager budgetManager = new BudgetManager();  // Create an instance of BudgetManager

        // Prompt user to enter income details
        Console.WriteLine("Enter the income amount: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());

        // Prompt user to enter income descripton details
        Console.WriteLine("Enter the income description (e.g., Salary, Freelance): ");
        string description = Console.ReadLine();

        // Add a null check for description to prevent potential null reference
        if (string.IsNullOrWhiteSpace(description))
        {
            description = "Unknown";  // Default description if user leaves it empty
        }

        // Add the income to the budget manager
        budgetManager.AddIncome(amount, description);

        // Display the total income so far
        Console.WriteLine($"Total Income: {budgetManager.GetTotalIncome()}");

        // Pause the console so the user can see the result
        Console.ReadLine();
    }
}

}