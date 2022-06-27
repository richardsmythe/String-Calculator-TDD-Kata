using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public string? newDelimiter;
        public IEnumerable<int> numberList;

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
                    newDelimiter = splitInput.First().Trim('/');


                    numbersString = String.Join('\n', splitInput.Skip(1));

                    // multiple delimiters should only be recorded as 1 character in delimiter list,
                    if (newDelimiter != null)
                    {
                        delimiters.Add(Convert.ToChar(newDelimiter[0]));
                    }
                }

                if ((newDelimiter != null) && (newDelimiter.Length > 1))
                {
                    numberList = numbersString.Split(new[] { newDelimiter }, System.StringSplitOptions.RemoveEmptyEntries)
                             .Select(s => int.Parse(s));
                }
                else
                {

                    numberList = numbersString.Split(delimiters.ToArray())
                    .Select(s => int.Parse(s));
                }

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


