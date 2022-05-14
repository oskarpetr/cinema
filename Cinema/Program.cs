using System;
using System.Text;
using System.Collections.Generic;

namespace Cinema {
    public class Program {
        static void Main(string[] args) {
            // setting
            Console.OutputEncoding = Encoding.UTF8;

            // home screen
            Home();

            Console.ReadKey();
        }


        // screens
        static void Home() {
            List<string> options = new List<string>() {
                Font("buy ticket"),
                Font("database"),
                Font("settings")
            };

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

            Console.WriteLine("\n");

            // logo
            foreach (string line in logo) {
                Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
                Console.WriteLine(line);
            }

            Console.WriteLine("\n");

            // options
            Center(Font("options // permissions"));
            Console.WriteLine();

            int index = 0;
            bool run = true;

            while(run) {
                for (int i = 0; i < options.Count; i++) {
                    string prefix = " ";

                    if (i == index) {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        prefix = "→";
                    }

                    string current = $" {prefix}{new String(' ', 50 - options[i].Length)}{options[i]} ";
                    Console.SetCursorPosition((Console.WindowWidth - current.Length) / 2, Console.CursorTop);
                    Console.Write(current);
                    Console.ResetColor();

                    if (i == 1) {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write($"  {Font("/ admin")}");
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
                        if(index - 1 >= 0) index--;
                        break;
                    case ConsoleKey.DownArrow:
                        if(index + 1 < options.Count) index++;
                        break;
                    case ConsoleKey.Enter:
                        switch(index) {
                            case 0:
                                Buy();
                                return;
                            case 1:
                                Database();
                                return;
                            case 2:
                                Settings();
                                return;
                        }

                        break;
                }
            }
        }

        static void Buy() {
            Console.Clear();

            Console.WriteLine();
            Center("Buy Ticket");
            Console.WriteLine(new String('\n', 2));

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

            for (int x = 0; x < 2; x++) {
                for (int i = 0; i < 2; i++) {
                    for (var j = 0; j < 4; j++) {
                        Console.Write(new String(' ', 8));
                        Console.Write(new String('█', 20));
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();

                for (int i = 0; i < 4; i++) {
                    int film = x * 4 + i;

                    Console.Write(new String(' ', (i == 0) ? 8 : 20 - films[film - 1].Length + 8));
                    Console.Write(films[film]);
                }

                Console.WriteLine();

                for (int i = 0; i < 4; i++) {
                    int film = x * 4 + i;
                    string hall = $"Hall {(char)(film + 65)}";

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(new String(' ', (i == 0) ? 8 : 20 - hall.Length + 8));
                    Console.Write(Font(hall));
                    Console.ResetColor();
                }

                if(x != 1) {
                    Console.WriteLine("\n");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Center(new String('—', Console.WindowWidth - 16));
                    Console.ResetColor();
                    Console.WriteLine("\n");
                }
            }
        }

        static void Database() {
            Login();
        }

        static void Settings() {

        }

        static void Login() {
            Console.Clear();

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
                        Home();
                    }
                } else {
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


        // format
        static string Font(string text) {
            text = text.ToUpper();

            const string numbers = "₀₁₂₃₄₅₆₇₈₉";
            const string alphabet = "ᴀʙᴄᴅᴇғɢʜɪᴊᴋʟᴍɴᴏᴘqʀsᴛᴜᴠᴡxʏᴢ";
            string str = "";

            foreach (char letter in text) {
                if((int)letter >= 48 && (int)letter <= 57) {
                    str += numbers[(int)letter - 48];
                } else if((int)letter >= 65 && (int)letter <= 90) {
                    str += alphabet[(int)letter - 65];
                } else {
                    str += letter;
                }
            }

            return str;
        }

        static void Center(string text) {
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(text);

            Console.ResetColor();
        }
    }
}
