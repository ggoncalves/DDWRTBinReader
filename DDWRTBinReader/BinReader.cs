using System.IO;
using System.Text;

namespace DDWRTBinReader
{
    public class BinReader
    {
        private static byte[] _bytes { get; set; }
        public string _path { get; set; }

        public BinReader(string pathname)
        {
            _bytes = File.ReadAllBytes(pathname);
            _path = pathname;
        }

        public void PrintBytes()
        {
            using (BinaryReader breader = new BinaryReader(File.Open(_path, FileMode.Open)))
            {
                // Reads the header.
                UTF8Encoding enc = new UTF8Encoding();
                byte[] header = breader.ReadBytes(6);
                string b2 = enc.GetString(header, 0, 6);
                System.Console.WriteLine(b2);
                colocar no git e continuar.
                short sh = breader.ReadInt16();
                System.Console.WriteLine( sh  );

                int lenght = breader.ReadByte();
                System.Console.WriteLine(lenght);

                char[] name = breader.ReadChars(9);
                System.Console.WriteLine( name  );

                int lenghtValue = breader.ReadInt16();
                System.Console.WriteLine(lenghtValue);

                //char[] name = breader.ReadChars(9);
                //System.Console.WriteLine(name);

                //// Read header.
                //System.Console.WriteLine(enc.GetCharCount(_bytes, 7, 2));

                System.Console.Read();
            }
        }
    }
}
