using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOCRLib {
    public class AccountValidationResult {
        public string AccountNumber { get; private set; }
        public string Result { get; private set; }

        public AccountValidationResult(string accountNumber, string result) {
            this.AccountNumber = accountNumber;
            this.Result = result;
        }
    }
}
