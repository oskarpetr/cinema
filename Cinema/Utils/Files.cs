using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Utils {
    public class Files {
        public object GetFile(string path) {
            using (Stream stream = File.Open(path, FileMode.OpenOrCreate)) {
                BinaryFormatter formatter = new BinaryFormatter();

                if (stream.Length == 0) {
                    return null;
                }

                return (object)formatter.Deserialize(stream);
            }
        }

        public void SaveFile(string path, object data) {
            using (Stream stream = File.Open(path, FileMode.OpenOrCreate)) {
                BinaryFormatter format = new BinaryFormatter();

                format.Serialize(stream, data);
            }
        }

        public List<string> GetTextFile(string path) {
            List<string> list = new List<string>();

            string[] data = File.ReadAllLines(path);

            foreach (string line in data) {
                list.Add(line);
            }

            return list;
        }
    }
}