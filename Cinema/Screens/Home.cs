using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cinema.Utils;

namespace Cinema.Screens {
    public class Home {
        public Home() {
            // setting
            Design design = new Design();

            // options
            List<string> options = new List<string>() {
                design.Font("buy ticket"),
                design.Font("database"),
                design.Font("settings")
            };

            // logo
            List<string> logo = new List<string>() {
                " ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ ",
                "░░░░░░██████╗░██╗███╗░░██╗███████╗███╗░░░███╗░█████╗░░░░░░",
                "░░░░░██╔═══██╗██║████╗░██║██╔════╝████╗░████║██╔══██╗░░░░░",
                "░░░░░██║░░░╚═╝██║██╔██╗██║█████╗░░██╔████╔██║███████║░░░░░",
                "░░░░░██║░░░██╗██║██║╚████║██╔══╝░░██║╚██╔╝██║██╔══██║░░░░░",
                "░░░░░╚██████╔╝██║██║░╚███║███████╗██║░╚═╝░██║██║░░██║░░░░░",
                "░░░░░░╚═════╝░╚═╝╚═╝░░╚══╝╚══════╝╚═╝░░░░░╚═╝╚═╝░░╚═╝░░░░░",
                " ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ "
            };

            Console.WriteLine(Environment.NewLine);

            // draw logo
            foreach (string line in logo) {
                Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
                Console.WriteLine(line);
            }

            Console.WriteLine(Environment.NewLine);

            // draw options
            design.Center(design.Font("options // permissions"));
            Console.WriteLine();

            int index = 0;
            bool run = true;

            while (run) {
                for (int i = 0; i < options.Count; i++) {
                    string prefix = " ";

                    if (i == index) {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        prefix = "˃";
                    }

                    string current = $" {prefix}{new String(' ', 50 - options[i].Length)}{options[i]} ";
                    Console.SetCursorPosition((Console.WindowWidth - current.Length) / 2, Console.CursorTop);
                    Console.Write(current);
                    Console.ResetColor();

                    if (i == 1) {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write($"  {design.Font("admin")}");
                    }

                    Console.WriteLine();
                    Console.ResetColor();
                }

                Console.SetCursorPosition(0, Console.CursorTop - 3);
                Console.WriteLine(new String('\n', 3));
                Console.SetCursorPosition(0, Console.CursorTop - 4);

                // arrow switch
                switch (Console.ReadKey().Key) {
                    case ConsoleKey.UpArrow:
                        if (index - 1 >= 0) index--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (index + 1 < options.Count) index++;
                        break;
                    case ConsoleKey.Enter:
                        switch (index) {
                            case 0:
                                new Buy();
                                return;
                            case 1:
                                new Database();
                                return;
                            case 2:
                                new Settings();
                                return;
                        }

                        break;
                }
            }
        }
    }
}
