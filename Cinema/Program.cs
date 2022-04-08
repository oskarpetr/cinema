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

            int index = 0;
            bool run = true;

            while(run) {
                Console.WriteLine("\n");

                // logo
                foreach (string line in logo) {
                    Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
                    Console.WriteLine(line);
                }

                Console.WriteLine("\n");

                // options
                Header("<< options >>");
                Console.WriteLine();

                for (int i = 0; i < options.Count; i++) {
                    string prefix = " ";

                    if (i == index) {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        prefix = "→";
                    }

                    string current = $" {prefix}{new String(' ', 50 - options[i].Length)}{options[i]} ";
                    Console.SetCursorPosition((Console.WindowWidth - current.Length) / 2, Console.CursorTop);
                    Console.Write(current);
                    Console.ResetColor();

                    if (index == 1 && i == 1) {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write($"  {Font("admin")}");
                    }

                    Console.WriteLine();
                    Console.ResetColor();
                }

                Console.WriteLine(new String('\n', 6));

                //// credits
                //Header("credits");
                //Console.WriteLine();

                //string credits = Font(" By Oskar Petr - T1, 2022 ");
                //Console.SetCursorPosition((Console.WindowWidth - credits.Length) / 2, Console.CursorTop);

                //Console.ForegroundColor = ConsoleColor.Blue;
                //Console.WriteLine(credits);
                //Console.ResetColor();

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

                                break;
                            case 1:
                                Database();

                                break;
                            case 2:
                                Settings();

                                break;
                        }

                        break;
                }

                Console.Clear();
            }
        }

        static void Buy() {

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
                        return;
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

            const string font = " !\"#$%&'()*+,-./₀₁₂₃₄₅₆₇₈₉:;<=>?@ᴀʙᴄᴅᴇғɢʜɪᴊᴋʟᴍɴᴏᴘqʀsᴛᴜᴠᴡxʏᴢ[\\]^-";
            string str = "";

            foreach (char letter in text) {
                str += font[(int)letter - 32];
            }

            return str;
        }

        static void Header(string text) {
            string header = Font(text);
            Console.SetCursorPosition((Console.WindowWidth - header.Length) / 2, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(header);
            Console.ResetColor();
        }
    }
}
