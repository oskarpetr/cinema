using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cinema.Utils;

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
            foreach (Ticket ticket in guest.Tickets) {
                Console.WriteLine(ticket.Film);
            }
        }
    }
}
