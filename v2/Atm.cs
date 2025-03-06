using System;
using System.Collections.Generic;

public static class ATMFunctions
{
    static List<string> transactionHistory = new List<string>(); //ginagamit para magkaroon ng listahan na rinerecord every transaction within the session

    public static void MainMenu()
    {
        decimal balance = 1000.00m; // fixed balance para sa user
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("ATM Main Menu");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. Show Transaction History");
            Console.WriteLine("5. Transfer Money");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");
            switch (Console.ReadLine())
            {
                case "1": // mas pinadali na if else statement
                    CheckBalance(balance);
                    break;
                case "2":
                    Withdraw(ref balance);
                    break;
                case "3":
                    Deposit(ref balance);
                    break;
                case "4":
                    ShowTransactionHistory();
                    break;
                case "5":
                    Transfer.TransferMenu(ref balance, transactionHistory);
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Press any key to try again...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    public static void CheckBalance(decimal balance) // chinecheck ang balance ni user
    {
        Console.WriteLine($"Your balance is: ${balance:F2}");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public static void Withdraw(ref decimal balance) // Winiwithdraw ang balance ni user
    {
        Console.WriteLine($"Your balance is: ${balance:F2}");
        Console.Write("Enter amount to withdraw: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
        {
            if (amount <= balance)
            {
                balance -= amount;
                transactionHistory.Add($"Withdraw: -${amount:F2}");
                Console.WriteLine("Withdrawal successful!");
                Console.WriteLine($"Remaining balance: ₱{balance:F2}");
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
            }
        }
        else
        {
            Console.WriteLine("Invalid amount.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public static void Deposit(ref decimal balance) // Dinedeposit para sa balance ni user
    {
        Console.WriteLine($"Your balance is: ${balance:F2}");
        Console.Write("Enter amount to deposit: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
        {
            balance += amount;
            transactionHistory.Add($"Deposit: +${amount:F2}");
            Console.WriteLine("Deposit successful!");
            Console.WriteLine($"New balance: ${balance:F2}");
        }
        else
        {
            Console.WriteLine("Invalid amount.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public static void ShowTransactionHistory() // Nagpapakita ng record ng every transaction (withdraw, deposit, transfer) dito papasok ang "static List<string> transactionHistory = new List<string>();" sa itaas
    {
        Console.WriteLine("Transaction History:");
        if (transactionHistory.Count == 0)
        {
            Console.WriteLine("No transactions yet.");
        }
        else
        {
            foreach (var transaction in transactionHistory)
            {
                Console.WriteLine(transaction);
            }
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}