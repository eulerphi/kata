using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankOCRLib;

namespace BankOCRTests {
    [TestClass]
    public class ParserTests {
        [TestMethod]
        public void ParserNumber_ShouldParseZero() {
            //var toParse =
            //        " _     _  _     _  _  _  _  _ " +
            //        "| |  | _| _||_||_ |_   ||_||_|" +
            //        "|_|  ||_  _|  | _||_|  ||_| _|" +
            //        "                              ";
            var zero = String.Join("\n",
                " _ ",
                "| |",
                "|_|",
                "   ");

            var parser = new Parser();
            var result = parser.ParseNumber(zero);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ParserNumber_ShouldParseOne() {
            var one = String.Join("\n",
                "   ",
                "  |",
                "  |",
                "   ");

            var parser = new Parser();
            var result = parser.ParseNumber(one);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void ParseNumber_ShouldParseTwo() {
            var two = String.Join("\n",
                " _ ",
                " _|",
                "|_ ",
                "   ");

            var parser = new Parser();
            var result = parser.ParseNumber(two);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void GetNumberAtIndex() {
            var input = String.Join("\n",
                " _     _  _     _  _  _  _  _ ",
                "| |  | _| _||_||_ |_   ||_||_|",
                "|_|  ||_  _|  | _||_|  ||_| _|",
                "                              ");

            var parser = new Parser();
            var result = parser.GetNumberAtIndex(input, 0);

            var zero = String.Join("\n",
                " _ ",
                "| |",
                "|_|",
                "   ");
            Assert.AreEqual(zero, result);

            result = parser.GetNumberAtIndex(input, 1);
            var one = String.Join("\n",
                "   ",
                "  |",
                "  |",
                "   ");
            Assert.AreEqual(one, result);
        }
    }
}
