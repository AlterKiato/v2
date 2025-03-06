using System;
using System.Collections.Generic;

public class Account 
    public string AccountName { get; set; }
    public decimal Balance { get; set; }

    public Account(string accountName, decimal balance)
    {
        AccountName = accountName;
        Balance = balance;
    }
}

public static class Accounts
{
    public static Dictionary<string, Account> AllAccounts { get; } = new Dictionary<string, Account>();
}
