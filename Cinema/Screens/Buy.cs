using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cinema.Utils;

namespace Cinema.Screens {
    public class Buy {
        public Buy() {
            // setting
            Design design = new Design();

            // header
            design.Header("Select a film");

            List<string> films = new List<string>() {
                "Sonic the Hedgehog",
                "Stranger Things",
                "Doctor Strange",
                "The Batman",
                "The Northman",
                "Spider Man",
                "Morbius",
                "Heartstopper",
                "The Bad Guys",
                "Happening"
            };

            for (int section = 0; section < 2; section++) {
                // draw rectangles
                for (int i = 0; i < 2; i++) {
                    for (var j = 0; j < 4; j++) {
                        Console.Write(new String(' ', 8));

                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.Write(new String(' ', 20));
                        Console.ResetColor();
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();

                // film
                for (int i = 0; i < 4; i++) {
                    int film = section * 4 + i;

                    Console.Write(new String(' ', (i == 0) ? 8 : 20 - films[film - 1].Length + 8));
                    Console.Write(films[film]);
                }

                Console.WriteLine();

                // hall
                for (int i = 0; i < 4; i++) {
                    int film = section * 4 + i;
                    string hall = $"Hall {(char)(film + 65)}";

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(new String(' ', (i == 0) ? 8 : 20 - hall.Length + 8));
                    Console.Write(design.Font(hall));
                    Console.ResetColor();
                }

                // spaces
                if (section != 1) {
                    Console.WriteLine(Environment.NewLine);
                }
            }

            int index = 0;

            while (true) {
                for (int i = 0; i < films.Count; i++) {
                    if (index == i) {
                        FilmSelection(i, ConsoleColor.DarkMagenta);
                    }
                }

                switch (Console.ReadKey().Key) {
                    case ConsoleKey.LeftArrow:
                        FilmSelection(index, ConsoleColor.Gray);

                        if (index < 4) {
                            if (index - 1 >= 0) index--;
                        }
                        else if (index >= 4 && index <= 8) {
                            if (index - 2 >= 4) index--;
                        }

                        break;
                    case ConsoleKey.RightArrow:
                        FilmSelection(index, ConsoleColor.Gray);

                        if (index < 4) {
                            if (index + 1 < films.Count / 2 - 1) index++;
                        }
                        else if (index >= 4 && index <= 8) {
                            if (index + 1 < films.Count - 1) index++;
                        }

                        break;
                    case ConsoleKey.DownArrow:
                        FilmSelection(index, ConsoleColor.Gray);

                        if (index < 4) index += 5;

                        break;
                    case ConsoleKey.UpArrow:
                        FilmSelection(index, ConsoleColor.Gray);

                        if (index >= 4 && index <= 8) index -= 5;

                        break;
                    case ConsoleKey.Enter:
                        new Form(index);
                        return;
                }
            }
        }

        public void FilmSelection(int i, ConsoleColor color) {
            for (var j = 0; j < 2; j++) {
                Console.SetCursorPosition(
                    (8 + 20) * ((i >= 5) ? i - 5 : i),
                    (i >= 5) ? 11 + j : 5 + j);

                Console.Write(new String(' ', 8));

                Console.BackgroundColor = color;
                Console.Write(new String(' ', 20));
                Console.WriteLine();
                Console.ResetColor();
            }
        }
    }
}
