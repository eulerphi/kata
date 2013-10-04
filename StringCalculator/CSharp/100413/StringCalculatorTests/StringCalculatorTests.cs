using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorLib;

namespace StringCalculatorTests {
    [TestClass]
    public class StringCalculatorTests {
        private StringCalculator calculator;

        [TestInitialize]
        public void Initialize() {
            calculator = new StringCalculator();
        }
        
        [TestMethod]
        public void Add_ShouldReturnZeroForEmptyValues() {
            var emptyValues = new string[] { String.Empty, null };
            foreach (var value in emptyValues) {
                var result = calculator.Add(value);
                Assert.AreEqual(0, result);
            }
        }

        [TestMethod]
        public void Add_ShouldParseSingleValue() {
            var result = calculator.Add("3");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Add_ShouldSumDelimitedValues() {
            var result = calculator.Add("1,2");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Add_ShouldSupportNewlineDelimiter() {
            var result = calculator.Add("1,2\n3");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Add_ShouldSupportCustomDelimiter() {
            var result = calculator.Add("//;\n1,2;3");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "negatives not allowed: -2,-4")]
        public void Add_ShouldThrowForNegatives() {
            var result = calculator.Add("1,-2,3,-4");
        }
    }
}
