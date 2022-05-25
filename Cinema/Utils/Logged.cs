using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cinema.Cinema;

namespace Cinema.Utils {
    public class Logged {
        // setting
        Files files = new Files();

        public const string PATH = "logged.db";

        public Guest GetLogged() {
            return (Guest)files.GetFile(PATH);
        }

        public void SaveLogged(Guest guest) {
            if (guest == null) {
                File.Delete(PATH);
                return;
            }

            files.SaveFile(PATH, guest);
        }
    }
}
