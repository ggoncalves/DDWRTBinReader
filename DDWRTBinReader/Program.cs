using System;
using System.IO;

namespace DDWRTBinReader
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (validate(args))
            {
                BinReader reader = new BinReader(args[0]);
                reader.PrintBytes();
            }
        }

        public static bool validate(String[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("You must inform the complete path to the dd-wrt bin file.");
                return false;
            }
            return File.Exists(args[0]);
        }
    }
}
