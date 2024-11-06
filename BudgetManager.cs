using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

// BudgetManager class is responsible for managing income and expenses.
public class BudgetManager
{
    private const string UserDataFile = "user_data.txt";
    private Dictionary<string, string> users = new Dictionary<string, string>();

    public BudgetManager()
    {
        LoadUsers();
    }
    
    // Dictionary to store user credentials with username as the key and password as the value.
    private Dictionary<string, string> userCredentials = new Dictionary<string, string>();

    // Fields to store the authenticated user's income and expenses
    private List<Income> incomes = new List<Income>();
    private List<Expense> expenses = new List<Expense>();

    // RegisterUser method to add new users with a username and password.
    public bool RegisterUser(string username, string password)
    {
        // Check if the username already exists in the credentials dictionary.
        if (userCredentials.ContainsKey(username))
        {
            Console.WriteLine("Username already exists. Please try a different username.");
            return false;
        }

        string hashedPassword = HashPassword(password);
        users[username] = hashedPassword;

        SaveUserToFile(username, hashedPassword);
        return true;
    }

    // AuthenticateUser method to check if provided username and password match any registered user.
    public bool AuthenticateUser(string username, string password)
    {
        if (users.TryGetValue(username, out string storedHashedPassword))
        {
            string hashedPassword = HashPassword(password);
            return storedHashedPassword == hashedPassword;
        }

        Console.WriteLine("Invalid username or password.");
        return false;
    }

    // Save a single user's data to file
    private void SaveUserToFile(string username, string hashedPassword)
    {
        using (StreamWriter sw = File.AppendText(UserDataFile))
        {
            sw.WriteLine($"{username}:{hashedPassword}");
        }
    }

    // Load all user data from file
    private void LoadUsers()
    {
        if (!File.Exists(UserDataFile))
        {
            return;
        }

        foreach (var line in File.ReadAllLines(UserDataFile))
        {
            var parts = line.Split(':');
            if (parts.Length == 2)
            {
                string username = parts[0];
                string hashedPassword = parts[1];
                users[username] = hashedPassword;
            }
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

    // // Method to calculate and return the balance (Income - Expenses).
    // public decimal GetBalance()
    // {
    //     // Get the total income and total expenses.
    //     decimal totalIncome = GetTotalIncome();
    //     decimal totalExpenses = GetTotalExpenses();

    //     // Calculate the balance by subtracting expenses from income.
    //     decimal balance = totalIncome - totalExpenses;

    //     // Return the balance.
    //     return balance;
    // }

    public decimal GetBalance()
    {
        return GetTotalIncome() - GetTotalExpenses();
    }
}
