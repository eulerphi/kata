using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorLib;

namespace StringCalculatorTests {
    [TestClass]
    public class StringCalculatorTests {
        private StringCalculator c;

        [TestInitialize]
        public void Initialize() {
            c = new StringCalculator();
        }

        [TestMethod]
        public void Add_ShouldReturnZeroForEmptyValues() {
            var emptyValues = new string[] { String.Empty, null };
            var results = emptyValues.Select(v => c.Add(v));
            foreach (var result in results) {
                Assert.AreEqual(0, result);
            }
        }

        [TestMethod]
        public void Add_ShouldParseSingleValue() {
            var result = c.Add("3");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Add_ShouldSumDelimitedValues() {
            var result = c.Add("1, 2");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Add_ShouldSupportNewlineDelimiters() {
            var result = c.Add("1,2\n3");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Add_ShouldSupportCustomDelimiters() {
            var result = c.Add("//;\n1,2;3");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "negatives not allowed: -2, -4")]
        public void Add_ShouldThrowForNegatives() {
            c.Add("1,-2,3,-4");
        }
    }
}
