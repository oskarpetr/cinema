using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cinema.Utils;
using Cinema.Cinema;
using System.Globalization;

namespace Cinema.Screens {
    public class MyTickets {
        public const int PADDING = 5;

        public MyTickets() {
            // setting
            Design design = new Design();
            Console.CursorVisible = false;

            // header
            design.Header("My tickets");

            // tickets
            Guest guest = new Logged().GetLogged();

            int index = 0;

            while(true) {
                for (var i = 0; i < guest.Tickets.Count + 1; i++) {
                    Console.Write(new String(' ', PADDING));

                    if (i == index) {
                        if(i == 0) {
                            Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        } else {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                        }
                    }

                    if(i == 0) {
                        Console.WriteLine(" + add ticket ");
                    } else {
                        int length = 25;

                        string film = guest.Tickets[i - 1].Film;
                        Console.WriteLine($" {film}{new String(' ', length - film.Length - 2)} ");
                        Console.SetCursorPosition(5, Console.CursorTop);

                        CultureInfo cs = new CultureInfo("cs-CZ");
                        string price = guest.Tickets[i - 1].GetPrice().ToString("c", cs);
                        Console.WriteLine($" {price}{new String(' ', length - price.Length - 2)} ");
                    }

                    Console.WriteLine();
                    Console.ResetColor();
                }

                Console.SetCursorPosition(0,
                    Console.CursorTop - (guest.Tickets.Count + 1) - 1 - 2 * guest.Tickets.Count);

                switch(Console.ReadKey().Key) {
                    case ConsoleKey.UpArrow:
                        if (index - 1 >= 0) index--;
                        break;
                    case ConsoleKey.DownArrow:
                        if(index < guest.Tickets.Count) index++;
                        break;
                    case ConsoleKey.Enter:
                        if (index == 0) {
                            new Buy();
                            return;
                        }

                        break;
                    case ConsoleKey.Escape:
                        new Home();
                        return;
                }
            }
        }
    }
}
