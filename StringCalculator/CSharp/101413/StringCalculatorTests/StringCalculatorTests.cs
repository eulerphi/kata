using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorLib;

namespace StringCalculatorTests {
    [TestClass]
    public class StringCalculatorTests {
        [TestMethod]
        public void Add_ShouldReturnZeroForEmptyValues() {
            var emptyValues = new string[] { null, String.Empty };
            foreach (var value in emptyValues) {
                var result = new StringCalculator().Add(value);
                Assert.AreEqual(0, result);
            }
        }

        [TestMethod]
        public void Add_ShouldParseSingleValue() {
            var result = new StringCalculator().Add("3");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Add_ShouldSumDelimitedValues() {
            var result = new StringCalculator().Add("1,2");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Add_ShouldSupportNewlineDelimiter() {
            var result = new StringCalculator().Add("1,2\n3");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Add_ShouldSupportCustomDelimiters() {
            var result = new StringCalculator().Add("//;\n1,2;3");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "negatives not allowed: -2,-4")]
        public void Add_ShouldThrowForNegatives() {
            new StringCalculator().Add("1,-2,3,-4");
        }
    }
}
