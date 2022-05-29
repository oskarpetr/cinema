using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cinema.Cinema;
using Cinema.Utils;

namespace Cinema.Screens {
    public class Database {
        public const int PADDING = 5;

        public Database() {
            // setting
            Design design = new Design();
            Console.CursorVisible = true;

            // header
            design.Header("Database");

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

                if (name == "admin" && password == "admin") {
                    Console.WriteLine();

                    Console.Write(new String(' ', PADDING));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Logged as admin");

                    // continue
                    Console.CursorVisible = false;
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(new String(' ', PADDING));
                    Console.WriteLine("Press enter to continue");
                    Console.ResetColor();
                }
                else {
                    Console.WriteLine();

                    Console.Write(new String(' ', PADDING));
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Access denied");

                    // again
                    Console.Write(new String(' ', PADDING));
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("Press y/n to enter again: ");
                    Console.ResetColor();

                    string answer = Console.ReadLine();

                    if (answer == "n") {
                        new Home();
                        return;
                    }
                }

                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.WriteLine(new String(' ', 50));
                Console.SetCursorPosition(0, Console.CursorTop - 2);
                Console.WriteLine(new String(' ', 50));
                Console.SetCursorPosition(0, Console.CursorTop - 3);
                Console.WriteLine(new String(' ', 50));
                Console.SetCursorPosition(0, Console.CursorTop - 3);
                Console.WriteLine(new String(' ', 50));
                Console.SetCursorPosition(0, Console.CursorTop - 1);

                // database
                List<Guest> accounts = new Accounts().GetAccounts();
                List<Ticket> tickets = new List<Ticket>();

                foreach (Guest guest in accounts) {
                    foreach (Ticket ticket in guest.Tickets) {
                        tickets.Add(ticket);
                    }
                }

                Console.CursorVisible = false;

                int index = 0;

                while (true) {
                    for (int i = 0; i < tickets.Count; i++) {
                        int length = 25;
                        Guest guest = accounts[accounts.FindIndex(e => e.Tickets.Contains(tickets[i]))];

                        Console.SetCursorPosition(5, Console.CursorTop);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine($" {design.Font(guest.FullName)}");
                        Console.ResetColor();

                        if (i == index) {
                            Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        }

                        Console.SetCursorPosition(5, Console.CursorTop);
                        Console.WriteLine($" {tickets[i].Film}{new String(' ', length - tickets[i].Film.Length)} ");

                        CultureInfo cs = new CultureInfo("cs-CZ");
                        string price = tickets[i].GetPrice().ToString("c", cs);

                        Console.SetCursorPosition(5, Console.CursorTop);
                        Console.WriteLine($" {price}{new String(' ', length - price.Length)} ");

                        Console.WriteLine();
                        Console.ResetColor();
                    }

                    Console.SetCursorPosition(5, Console.CursorTop - (tickets.Count * 3) - (tickets.Count - 1) - 1);

                    switch (Console.ReadKey().Key) {
                        case ConsoleKey.UpArrow:
                            if (index - 1 >= 0) index--;
                            break;
                        case ConsoleKey.DownArrow:
                            if (index - 1 < accounts.Count) index++;
                            break;
                        case ConsoleKey.Escape:
                            new Home();
                            return;
                    }
                }
            }
        }
    }
}