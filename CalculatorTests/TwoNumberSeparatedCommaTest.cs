using calculator.Models;
using calculator.Services;
using System;
using Xunit;

namespace CalculatorTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("",0)]
        [InlineData("20",20)]
        [InlineData("1,5000",5001)]
        [InlineData("4,-3",1)]
        [InlineData("5,tytyty",5)]
        public void BinaryInputAddTest(string commaSeparatedOperands,int expectedResult)
        {
            var validationService = new ValidationService();
            var calService = new CalculatorService(validationService);
            var sum = calService.Add(commaSeparatedOperands);
            Assert.Equal(expectedResult, sum);
        }
        [Fact]
        public void BinaryInputAddExcpetionTest()
        {
            var validationService = new ValidationService();
            var calService = new CalculatorService(validationService);
            try
            {
                var sum = calService.Add("2,3,4");
            } catch (Exception ex)
            {
                Assert.IsType(typeof(NotBinaryOperandException), ex);
            }


        }
    }
}
