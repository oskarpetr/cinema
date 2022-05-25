using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Cinema {

    [Serializable]
    public class Guest {
        public string FullName { get; set; }
        public string Password { get; set; }
        public DateTime AccountCreated { get; set; } = DateTime.Now;
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
