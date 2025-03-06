using System;
using System.Collections.Generic;

public static class Login
{
    static Dictionary<string, UserInfo> users = UserInfo.DefaultUsers; // Nag aauthenticate sa mga users sa loginReg.cs
                                                                       // at nag reregister ng new user sa loginReg.cs

    public static string CurrentUserPassword { get; private set; }

    public static bool Authenticate() // chinecheck kung may existing user na sa users dictionary
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        if (users.ContainsKey(username) && users[username].Password == password)
        {
            CurrentUserPassword = password;
            Console.WriteLine("Login successful! Press any key to continue...");
            Console.ReadKey();
            return true;
        }
        else
        {
            Console.WriteLine("Invalid username or password. Press any key to try again...");
            Console.ReadKey();
            return false;
        }
    }

    public static void Register() // Nag reregister ng new user sa users dictionary
    {
        Console.Write("Enter new username: ");
        string username = Console.ReadLine();
        if (users.ContainsKey(username))
        {
            Console.WriteLine("Username already exists. Press any key to try again...");
            Console.ReadKey();
            return;
        }

        Console.Write("Enter account name: ");
        string accountName = Console.ReadLine();

        Console.Write("Enter new password: ");
        string password = Console.ReadLine();

        users.Add(username, new UserInfo(accountName, password, 1000.00m)); // automatic may 1k na balance
        Console.WriteLine("Registration successful! Press any key to continue...");
        Console.ReadKey();
    }
}