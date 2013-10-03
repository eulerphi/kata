using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StringCalculatorLib {
    public class StringCalculator {
        public int Add(string values) {
            return Split(values ?? String.Empty).Select(Parse).Sum();
        }

        private static string[] Split(string values) {
            var delimiters = new List<string> { ",", "\n" };

            var customDelimiter = Regex.Match(values, "//(?<custom>.)\n.*").Groups["custom"];
            if (customDelimiter.Success) {
                delimiters.Add(customDelimiter.Value);
            }

            return values.Split(delimiters.ToArray(), StringSplitOptions.None);
        }

        private static int Parse(string values) {
            int parsedValue;
            return Int32.TryParse(values, out parsedValue) ? parsedValue : 0;
        }
    }
}
