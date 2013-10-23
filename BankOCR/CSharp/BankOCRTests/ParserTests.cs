using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankOCRLib;

namespace BankOCRTests {
    [TestClass]
    public class ParserTests {
        [TestMethod]
        public void Parse_AccountLengthInput() {
            var input = String.Join("\n",
                " _     _  _     _  _  _  _  _ ",
                "| |  | _| _||_||_ |_   ||_||_|",
                "|_|  ||_  _|  | _||_|  ||_| _|",
                "                              ");

            var result = new OcrNumberParser().Parse(input);
            Assert.AreEqual("0123456789", result);
        }
    }
}
