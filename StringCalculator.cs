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

                // get sequence of ints
                var result = numbersString.Split(delimiters.ToArray())
                .Select(s => int.Parse(s))
                .Sum();

                return result;
            }
        }
    }

}


