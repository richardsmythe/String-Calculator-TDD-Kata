using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public string newDelimiter;
        public IEnumerable<int> numberList;

        internal object Add(string numbers)
        {

            if (String.IsNullOrEmpty(numbers))
                return 0;

            else
            {
                // given delimters
                var delimiters = new List<char> { ',', '\n' };

                string numbersString = numbers;

                if (numbersString.StartsWith("//"))
                {
                    var splitInput = numbersString.Split('\n');
                    var tmpStr = splitInput[0] + splitInput[1];
                    numbersString = tmpStr;
                    newDelimiter = splitInput.First().Trim('/');
                    numbersString = numbersString.Substring(2);

                    for (int i = 0; i < numbersString.Length; i++)
                    {
                        if (numbersString[i] != numbersString[i] + 1)
                        {
                            bool isNum = numbersString[i].ToString().Any(char.IsDigit);
                            if ((!isNum) && (!delimiters.Contains(numbersString[i])))
                            {
                                delimiters.Add(Convert.ToChar(numbersString[i]));
                            }
                        }
                        else
                        {               
                            delimiters.Add(Convert.ToChar(newDelimiter[0]));
                        }

                    }
                    bool clearNewDelimiter = delimiters.Contains(Convert.ToChar(newDelimiter.FirstOrDefault()));
                    if (clearNewDelimiter)
                    {
                        // clear newDelimiters variable if delimiters List contains same chars
                        newDelimiter = null;
                    }
                    
                    if (newDelimiter != null)
                    {
                        delimiters.Add(Convert.ToChar(newDelimiter[0]));
                    }
                }

                if ((newDelimiter != null) && (newDelimiter.Length > 1) )
                {
                    numberList = numbersString.Split(new[] { newDelimiter }, System.StringSplitOptions.RemoveEmptyEntries)
                             .Select(s => int.Parse(s));
                }
                else
                {
                    numberList = numbersString.Split(delimiters.ToArray())
                     .Where(s => !string.IsNullOrWhiteSpace(s))
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


