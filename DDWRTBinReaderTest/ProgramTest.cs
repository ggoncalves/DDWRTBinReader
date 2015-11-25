using Microsoft.VisualStudio.TestTools.UnitTesting;
using DDWRTBinReader;
using System.Collections.Generic;

namespace DDWRTBinReaderTest
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void TestValidate_InvalidFile()
        {
            Assert.IsFalse(Program.validate(null));
        }

        [TestMethod]
        public void TestValidate_InvalidFilename()
        {
            string[] args = { "Filename" };
            Assert.IsFalse(Program.validate(args));
        }

    }
}
