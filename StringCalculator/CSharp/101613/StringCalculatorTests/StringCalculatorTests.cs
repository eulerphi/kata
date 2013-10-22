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
        public void MyTestMethod() {
            this.calculator = new StringCalculator();
        }

        [TestMethod]
        public void Add_ShouldReturnZeroForEmptyValues() {
            var emptyValues = new List<string> { String.Empty, null };
            foreach (var value in emptyValues) {
                var result = this.calculator.Add(value);
                Assert.AreEqual(0, result);
            }
        }

        [TestMethod]
        public void Add_ShouldParseSingleValue() {
            var result = this.calculator.Add("3");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Add_ShouldSumDelimitedValues() {
            var result = this.calculator.Add("1,2");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Add_ShouldSupportNewlineDelimiters() {
            var result = this.calculator.Add("1,2\n3");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Add_ShouldSupportCustomDelimiters() {
            var result = this.calculator.Add("//;\n1,2;3");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "negatives not allowed: -2,-4")]
        public void Add_ShouldThrowForNegatives() {
            this.calculator.Add("1,-2,3,-4");
        }

        [TestMethod]
        public void Add_ShouldIgnoreNumbersGreaterThan1000() {
            var result = this.calculator.Add("1,999,1000,1001");
            Assert.AreEqual(2000, result);
        }
    }
}
