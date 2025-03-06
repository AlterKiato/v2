using System;

public static class Program
{
    public static void Main() 
    {
        while (true)
        {
            bool authenticated = false;
            while (!authenticated)
            {
                Console.Clear();
                Console.WriteLine("ATM System");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        authenticated = Login.Authenticate();
                        break;
                    case "2":
                        Login.Register();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Press any key to try again..."); 
                        Console.ReadKey(); 
                        break;
                }
            }

            ATMFunctions.MainMenu(); 
        }
    }
}
