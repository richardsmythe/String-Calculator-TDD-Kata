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
                // get sequence of ints
                var delimiters = new char[] { ',', '\n' };
                var result = numbers.Split(delimiters)
                .Select(s => int.Parse(s))
                .Sum();

                return result;
            }
        }
    }

}