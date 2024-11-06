using System;

// Main program where the application runs.
class Program
{
    // Entry point of the program, execution starts here.
    static void Main(string[] args)
    {
        // Create an instance of the BudgetManager class to manage income and expenses.
        BudgetManager budgetManager = new BudgetManager();

        // Loop to keep the program running until the user types "exit" or "quit".
        while (true)
        {
            // Ask the user for a command (either to add income/expense or to quit).
            Console.WriteLine("\nEnter a command (Add Income, Add Expense, Quit): ");
            string command = Console.ReadLine().ToLower();  // Read user input and convert it to lowercase.

            // If the user types "quit" or "exit", break out of the loop and exit the program.
            if (command == "quit" || command == "exit")
            {
                Console.WriteLine("Exiting the program...");
                break;  // Exit the loop and the program.
            }

            // If the user wants to add income.
            if (command == "add income")
            {
                // Ask the user to input the income amount.
                Console.WriteLine("Enter the income amount: ");
                decimal incomeAmount = Convert.ToDecimal(Console.ReadLine());  // Read input and convert to decimal.

                // Ask the user to input a description for the income.
                Console.WriteLine("Enter the income description (e.g., Salary, Freelance): ");
                string incomeDescription = Console.ReadLine();  // Read input for the description.

                // Check if the income description is null or empty and prompt again if needed.
                if (string.IsNullOrEmpty(incomeDescription))
                {
                    incomeDescription = "No description provided";  // Provide a default description.
                }

                // Add the income to the BudgetManager using the AddIncome method.
                budgetManager.AddIncome(incomeAmount, incomeDescription);
                Console.WriteLine($"Income added: {incomeDescription} - Amount: {incomeAmount}");
                Console.WriteLine($"Total Income: {budgetManager.GetTotalIncome()}");
            }

            // If the user wants to add an expense.
            else if (command == "add expense")
            {
                // Ask the user to input the expense amount.
                Console.WriteLine("Enter the expense amount: ");
                decimal expenseAmount = Convert.ToDecimal(Console.ReadLine());  // Read input and convert to decimal.

                // Ask the user to input a description for the expense.
                Console.WriteLine("Enter the expense description (e.g., Groceries, Electricity Bill): ");
                string expenseDescription = Console.ReadLine();  // Read input for the description.

                // Check if the expense description is null or empty and prompt again if needed.
                if (string.IsNullOrEmpty(expenseDescription))
                {
                    expenseDescription = "No description provided";  // Provide a default description.
                }

                // Add the expense to the BudgetManager using the AddExpense method.
                budgetManager.AddExpense(expenseAmount, expenseDescription);
                Console.WriteLine($"Expense added: {expenseDescription} - Amount: {expenseAmount}");
                Console.WriteLine($"Total Expenses: {budgetManager.GetTotalExpenses()}");

                // Display all the expenses with their descriptions and amounts.
                budgetManager.DisplayExpenses();
            }

            // If the user enters an unknown command, inform them.
            else
            {
                Console.WriteLine("Unknown command. Please enter 'Add Income', 'Add Expense', or 'Quit'.");
            }
        }

        // The program should terminate
        Console.WriteLine("Program has terminated.");
    }
}
