using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Screens {
    public class Database {
        public Database() {
            new Login();

            // get active tickets & halls
        }

        public const string FILE = "halls.db";

        public List<Hall> Download() {
            return null;
        }
    }
}
