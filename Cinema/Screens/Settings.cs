using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cinema.Utils;
using Cinema.Cinema;

namespace Cinema.Screens {
    public class Settings {
        public const int PADDING = 5;

        public Settings() {
            // setting
            Design design = new Design();

            // header
            design.Header("Settings");

            // user account
            Guest guest = new Logged().GetLogged();

            if (guest != null) {
                Console.Write(new String(' ', PADDING));
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(design.Font("user account"));
                Console.ResetColor();

                // full name
                Console.WriteLine();

                Console.Write(new String(' ', PADDING));

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Full name: ");
                Console.ResetColor();

                Console.Write(guest.FullName);

                // date created
                Console.WriteLine();

                Console.Write(new String(' ', PADDING));

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Date created: ");
                Console.ResetColor();

                Console.Write($"{guest.AccountCreated.ToString("dd/MM/yyyy")}" +
                              $" at {guest.AccountCreated.ToString("HH:mm")}");

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }

            // credits
            Console.Write(new String(' ', PADDING));
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(design.Font("credits"));
            Console.ResetColor();

            Console.WriteLine();

            Console.Write(new String(' ', PADDING));
            Console.WriteLine("Cinema app was made by Oskar Petr, class of T1 in 2022");
            Console.Write(new String(' ', PADDING));
            Console.WriteLine("in collaboration with Kyberna s.r.o.");

            // return home
            while (true) {
                if (Console.ReadKey().Key == ConsoleKey.Escape) {
                    new Home();
                }
            }
        }
    }
}