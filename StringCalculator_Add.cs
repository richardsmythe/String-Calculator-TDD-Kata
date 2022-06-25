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
        public void Return1GivenStringWith1(string numbers, int expectedResult)
        {
            var calculator = new StringCalculator();

            var result = calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }



    }



}