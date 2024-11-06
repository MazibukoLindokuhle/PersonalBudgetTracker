using System;
using System.Collections.Generic;
using System.Linq;

// BudgetManager class is responsible for managing income and expenses.
public class BudgetManager
{
    // List to store all income entries.
    private List<Income> incomes = new List<Income>();

    // List to store all expense entries.
    private List<Expense> expenses = new List<Expense>();

    // Method to add a new income entry to the list.
    public void AddIncome(decimal amount, string description)
    {
        // Create a new Income object with the provided amount and description.
        Income income = new Income(amount, description);

        // Add the newly created income to the incomes list.
        incomes.Add(income);
    }

    // Method to get the total sum of all income amounts.
    public decimal GetTotalIncome()
    {
        // Use LINQ's Sum method to calculate the total of all income amounts.
        return incomes.Sum(income => income.Amount);
    }

    // Method to add a new expense entry to the list.
    public void AddExpense(decimal amount, string description)
    {
        // Create a new Expense object with the provided amount and description.
        Expense expense = new Expense(amount, description);

        // Add the newly created expense to the expenses list.
        expenses.Add(expense);
    }

    // Method to get the total sum of all expense amounts.
    public decimal GetTotalExpenses()
    {
        // Use LINQ's Sum method to calculate the total of all expense amounts.
        return expenses.Sum(expense => expense.Amount);
    }

    // Method to display all expenses with their descriptions and amounts.
    public void DisplayExpenses()
    {
        // Loop through each expense in the expenses list and print it to the console.
        foreach (var expense in expenses)
        {
            Console.WriteLine($"{expense.Description}: {expense.Amount}");
        }
    }
}
