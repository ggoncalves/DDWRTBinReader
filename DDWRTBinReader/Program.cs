using DDWRTBinReader.Logic;
using System;
using System.Collections.Generic;
using System.IO;


// TODO:
// OK Create structure to represent values (can use Dictionary)
// OK Refactor read class from reader to I/O.
// OK Provide Writing funcionality
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
                binIO.WriteContent(linkedList, args[1]);
                Console.WriteLine("Done");
            }
        }

        public static bool validate(String[] args)
        {
            if (validateLine(args))
            {
                return File.Exists(args[0]);
            }
            Console.WriteLine("You must inform 2 arguments: ");
            Console.WriteLine(" - the absolute path to source dd-wrt bin file;");
            Console.WriteLine(" - the absolute path to destiny txt file.");
            return false;
        }

        public static bool validateLine(String[] args)
        {
            if (args == null || args.Length < 2)
            {
                return false;
            }
            return true;
        }
    }
}
