using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOCRLib {
    public class AccountProcessor {
        private const int AccountNumberLength = 9;

        public bool ValidateChecksum(string input) {
            var sum = 0;
            for (var scalar = 1; scalar <= AccountNumberLength; scalar++) {
                var index = AccountNumberLength - scalar;
                var number = this.GetNumberAtIndex(input, index);
                sum += number * scalar;
            }

            return sum % 11 == 0;

        }

        private int GetNumberAtIndex(string input, int index) {
            return Int32.Parse(input[index].ToString());
        }
    }
}
