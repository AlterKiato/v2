using System;
using System.Collections.Generic;

public class UserInfo //Dictionary na pwede lagyan ng multiple users through register. Also inistore ang credentials ng user for login
{
    public string AccountName { get; set; }
    public string Password { get; set; }
    public decimal Balance { get; set; }

    public UserInfo(string accountName, string password, decimal balance)
    {
        AccountName = accountName;
        Password = password;
        Balance = balance;
    }

    public static Dictionary<string, UserInfo> DefaultUsers { get; } = new Dictionary<string, UserInfo>
    {
        { "admin", new UserInfo("AdminUser", "123456", 1000.00m) } // Default user na pwede agad i log in
    };
}

//Connected toh sa mainLoginReg.cs at AuthReg.cs
