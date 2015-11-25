using DDWRTBinReader.Logic;
using System;
using System.Collections.Generic;
using System.IO;


// TODO:
// Create structure to represent values (can use Dictionary)
// Refactor read class from reader to I/O.
// Provide Writing funcionality
// Allow customization in writing sequence (alpha, NULL values first/last, same order)
// Document code using site original reference
// Document README.TXT
// Create github project
// Allow open 2 binary files and generate diff result (from -> to in the same order)
// Customize diff result options
//  - UNCHANGED values separated from modified values (first/last)
// Done
namespace DDWRTBinReader
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (validate(args))
            {
                BinFileIO binIO = new BinFileIO(args[0]);
                LinkedList<Parameter> linkedList = binIO.ReadContent();
                binIO.WriteContent(linkedList);
                Console.WriteLine("Finished");
                Console.Read();
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
