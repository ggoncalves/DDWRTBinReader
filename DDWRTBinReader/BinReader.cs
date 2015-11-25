using System;
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
                char[] header = breader.ReadChars(6);
                System.Console.WriteLine(header);

                short sh = breader.ReadInt16();
                System.Console.WriteLine(sh);

                while (breader.PeekChar() != -1)
                {

                    int lenght = breader.ReadByte();
                    //System.Console.WriteLine("length: {0}", lenght);

                    char[] name = breader.ReadChars(lenght);
                    //System.Console.WriteLine(name);

                    byte[] lenghtValueByte = breader.ReadBytes(2);
                    ushort lenghtValue = BitConverter.ToUInt16(lenghtValueByte, 0);
                    //System.Console.WriteLine("lenghtValue: {0}", lenghtValue);

                    if (lenghtValue > 0)
                    {
                        char[] value = breader.ReadChars(lenghtValue);
                        System.Console.WriteLine(new string(name) + " : " + new string(value));
                        //System.Console.Read();

                    }


                }
                System.Console.Read();
            }
        }
    }
}
