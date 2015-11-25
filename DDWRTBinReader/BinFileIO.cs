using DDWRTBinReader.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DDWRTBinReader
{
    public class BinFileIO
    {
        const int EOF = -1;

        public string _path { get; set; }

        public BinFileIO(string pathname)
        {
            _path = pathname;
        }

        public void WriteContent(LinkedList<Parameter> paramList)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"outfile.txt"))
            {
                foreach (Parameter p in paramList)
                {
                    file.WriteLine("{0}: {1}", p.Name, p.Value);
                }
            }
        }

        public LinkedList<Parameter> ReadContent()
        {
            LinkedList<Parameter> linkedList = new LinkedList<Parameter>();
            using (BinaryReader breader = new BinaryReader(File.Open(_path, FileMode.Open)))
            {

                // Reads the header.
                UTF8Encoding enc = new UTF8Encoding();
                char[] header = breader.ReadChars(6);
                short sh = breader.ReadInt16();

                // Reads the file content.
                while (breader.PeekChar() != EOF)
                {

                    // name bytes.
                    int nameLenght = breader.ReadByte();
                    char[] name = breader.ReadChars(nameLenght);

                    // value bytes.
                    byte[] valueLenghtBytes = breader.ReadBytes(2);
                    ushort valueLenght = BitConverter.ToUInt16(valueLenghtBytes, 0);

                    char[] value = null;
                    if (valueLenght > 0)
                    {
                        value = breader.ReadChars(valueLenght);
                    }
                    Parameter p = new Parameter(new string(name), new string(value));
                    linkedList.AddLast(p);


                }

                return linkedList;
            }
        }

        public void PrintContent(LinkedList<Parameter> linkedList)
        {
            foreach (Parameter p in linkedList)
            {
                Console.WriteLine(p.Name + ": " + p.Value);
            }
            System.Console.Read();
        }
    }
}
