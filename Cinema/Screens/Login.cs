using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cinema.Utils;

namespace Cinema.Screens {
    public class Login {
        public Login() {
            // setting
            Design design = new Design();

            // header
            design.Header("Login");

            do {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Enter your username");
                Console.ResetColor();

                string username = Console.ReadLine();

                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Enter your password");
                Console.ResetColor();

                string password = Console.ReadLine();
                Console.WriteLine();

                if (username != "admin" || password != "admin") {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong username or password");

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Enter again? y/n");
                    Console.ResetColor();

                    string again = Console.ReadLine();

                    Console.ResetColor();
                    Console.Clear();

                    if (again == "n") {
                        new Home();
                    }
                }
                else {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Logged as admin");

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Press enter to continue");

                    if (Console.ReadKey().Key == ConsoleKey.Enter) {
                        Console.ResetColor();
                        Console.Clear();
                        return;
                    }
                }
            } while (true);
        }
    }
}
