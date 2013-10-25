using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOCRLib {
    public class AccountProcessor {
        private const int AccountNumberLength = 9;

        public AccountValidationResult Validate(string accountNumber) {
            var legible = !accountNumber.Contains("?");
            var validChecksum = legible && this.ValidateChecksum(accountNumber);

            var result = String.Empty;
            if (!validChecksum) {
                result = "ERR";
            }
            if (!legible) {
                result = "ILL";
            }

            return new AccountValidationResult(accountNumber, result);

        }

        public bool ValidateChecksum(string accountNumber) {
            var sum = 0;
            for (var scalar = 1; scalar <= AccountNumberLength; scalar++) {
                var index = AccountNumberLength - scalar;
                var number = this.GetNumberAtIndex(accountNumber, index);
                sum += number * scalar;
            }

            return sum % 11 == 0;

        }

        private int GetNumberAtIndex(string input, int index) {
            return Int32.Parse(input[index].ToString());
        }
    }
}
