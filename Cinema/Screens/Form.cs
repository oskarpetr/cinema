using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cinema.Utils;

namespace Cinema.Screens {
    public class Form {
        public const int PADDING = 5;

        public Form(int film) {
            // setting
            Design design = new Design();

            // header
            design.Header("Guest form");

            // full name
            Console.Write(new String(' ', PADDING));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Full name: ");
            Console.ResetColor();

            string name = Console.ReadLine();

            Console.WriteLine();

            // guest type
            Console.Write(new String(' ', PADDING));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Guest type: ");
            Console.ResetColor();

            GuestType guest = (GuestType)InlineMenu(typeof(GuestType), "Guest type");

            // separator
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(new String(' ', PADDING));
            Console.Write(new String('—', 60));
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine();

            // food
            Console.Write(new String(' ', PADDING));
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Write("Any popcorn? y/n: ");
            Console.ResetColor();

            string answer = Console.ReadLine();

            if (answer == "y") {
                int counter = 1;

                while(true) {
                    Console.SetCursorPosition(PADDING, Console.CursorTop - 1);
                    int popcorn = InlineMenu(typeof(PopcornType), $"Popcorn {counter}");

                    Console.WriteLine();

                    Console.Write(new String(' ', PADDING));
                    int size = InlineMenu(typeof(Size), "Size");

                    Console.Write("Add Another? y/n: ");
                    answer = Console.ReadLine();

                    if (answer != "y") break;

                    counter++;
                }
            } else {
                Console.WriteLine();
            }

            Console.WriteLine();

            // drink
            Console.Write(new String(' ', PADDING));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Any drink? y/n: ");
            Console.ResetColor();

            if (Console.ReadLine() == "y") {

            } else {
                Console.SetCursorPosition(0, Console.CursorTop - 2);
                Console.WriteLine();
            }
        }

        public int InlineMenu(Type type, string title) {
            string[] options = Enum.GetNames(type);
            
            int index = 0;
            bool run = true;

            title += ": ";

            Console.SetCursorPosition(PADDING, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(title);
            Console.ResetColor();

            while (run) {
                for (int i = 0; i < options.Length; i++) {
                    if (i != 0) {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(" / ");
                        Console.ResetColor();
                    }

                    if (i == index) {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                    }

                    Console.Write($" {options[i]} ");
                    Console.ResetColor();
                }

                switch (Console.ReadKey().Key) {
                    case ConsoleKey.LeftArrow:
                        if (index - 1 >= 0) index--;
                        Console.SetCursorPosition(title.Length + PADDING, Console.CursorTop);

                        break;
                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(title.Length + PADDING, Console.CursorTop);
                        if (index + 1 < options.Length) index++;

                        break;
                    case ConsoleKey.Enter:
                        Console.SetCursorPosition(0, Console.CursorTop + 1);
                        return index;
                    default:
                        Console.SetCursorPosition(title.Length + PADDING, Console.CursorTop);

                        break;
                }
            }

            return -1;
        }
    }
}
