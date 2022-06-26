using System;
using Xunit;

namespace StringCalculatorKata
{

    public class StringCalculator_Add
    {

        private StringCalculator _calculator = new StringCalculator();


        [Fact]
        public void Return0GivenEmptyString()
        {
            var result = _calculator.Add("");
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        public void ReturnNumberGivenStringWithOneNumber(string numbers, int expectedResult)
        {
            var result = _calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("2,3,4", 9)]
        public void ReturnSumGivenStringWithMultipleComaSeparatedNumbers(string numbers,
        int expectedResult)
        {
            var result = _calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("1\n2,3", 6)]
        [InlineData("1\n2 \n 3", 6)]
        [InlineData("1\n2 ,3", 6)]
        public void ReturnSumGivenStringWithMultipleComaOrNewLineSeparatedNumbers(string numbers,
           int expectedResult)
        {
            var result = _calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("//;\n1;2;3", 6)]
        public void ReturnSumGivenStringWithCustomDelimiter(string numbers,
            int expectedResult)
        {
            var result = _calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("-1,2", "Negatives not allowed: -1")]
        [InlineData("-1,-2", "Negatives not allowed: -1,-2")]
        public void ThrowsGivenNegativeInputs(string numbers,
            string expectedMessage)
        {

            Action action = () => _calculator.Add(numbers);

            var exception = Assert.Throws<Exception>(() => action());

            Assert.Equal(expectedMessage, exception.Message);
        }

        [Theory]
        [InlineData("1,2,3000", 3)]
        [InlineData("1001,2", 2)]
        [InlineData("1000,2", 1002)]
        public void ReturnSumGivenStringIgnoringValuesOver1000(string numbers,
            int expectedResult)
        {
            var result = _calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }


        [Theory]
        [InlineData("//***\n1***2***3", 6)]
        public void ReturnSumUsingDelimitersOfAnyLength(string numbers,
          int expectedResult)
        {
            var result = _calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }






    }



}