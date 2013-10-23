using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOCRLib {
    public class OcrNumberParser {
        private static readonly Dictionary<string, int> stringToNumber;

        static OcrNumberParser() {
            stringToNumber = new Dictionary<string, int>();

            var numbers = String.Join("\n",
                " _     _  _     _  _  _  _  _ ",
                "| |  | _| _||_||_ |_   ||_||_|",
                "|_|  ||_  _|  | _||_|  ||_| _|",
                "                              ");

            var value = 0;
            foreach (var number in GetNumbers(numbers)) {
                stringToNumber.Add(number, value++);
            }
        }
        public int ParseNumber(string input) {
            return stringToNumber[input];
        }

        public static IEnumerable<string> GetNumbers(string input) {
            var lines = input.Split('\n');
            var numberOfColumns = lines[0].Length;

            var numberWidth = 3;
            for (var startIndex = 0; startIndex < numberOfColumns; startIndex += numberWidth) {
                var numberLines = lines.Select(l => l.Substring(startIndex, numberWidth));
                 yield return String.Join("\n", numberLines);
            }
        }

        public string Parse(string input) {
            var output = String.Empty;
            foreach (var number in GetNumbers(input)) {
                output += this.ParseNumber(number);
            }

            return output;
        }
    }
}
