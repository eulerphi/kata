using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOCRLib {
    public class Parser {
        private static readonly Dictionary<string, int> stringToNumber;

        static Parser() {
            stringToNumber = new Dictionary<string, int>();

            var zero = String.Join("\n",
                " _ ",
                "| |",
                "|_|",
                "   ");
            stringToNumber.Add(zero, 0);

            var one = String.Join("\n",
                "   ",
                "  |",
                "  |",
                "   ");
            stringToNumber.Add(one, 1);

            var two = String.Join("\n",
                " _ ",
                " _|",
                "|_ ",
                "   ");
            stringToNumber.Add(two, 2);

        }
        public int ParseNumber(string input) {
            return stringToNumber[input];
        }

        public string GetNumberAtIndex(string input, int index) {
            var numberWidth = 3;
            var startColumn = index * 3;

            var lines = input.Split('\n');
            var sublines = lines.Select(
                line => line.Substring(startColumn, numberWidth));

            return String.Join("\n", sublines);
        }
    }
}
