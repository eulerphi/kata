using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankOCRLib;

namespace BankOCRTests {
    [TestClass]
    public class OcrNumberParserTests {
        [TestMethod]
        public void Parse_NonAccountLengthInput() {
            var input = String.Join("\n",
                " _  _ ",
                "|_||_|",
                " _||_|",
                "      ");

            var result = new OcrNumberParser().Parse(input);
            Assert.AreEqual("98", result);
        }

        [TestMethod]
        public void Parse_AccountLengthInput() {
            var input = String.Join("\n",
                "    _  _     _  _  _  _  _ ",
                "  | _| _||_||_ |_   ||_||_|",
                "  ||_  _|  | _||_|  ||_| _|",
                "                           ");

            var result = new OcrNumberParser().Parse(input);
            Assert.AreEqual("123456789", result);
        }

        [TestMethod]
        public void Parse_AccountLengthInput2() {
            var input = String.Join("\n",
                " _  _  _  _  _  _  _       ",
                "| ||_  _||_||_||_ | |  |  |",
                "|_| _| _| _||_||_||_|  |  |",
                "                              ");

            var result = new OcrNumberParser().Parse(input);
            Assert.AreEqual("053986011", result);
        }

        [TestMethod]
        public void Parse_IllegibleNumbersAreTurnedIntoQuestionMarks() {
            var input = String.Join("\n",
                " _  _ ",
                " _ |_|",
                " _  _ ",
                "                              ");

            var result = new OcrNumberParser().Parse(input);
            Assert.AreEqual("??", result);
        }
    }
}
