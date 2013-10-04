using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StringCalculatorLib {
    public class StringCalculator {
        public int Add(string values) {
            var numbers = this.Split(values ?? String.Empty)
                              .Select(Parse);

            var negatives = numbers.Where(n => n < 0);
            if (negatives.Any()) {
                throw new ArgumentException("negatives not allowed: " + String.Join(",", negatives));
            }

            return numbers.Sum();
        }

        private string[] Split(string values) {
            var delimiters = new List<string> { ",", "\n" };

            var customDelimiter = Regex.Match(values, "//(?<custom>.)\n.*").Groups["custom"];
            if (customDelimiter.Success) {
                delimiters.Add(customDelimiter.Value);
            }

            return values.Split(delimiters.ToArray(), StringSplitOptions.None);
        }

        private int Parse(string value) {
            int parsedValue;
            return Int32.TryParse(value, out parsedValue) ? parsedValue : 0;
        }
    }
}
