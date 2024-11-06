using System;


class Program
{

    static void Main(string[] args)
    {
        // Create an instance of the BudgetManager class to manage income and expenses.
        BudgetManager budgetManager = new BudgetManager();

        // Variable to track if the user is authenticated
        Console.WriteLine("Welcome to the Personal Budget Tracker!");
        bool isAuthenticated = false;

        // Loop until the user is authenticated
        while (!isAuthenticated)
        {
            // Display authentication options
            Console.WriteLine("Choose an option: Register or Login");

            // Read the user's choice
            string choice = Console.ReadLine()?.Trim().ToLower();

            if (choice == "register")
            {
                // Prompt for username and password for registration.
                Console.Write("Enter a username: ");
                string username = Console.ReadLine()?.Trim();
                Console.Write("Enter a password: ");
                string password = Console.ReadLine()?.Trim();

                // Register the user and log them in automatically if successful.
                if (budgetManager.RegisterUser(username, password))
                {
                    Console.WriteLine("User registered successfully!");
                    isAuthenticated = true;
                    Console.WriteLine("You are now logged in!");
                }
            }
            else if (choice == "login")
            {
                // Prompt for username and password for login.
                Console.Write("Enter your username: ");
                string username = Console.ReadLine()?.Trim();
                Console.Write("Enter your password: ");
                string password = Console.ReadLine()?.Trim();

                // Attempt to authenticate the user.
                if (budgetManager.AuthenticateUser(username, password))
                {
                    Console.WriteLine("Login successful!");
                    isAuthenticated = true;
                }
            }
            if (!isAuthenticated)
            {
                Console.WriteLine("Invalid option or credentials, please try again.");
            }
        }

        // Main menu for authenticated users.
        while (true)
        {
            Console.WriteLine("Enter a command (Add Income, Add Expense, View Balance, Quit):");
            string command = Console.ReadLine()?.Trim().ToLower();

            if (command == "add income")
            {
                // Code to add income entry
                Console.Write("Enter income amount: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Enter income description: ");
                string description = Console.ReadLine();

                budgetManager.AddIncome(amount, description);
                Console.WriteLine("Income added successfully.");
            }
            else if (command == "add expense")
            {
                // Code to add expense entry
                Console.Write("Enter expense amount: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Enter expense description: ");
                string description = Console.ReadLine();

                budgetManager.AddExpense(amount, description);
                Console.WriteLine("Expense added successfully.");
            }
            else if (command == "view balance")
            {
                // Display current balance by calling GetBalance
                decimal balance = budgetManager.GetBalance();
                Console.WriteLine($"Current balance: {balance}");
            }
            else if (command == "quit" || command == "exit") 
            {
                Console.WriteLine("Exiting the program...");
                break;
            }
            else
            {
                Console.WriteLine("Invalid command. Please try again.");
            }
        }
    }
}