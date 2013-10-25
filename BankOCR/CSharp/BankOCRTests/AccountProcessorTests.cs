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

        [TestMethod]
        public void Validate_Valid() {
            var accountNumber = "345882865";
            var processor = new AccountProcessor();
            var result = processor.Validate(accountNumber);

            Assert.AreEqual(accountNumber, result.AccountNumber);
            Assert.AreEqual(String.Empty, result.Result);
        }

        [TestMethod]
        public void Validate_Illegible() {
            var accountNumber = "34?882?65";
            var processor = new AccountProcessor();
            var result = processor.Validate(accountNumber);

            Assert.AreEqual(accountNumber, result.AccountNumber);
            Assert.AreEqual("ILL", result.Result);
        }

        [TestMethod]
        public void Validate_InvalidChecksum() {
            var accountNumber = "345882861";
            var processor = new AccountProcessor();
            var result = processor.Validate(accountNumber);

            Assert.AreEqual(accountNumber, result.AccountNumber);
            Assert.AreEqual("ERR", result.Result);
        }
    }
}
