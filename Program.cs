using System;


class Program
{

    static void Main(string[] args)
    {
        // Create an instance of the BudgetManager class to manage income and expenses.
        BudgetManager budgetManager = new BudgetManager();


        while (true)
        {
            // Display a menu with available options.
            Console.WriteLine("\nEnter a command (Add Income, Add Expense, View Balance, Quit):");
            string command = Console.ReadLine().ToLower();

            // Switch case to handle user input.
            switch (command)
            {
                case "add income":
                    // Get the income amount and description from the user.
                    Console.Write("Enter the income amount: ");
                    decimal incomeAmount = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Enter the income description (e.g., Salary, Freelance): ");
                    string incomeDescription = Console.ReadLine();

                    // Add the income using the AddIncome method.
                    budgetManager.AddIncome(incomeAmount, incomeDescription);
                    Console.WriteLine($"Income added: {incomeDescription} - Amount: {incomeAmount}");
                    break;

                case "add expense":
                    // Get the expense amount and description from the user.
                    Console.Write("Enter the expense amount: ");
                    decimal expenseAmount = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Enter the expense description (e.g., Rent, Groceries): ");
                    string expenseDescription = Console.ReadLine();

                    // Add the expense using the AddExpense method.
                    budgetManager.AddExpense(expenseAmount, expenseDescription);
                    Console.WriteLine($"Expense added: {expenseDescription} - Amount: {expenseAmount}");
                    break;

                case "view balance":
                    // Get the current balance by calling the GetBalance method.
                    decimal balance = budgetManager.GetBalance();

                    // Display the balance.
                    Console.WriteLine($"Your current balance is: {balance}");
                    break;

                case "quit":
                    // Exit the program when "quit" is entered.
                    Console.WriteLine("Exiting the program...");
                    return;  // Exit the application.

                default:
                    // Handle invalid commands.
                    Console.WriteLine("Invalid command. Please try again.");
                    break;
            }
        }
    }

}