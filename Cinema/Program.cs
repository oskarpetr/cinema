using System;
using System.Text;
using System.Collections.Generic;

using Cinema.Screens;
using Cinema.Utils;

namespace Cinema {
    public class Program {
        static void Main(string[] args) {
            // setting
            Console.OutputEncoding = Encoding.UTF8;
            Console.WindowHeight = 25;
            Console.CursorVisible = false;

            //Accounts accounts = new Accounts();
            //accounts.AddAccount(new Guest() {
            //    FullName = "Oskar Petr",
            //    Password = "Haha"
            //});

            // home screen
            new Home();

            Console.ReadKey();
        }
    }
}