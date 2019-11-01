using calculator.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CalculatorTests
{
    public class MultipleNumberAdditionTest
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("20", 20)]
        [InlineData("20,", 20)]
        [InlineData("20\n", 20)]
        [InlineData("1\n2,3",6)]
        [InlineData("1,5000", 5001)]
        [InlineData("1\n5000\n", 5001)]
        [InlineData("4,-3", 1)]
        [InlineData("5,tytyty", 5)]
        [InlineData("5\ntytyty", 5)]
        [InlineData("1,2,3,4,5,6,7,8,9,10,11,12", 78)]
        [InlineData("1\n2\n3,4,5\n6,7,8,9,10,11,12", 78)]
        [InlineData("1\n2\n3,4,5\n6,7,8,9,10,11,12\n", 78)]
        public void OperandListAddTest(string commaSeparated,int expected)
        {
            var validationService = new ValidationService();
            var calService = new CalculatorService(validationService);
            var sum = calService.AddOperands(commaSeparated);
            Assert.Equal(expected, sum);

        }
    }
}
