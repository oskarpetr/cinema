using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cinema.Utils;
using Cinema.Cinema;

namespace Cinema.Screens {
    public class Home {
        public Home() {
            // setting
            Design design = new Design();
            Files files = new Files();

            Guest guest = new Logged().GetLogged();
            bool logged = guest != null;

            // options
            List<string> options = new List<string>();
            
            if(logged) {
                options.Add(design.Font("my tickets"));
                options.Add(design.Font("database"));
                options.Add(design.Font("settings"));
                options.Add(design.Font("log out"));
            } else {
                options.Add(design.Font("register"));
                options.Add(design.Font("login"));
                options.Add(design.Font("database"));
                options.Add(design.Font("settings"));
            }

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

            Console.Clear();
            Console.WriteLine(new String('\n', 2));

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

                    if(logged && i == 1 || !logged && i == 2) {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write($"  {design.Font("admin")}");
                    }

                    Console.WriteLine();
                    Console.ResetColor();
                }

                Console.SetCursorPosition(0, Console.CursorTop - 4);
                Console.WriteLine(new String('\n', 4));
                Console.SetCursorPosition(0, Console.CursorTop - 5);                

                // arrow switch
                switch (Console.ReadKey().Key) {
                    case ConsoleKey.UpArrow:
                        if (index - 1 >= 0) index--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (index + 1 < options.Count) index++;
                        break;
                    case ConsoleKey.Enter:
                        if(logged) {
                            switch (index) {
                                case 0:
                                    new MyTickets();
                                    return;
                                case 1:
                                    new Database();
                                    return;
                                case 2:
                                    new Settings();
                                    return;
                                case 3:
                                    new Logged().SaveLogged(null);
                                    new Home();
                                    return;
                            }
                        } else {
                            switch (index) {
                                case 0:
                                    new Register();
                                    return;
                                case 1:
                                    new Login();
                                    return;
                                case 2:
                                    new Database();
                                    return;
                                case 3:
                                    new Settings();
                                    return;
                            }
                        }

                        break;
                }
            }
        }
    }
}