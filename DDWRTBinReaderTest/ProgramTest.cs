using Microsoft.VisualStudio.TestTools.UnitTesting;
using DDWRTBinReader;
using System.Collections.Generic;

namespace DDWRTBinReaderTest
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void TestValidateLine_NullLine()
        {
            Assert.IsFalse(Program.validateLine(null));
        }

        [TestMethod]
        public void TestValidateLine_IncompleteLine()
        {
            string[] args = { "Filename" };
            Assert.IsFalse(Program.validateLine(args));
        }

        [TestMethod]
        public void TestValidateLine_EmptyLine()
        {
            string[] args = { "" };
            Assert.IsFalse(Program.validateLine(args));
        }

        [TestMethod]
        public void TestValidateLine_BlankLine()
        {
            string[] args = { "   " };
            Assert.IsFalse(Program.validateLine(args));
        }

        [TestMethod]
        public void TestValidateLine_Valid()
        {
            string[] args = { "pathtobin.bin", "pathtotxt.txt" };
            Assert.IsTrue(Program.validateLine(args));
        }
    }
}
