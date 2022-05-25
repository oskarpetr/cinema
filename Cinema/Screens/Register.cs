using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cinema.Utils;
using Cinema.Cinema;

namespace Cinema.Screens {
    public class Register {
        public const int PADDING = 5;

        public Register() {
            // setting
            Design design = new Design();
            Console.CursorVisible = true;

            // header
            design.Header("Register");

            while (true) {
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

                Guest user = new Guest() {
                    FullName = name,
                    Password = password
                };

                // set logged & add account
                new Logged().SaveLogged(user);
                new Accounts().AddAccount(user);

                // return home
                Console.WriteLine();

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
