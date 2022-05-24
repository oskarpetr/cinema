using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Utils {
    public class Accounts {
        // setting
        Files files = new Files();

        public const string PATH = "accounts.db";

        public List<Guest> GetAccounts() {
            List<Guest> data = (List<Guest>)files.GetFile(PATH);

            if (data == null) {
                return new List<Guest>();
            }

            return data;
        }

        public void AddAccount(Guest guest) {
            List<Guest> data = GetAccounts();
            data.Add(guest);

            files.SaveFile(PATH, data);
        }

        public void UpdateAccount(Guest guest) {
            List<Guest> accounts = GetAccounts();

            int index = accounts.FindIndex(account =>
                account.FullName == guest.FullName &&
                account.Password == guest.Password);

            accounts[index] = guest;
            new Logged().SaveLogged(guest);

            files.SaveFile(PATH, accounts);
        }
    }
}