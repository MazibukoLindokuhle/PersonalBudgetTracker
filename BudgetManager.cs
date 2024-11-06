using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

// BudgetManager class is responsible for managing income and expenses.
public class BudgetManager
{
    // List to store registered users
    private List<User> users = new List<User>();

    // Fields to store the authenticated user's income and expenses
    private List<Income> incomes = new List<Income>();
    private List<Expense> expenses = new List<Expense>();

    // Method to register a new user with username and password
    public bool RegisterUser(string username, string password)
    {
        // Check if username is already taken
        if (users.Any(user => user.Username == username))
        {
            Console.WriteLine("Username already exists. Try a different username.");
            return false; // Registration failed
        }

        // Hash the password before storing
        string passwordHash = HashPassword(password);

        // Create a new User object and add it to the list of users
        users.Add(new User(username, passwordHash));

        Console.WriteLine("User registered successfully!");
        return true; // Registration successful
    }

    // Method to authenticate a user with their username and password
    public bool AuthenticateUser(string username, string password)
    {
        // Find the user by username
        var user = users.FirstOrDefault(user => user.Username == username);
        
        // Check if user exists and if the hashed password matches
        if (user != null && user.PasswordHash == HashPassword(password))
        {
            Console.WriteLine("Authentication successful!");
            return true; // Authentication successful
        }
        else
        {
            Console.WriteLine("Invalid username or password.");
            return false; // Authentication failed
        }
    }

    // Helper method to hash a password for secure storage
    private string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            // Convert the password into a byte array
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Convert the byte array to a hexadecimal string
            StringBuilder result = new StringBuilder();
            foreach (byte b in bytes)
            {
                result.Append(b.ToString("x2"));
            }

            return result.ToString();
        }
    }

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

    // Method to calculate and return the balance (Income - Expenses).
    public decimal GetBalance()
    {
        // Get the total income and total expenses.
        decimal totalIncome = GetTotalIncome();
        decimal totalExpenses = GetTotalExpenses();

        // Calculate the balance by subtracting expenses from income.
        decimal balance = totalIncome - totalExpenses;

        // Return the balance.
        return balance;
    }
}
