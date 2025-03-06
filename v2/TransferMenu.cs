using System;
using System.Collections.Generic;

public static class Transfer
{
    public static void TransferMenu(ref decimal balance, List<string> transactionHistory) // para sa pagtransfer ng pera to other user
    {
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Transfer Menu");
            Console.WriteLine("1. Transfer Money");
            Console.WriteLine("2. Register Account");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");
            switch (Console.ReadLine())
            {
                case "1":
                    TransferMoney(ref balance, transactionHistory);
                    break;
                case "2":
                    RegisterAccount();
                    break;
                case "3":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Press any key to try again...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    public static void TransferMoney(ref decimal balance, List<string> transactionHistory) // magtransfer ng pera sa target account na registered
    {
        Console.WriteLine("Registered Accounts:"); // iappakita listahan ng registered target account/s
        foreach (var account in Accounts.AllAccounts)
        {
            Console.WriteLine($"Account Number: {account.Key}, Account Name: {account.Value.AccountName}");
        }

        Console.Write("Enter account number to transfer to: "); // pipili ng target account
        string accountNumber = Console.ReadLine();
        if (!Accounts.AllAccounts.ContainsKey(accountNumber))
        {
            Console.WriteLine("Account number not found. Press any key to continue...");
            Console.ReadKey();
            return;
        }

        Account targetAccount = Accounts.AllAccounts[accountNumber];


        Console.Write("Enter amount to transfer: "); // lalagay ng amount na itatatransfer o isesend
        if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
        {
            if (amount <= balance)
            {
                balance -= amount;
                targetAccount.Balance += amount;
                transactionHistory.Add($"Transfer: -${amount:F2} to {accountNumber} ({targetAccount.AccountName})");
                Console.WriteLine("Transfer successful!");
                Console.WriteLine($"New balance: ${balance:F2}");
                Console.WriteLine($"Transferred ${amount:F2} to account {accountNumber} ({targetAccount.AccountName})");
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

    public static void RegisterAccount() // mag reregister ng target account, every registered account may initial na 1k para sa session
    {
        Console.Write("Enter new account number: ");
        string accountNumber = Console.ReadLine();
        if (Accounts.AllAccounts.ContainsKey(accountNumber))
        {
            Console.WriteLine("Account number already exists. Press any key to try again...");
            Console.ReadKey();
            return;
        }

        Console.Write("Enter account name: ");
        string accountName = Console.ReadLine();

        string password = Login.CurrentUserPassword;

        Accounts.AllAccounts.Add(accountNumber, new Account(accountName, 1000.00m)); // Initial balance set to 1000.00
        Console.WriteLine("Account registration successful! Press any key to continue...");
        Console.ReadKey();
    }
}