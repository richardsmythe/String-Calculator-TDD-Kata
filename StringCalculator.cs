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
                var delimiters = new List<char>[] { ',', '\n' };
                //check if string starts with // 
                if (numbers.StartsWith("//"))
                {
                    var newDelimiter = numbers.Split('\n').First();
                    delimiters.Add(Convert.ToChar(newDelimiter));
                }

                // get sequence of ints
                var result = numbers.Split(delimiters.ToArray)
                .Select(s => int.Parse(s))
                .Sum();

                return result;
            }
        }
    }

}