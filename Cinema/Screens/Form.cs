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
            Console.CursorVisible = true;

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
            GuestType guest = (GuestType)InlineMenu(typeof(GuestType), "Guest type");

            // separator
            Console.WriteLine();


            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(new String(' ', PADDING));
            Console.Write(new String('═', 60));
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine();

            // food
            Console.Write(new String(' ', PADDING));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Any popcorn? y/n: ");
            Console.ResetColor();

            string answer = Console.ReadLine();

            Refreshments refreshments = new Refreshments();

            if (answer == "y") {
                int counter = 1;

                while(true) {
                    Console.SetCursorPosition(PADDING, Console.CursorTop - 1);
                    int selected_popcorn = InlineMenu(typeof(PopcornType), $"Popcorn {counter}");

                    Console.WriteLine();

                    Console.Write(new String(' ', PADDING));
                    int selected_size = InlineMenu(typeof(Size), "Size");

                    refreshments.Food.Add(new Food {
                        Name = (PopcornType)selected_popcorn,
                        Size = (Size)selected_size
                    });

                    counter++;

                    Console.WriteLine();
                    Console.Write(new String(' ', PADDING));
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("Add another? y/n: ");
                    Console.ResetColor();

                    answer = Console.ReadLine();

                    Console.SetCursorPosition(PADDING, Console.CursorTop - 1);
                    Console.WriteLine(new String(' ', 50));
                    Console.SetCursorPosition(PADDING, Console.CursorTop - 3);
                    Console.WriteLine(new String(' ', 50));

                    if (answer == "y") {
                        Console.SetCursorPosition(PADDING, Console.CursorTop - 2);
                    } else {
                        Console.SetCursorPosition(PADDING, Console.CursorTop - 3);
                        Console.Write(new String(' ', 50));
                        Console.SetCursorPosition(PADDING, Console.CursorTop);

                        string title = "Popcorn: ";
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(title);
                        Console.ResetColor();

                        foreach (Food food in refreshments.Food) {
                            Console.SetCursorPosition(title.Length + PADDING, Console.CursorTop);
                            Console.WriteLine($"{food.Name} — {food.Size} size");
                        }

                        break;
                    }
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

            answer = Console.ReadLine();

            if (answer == "y") {
                int counter = 1;

                while (true) {
                    Console.SetCursorPosition(PADDING, Console.CursorTop - 1);
                    int selected_drink = InlineMenu(typeof(DrinkType), $"Drink {counter}");

                    Console.WriteLine();

                    Console.Write(new String(' ', PADDING));
                    int selected_size = InlineMenu(typeof(Size), "Size");

                    refreshments.Drinks.Add(new Drink {
                        Name = (DrinkType)selected_drink,
                        Size = (Size)selected_size
                    });

                    counter++;

                    Console.WriteLine();
                    Console.Write(new String(' ', PADDING));
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("Add another? y/n: ");
                    Console.ResetColor();

                    answer = Console.ReadLine();

                    Console.SetCursorPosition(PADDING, Console.CursorTop - 1);
                    Console.WriteLine(new String(' ', 50));
                    Console.SetCursorPosition(PADDING, Console.CursorTop - 3);
                    Console.WriteLine(new String(' ', 50));

                    if (answer == "y") {
                        Console.SetCursorPosition(PADDING, Console.CursorTop - 2);
                    } else {
                        Console.SetCursorPosition(PADDING, Console.CursorTop - 3);
                        Console.Write(new String(' ', 50));
                        Console.SetCursorPosition(PADDING, Console.CursorTop);

                        string title = "Drinks: ";
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(title);
                        Console.ResetColor();

                        foreach (Drink drink in refreshments.Drinks) {
                            Console.SetCursorPosition(title.Length + PADDING, Console.CursorTop);
                            Console.WriteLine($"{drink.Name.ToString().Replace("_", " ")} — {drink.Size} size");
                        }

                        break;
                    }
                }
            } else {
                Console.WriteLine();
            }
        }

        public int InlineMenu(Type type, string title) {
            string[] options = Enum.GetNames(type);
            
            int index = 0;
            bool run = true;

            title += ": ";

            Console.CursorVisible = false;
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

                    Console.Write($" {options[i].Replace("_", " ")} ");
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

            Console.CursorVisible = true;
            return -1;
        }
    }
}
