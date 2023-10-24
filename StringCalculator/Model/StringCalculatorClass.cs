using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Model
{
    public static class StringCalculatorClass
    {
        private static string delimiter = ",";
        private static string newDelimiterSimbol = "//";
        private static int newDelimiterPosition = 3;

        public static int add(string inputNumbers)
        {
            if (string.IsNullOrEmpty(inputNumbers)) { return 0; }
            IEnumerable<int> numbers = TransformInput(inputNumbers);
            CheckNegativeNumbers(numbers);
            return numbers.Where(number => number <= 1000).Sum();
        }

        private static IEnumerable<int> TransformInput(string inputNumbers)
        {
            var actualDelimiter = delimiter;

            if (inputNumbers.Contains(newDelimiterSimbol))
            {
                actualDelimiter = inputNumbers[2].ToString();
                inputNumbers = inputNumbers.Remove(0, newDelimiterPosition);
            }

            inputNumbers = inputNumbers.Replace("\n", actualDelimiter);
            var nums = inputNumbers.Split(actualDelimiter).Select(int.Parse);

            return nums;
        }

        private static void CheckNegativeNumbers(IEnumerable<int> numbers)
        {
            var negatives = numbers.Where(number => number < 0);
            if (negatives.Count() > 0)
            {
                throw new NegativesNotAlloweException(negatives);
            }
        }
    }
}
