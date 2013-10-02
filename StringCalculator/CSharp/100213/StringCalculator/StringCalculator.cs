﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculatorLib {
    public class StringCalculator {
        public int Add(string values) {
            var numbers = this.Split(values ?? String.Empty)
                              .Select(this.Parse)
                              .Where(n => n <= 1000);

            this.ValidateNoNegatives(numbers);

            return numbers.Sum();
        }

        private string[] Split(string values) {
            var delimiters = new List<string> { ",", "\n" };

            var custom = Regex.Match(values, @"//(\[?(?<custom>[^\]]+)\]?)+\n.*").Groups["custom"];
            delimiters.AddRange(custom.Captures.Cast<Capture>().Select(c => c.Value));

            return values.Split(delimiters.ToArray(), StringSplitOptions.None);
        }

        private int Parse(string value) {
            int parsedValue;
            return Int32.TryParse(value, out parsedValue) ? parsedValue : 0;
        }

        private void ValidateNoNegatives(IEnumerable<int> numbers) {
            var negatives = numbers.Where(n => n < 0);
            if (negatives.Any()) {
                throw new ArgumentException(
                    "negatives not allowed: " + String.Join(",", negatives));
            }
        }
    }
}
