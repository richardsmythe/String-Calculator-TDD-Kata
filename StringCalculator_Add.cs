using System;
using Xunit;

namespace StringCalculatorKata
{

    public class StringCalculator_Add
    {
        [Fact]
        public void Return0GivenEmptyString()
        {
            var calculator = new StringCalculator();

            var result = calculator.Add("");

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        public void ReturnNumberGivenStringWithOneNumber(string numbers, int expectedResult)
        {
            var calculator = new StringCalculator();

            var result = calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("2,3", 5)]
        public void ReturnSumGivenStringWithTwoComaSeparatedNumbers(string numbers, int expectedResult)
        {
            var calculator = new StringCalculator();

            var result = calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }




    }



}