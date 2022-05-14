using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema {
    public class Ticket {
        public string Film { get; set; }
        public Hall Hall { get; set; }
        public string Row { get; set; }
        public int Seat { get; set; }
    }
}
