using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Utils {
    public class Design {
        public void Header(string header) {
            Console.Clear();

            Console.WriteLine();
            Center(Font(header));

            Console.WriteLine(new String('\n', 2));
        }

        public string Font(string text) {
            text = text.ToUpper();

            const string alphabet = "ᴀʙᴄᴅᴇғɢʜɪᴊᴋʟᴍɴᴏᴘqʀsᴛᴜᴠᴡxʏᴢ";
            string str = "";

            foreach (char letter in text) {
                if ((int)letter >= 65 && (int)letter <= 90) {
                    str += alphabet[(int)letter - 65];
                } else {
                    str += letter;
                }
            }

            return str;
        }

        public void Center(string text) {
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(text);

            Console.ResetColor();
        }
    }
}
