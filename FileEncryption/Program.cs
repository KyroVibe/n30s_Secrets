using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileEncryption {
    class Program {

        public static bool de = true;

        static void Main(string[] args) {

            Console.Write("\n encrypt or decrypt > ");
            string g = Console.ReadLine();
            if (g.ToLower() == "encrypt") {
                de = false;
            }

            Console.Clear();

            Console.Write("\n Path > ");
            string path = Console.ReadLine();
            Console.Write("\n Encryption Key > ");
            string key = Console.ReadLine();
            byte[] file = File.ReadAllBytes(path);

            List<byte> encryptedFile = new List<byte>();

            /*byte a = Convert.ToByte('a');
            byte b = 255;
            b += a;
            Console.Write("\n Encrypted Byte: " + b);
            b -= a;
            Console.Write("\n Decryption Test: " + b);*/

            int keyCount = 0;

            for (int i = 0; i < file.Length; i++) {

                byte a = Convert.ToByte(file[i]);
                byte b = Convert.ToByte(key[keyCount]);

                if (!de) {
                    a += b;
                } else {
                    a -= b;
                }

                encryptedFile.Add(a);

                keyCount++;
                if (keyCount <= key.Length) {
                    keyCount = 0;
                }
            }

            byte[] newFile = encryptedFile.ToArray();

            string newPath = "";

            /*if (!de) {
                newPath = path.Substring(0, path.LastIndexOf(".") + 1) + "ecy";
            } else {
                newPath = path.Substring(0, path.LastIndexOf(".") + 1) + "dcy";
            }*/

            newPath = path;

            File.WriteAllBytes(newPath, newFile);

            Console.Clear();
            if (!de) {
                Console.Write("\n --------------\n File Encrypted\n --------------");
            } else {
                Console.Write("\n --------------\n File Decrypted\n --------------");
            }
            Console.ReadKey();
        }
    }
}
