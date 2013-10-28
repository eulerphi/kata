using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOCRLib {
    public class ParseResult {
        public Collection<string> Alternates { get; private set; }
        public string Exact { get; set; }

        public ParseResult() {
            this.Alternates = new Collection<string>();
        }
    }


    public class OcrNumberParser {
        private static readonly Dictionary<string, string> patternToNumber;
        private static readonly Dictionary<string, List<string>> numberToAlternates;

        static OcrNumberParser() {
            patternToNumber = new Dictionary<string, string>();

            var numbers = String.Join("\n",
                " _     _  _     _  _  _  _  _ ",
                "| |  | _| _||_||_ |_   ||_||_|",
                "|_|  ||_  _|  | _||_|  ||_| _|",
                "                              ");

            var value = 0;
            foreach (var number in GetNumbers(numbers)) {
                patternToNumber.Add(number, (value++).ToString());
            }

            numberToAlternates = new Dictionary<string, List<string>>();
            //numberToAlternates.Add()
        }

        public ParseResult Parse(string input) {
            var output = String.Empty;
            var alternates = new List<List<string>>();
            foreach (var number in GetNumbers(input)) {
                output += this.ParseNumber(number);
                alternates.Add(this.ParseAlternates(number));
            }

            return new ParseResult { Exact = output };
        }

        private List<string> ParseAlternates(string number) {
            throw new NotImplementedException();
        }

        private static IEnumerable<string> GetNumbers(string input) {
            var lines = input.Split('\n');
            var numberOfColumns = lines[0].Length;

            var widthOfNumber = 3;
            for (var i = 0; i < numberOfColumns; i += widthOfNumber) {
                var numberLines = lines.Select(l => l.Substring(i, widthOfNumber));
                yield return String.Join("\n", numberLines);
            }
        }

        private string ParseNumber(string input) {
            string illegibleNumber = "?";

            string number;
            return patternToNumber.TryGetValue(input, out number) ? number : illegibleNumber;
        }
    }
}
