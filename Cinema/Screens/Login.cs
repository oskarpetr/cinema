using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cinema.Utils;
using Cinema.Cinema;

namespace Cinema.Screens {
    public class Login {
        public const int PADDING = 5;

        public Login() {
            // setting
            Design design = new Design();
            Console.CursorVisible = true;

            // header
            design.Header("Login");

            while(true) {
                // full name
                Console.Write(new String(' ', PADDING));
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Full name: ");
                Console.ResetColor();

                string name = Console.ReadLine();

                Console.WriteLine();

                // password
                Console.Write(new String(' ', PADDING));
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Password: ");
                Console.ResetColor();

                string password = Console.ReadLine();

                // accounts
                List<Guest> accounts = new Accounts().GetAccounts();

                Guest user = accounts.FirstOrDefault(account =>
                    account.FullName == name &&
                    account.Password == password);

                if (user == null) {
                    Console.WriteLine();

                    Console.Write(new String(' ', PADDING));
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid credentials");

                    Console.Write(new String(' ', PADDING));
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("Press y/n to enter again: ");
                    Console.ResetColor();
                    
                    string answer = Console.ReadLine();

                    if(answer == "n") {
                        new Home();
                    } else {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine(new String(' ', 50));
                        Console.SetCursorPosition(0, Console.CursorTop - 2);
                        Console.WriteLine(new String(' ', 50));
                        Console.SetCursorPosition(0, Console.CursorTop - 3);
                        Console.WriteLine(new String(' ', 50));
                        Console.SetCursorPosition(0, Console.CursorTop - 3);
                        Console.WriteLine(new String(' ', 50));
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                    }
                } else {
                    Console.WriteLine();

                    Console.Write(new String(' ', PADDING));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Logged as {user.FullName}");

                    // set logged
                    new Logged().SaveLogged(user);

                    // return home
                    Console.CursorVisible = false;
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(new String(' ', PADDING));
                    Console.WriteLine("Press enter to continue");
                    Console.ResetColor();

                    while (true) {
                        if (Console.ReadKey().Key == ConsoleKey.Enter) {
                            new Home();
                        }
                    }
                }
            }
        }
    }
}