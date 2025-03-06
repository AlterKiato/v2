using System;

public static class Program
{
    public static void Main() //Pinaka Main na babasahin ng program
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
                        Console.WriteLine("Invalid option. Press any key to try again..."); //Hinihintay si user na mag press ng key bago mag proceed.
                        Console.ReadKey(); //Para mabasa nya yung message at maging malinis ang console
                        break;
                }
            }

            ATMFunctions.MainMenu(); // after mag log in, didirekta sa atm.cs kung saan ang main()
        }
    }
}
