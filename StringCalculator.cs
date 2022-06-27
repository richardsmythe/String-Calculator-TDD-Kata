using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        internal object Add(string numbers)
        {
            if (String.IsNullOrEmpty(numbers))
                return 0;

            else
            {
                var delimiters = new List<char> { ',', '\n' };

                string numbersString = numbers;
                //check if string starts with '//'
                if (numbersString.StartsWith("//"))
                {
                    // rebuild string without the '//'
                    var splitInput = numbersString.Split('\n');
                    var newDelimiter = splitInput.First().Trim('/');
                    numbersString = String.Join('\n', splitInput.Skip(1));
                    delimiters.Add(Convert.ToChar(newDelimiter));
                }
                //bool res = delimiters.Any(s => numbersString.Contains(s));

                var currentDelimiter = delimiters.Last();
                var numberList = numbersString.Split(new[] { currentDelimiter }, System.StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => int.Parse(s));

                var negatives = numberList.Where(n => n < 0);

                if (negatives.Any())
                {
                    string negativestring = String.Join(',', negatives
                        .Select(n => n.ToString()));
                    throw new Exception($"Negatives not allowed: {negativestring}");
                }


                var result = numberList.Where(n => n <= 1000).Sum();

                return result;
            }
        }
    }

}


