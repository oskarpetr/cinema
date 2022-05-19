using System;
using System.Text;
using System.Collections.Generic;

using Cinema.Screens;

namespace Cinema {
    public class Program {
        static void Main(string[] args) {
            // setting
            Console.OutputEncoding = Encoding.UTF8;

            // home screen
            new Home();

            Console.ReadKey();
        }
    }
}