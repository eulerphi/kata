using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankOCRLib;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
            Assert.AreEqual("98", result.Exact);
        }

        [TestMethod]
        public void Parse_AccountLengthInput() {
            var input = String.Join("\n",
                "    _  _     _  _  _  _  _ ",
                "  | _| _||_||_ |_   ||_||_|",
                "  ||_  _|  | _||_|  ||_| _|",
                "                           ");

            var result = new OcrNumberParser().Parse(input);
            Assert.AreEqual("123456789", result.Exact);
        }

        [TestMethod]
        public void Parse_AccountLengthInput2() {
            var input = String.Join("\n",
                " _  _  _  _  _  _  _       ",
                "| ||_  _||_||_||_ | |  |  |",
                "|_| _| _| _||_||_||_|  |  |",
                "                              ");

            var result = new OcrNumberParser().Parse(input);
            Assert.AreEqual("053986011", result.Exact);
        }

        [TestMethod]
        public void Parse_IllegibleNumbersAreTurnedIntoQuestionMarks() {
            var input = String.Join("\n",
                " _  _ ",
                " _ |_|",
                " _  _ ",
                "                              ");

            var result = new OcrNumberParser().Parse(input);
            Assert.AreEqual("??", result.Exact);
        }

        [TestMethod]
        public void Parse_Alternates() {
            var input = String.Join("\n",
                " _  _ ",
                " _|| |",
                " _||_|",
                "      ");

            var result = new OcrNumberParser().Parse(input);
            Assert.AreEqual("30", result.Exact);

            var alternates = new Collection<string> { "98" };
            CollectionAssert.AreEquivalent(alternates, result.Alternates);
        }
    }
}
