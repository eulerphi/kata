using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankOCRLib;

namespace BankOCRTests {
    [TestClass]
    public class AccountProcessorTests {
        [TestMethod]
        public void ValidateChecksum_Valid() {
            var input = "345882865";
            var processor = new AccountProcessor();
            Assert.IsTrue(processor.ValidateChecksum(input));
        }

        [TestMethod]
        public void ValidateChecksum_Invalid() {
            var input = "345882866";
            var processor = new AccountProcessor();
            Assert.IsFalse(processor.ValidateChecksum(input));
        }
    }
}
