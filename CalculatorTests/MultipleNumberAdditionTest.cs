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
        [InlineData("1\n2,3", 6)]
        [InlineData("1,5000", 1)]
        [InlineData("1\n5000\n", 1)]
        [InlineData("2,1001,6", 8)]
        [InlineData("2,1001\n6", 8)]
        [InlineData("5,tytyty", 5)]
        [InlineData("5\ntytyty", 5)]
        [InlineData("1,2,3,4,5,6,7,8,9,10,11,12", 78)]
        [InlineData("1\n2\n3,4,5\n6,7,8,9,10,11,12", 78)]
        [InlineData("1\n2\n3,4,5\n6,7,8,9,10,11,12\n", 78)]
        [InlineData(@"//#\n2#5", 7)]
        [InlineData(@"//,\n2,5,9", 16)]
        [InlineData(@"//,\n2,ff,100", 102)]
        [InlineData(@"//[***]\n11***22***33", 66)]
        [InlineData(@"//[###]\n11###22###33", 66)]
        [InlineData(@"//[*][!!][r9r]\n11r9r22*hh*33!!44", 110)]
        public void OperandListAddTest(string commaSeparated, int expected)
        {
            var delimterService = new DelimiterService();
            var validationService = new ValidationService(delimterService);
            
            var calService = new CalculatorService(validationService);
            var sum = calService.AddOperands(commaSeparated);
            Assert.Equal(expected, sum.sum);

        }
        [Theory]
        [InlineData("1,5000", 1)]
        [InlineData("1\n5000\n", 1)]
        [InlineData("2,1001,6", 1009)]
        [InlineData("2,1001\n6", 1009)]
        public void OperandListAndTestWitLimit2000(string input, int expectedResult)
        {
            var delimterService = new DelimiterService();
            var validationService = new ValidationService(delimterService);

            var calService = new CalculatorService(validationService);
            var sum = calService.AddOperands(input,"",true,2000);
            Assert.Equal(expectedResult, sum.sum);

        }
        [Theory]
        [InlineData("1b5000","b", 1)]
        [InlineData("1c5000c","c", 1)]
        [InlineData("2*1001*6","*", 1009)]
        [InlineData("2i1001i6","i", 1009)]
        public void OperandListAndTestDiffDelimiter(string input, string delimiter, int expectedResult)
        {
            var delimterService = new DelimiterService();
            var validationService = new ValidationService(delimterService);

            var calService = new CalculatorService(validationService);
            var sum = calService.AddOperands(input, delimiter, true, 2000);
            Assert.Equal(expectedResult, sum.sum);

        }


        [Theory]
        [InlineData("4,-3", 1)]
        [InlineData("4,-3,-2,-1,-9", -11)]
        [InlineData("4,-3\n-2\n-1,-9", -11)]
        public void OperandListAndTestWitLimitAllowNegative(string input, int expectedResult)
        {
            var delimterService = new DelimiterService();
            var validationService = new ValidationService(delimterService);

            var calService = new CalculatorService(validationService);
            var sum = calService.AddOperands(input, "", false, 2000);
            Assert.Equal(expectedResult, sum.sum);

        }

        [Theory]
        [InlineData("4,-3", new int[] { -3 })]
        [InlineData("4,-3,-2,-1,-9",new int[]{-3,-2,-1,-9})]
        [InlineData("4,-3\n-2\n-1,-9", new int[] { -3, -2, -1, -9 })]
        public void OperandListAddTestExeption(string commaSeparated,int[] expected)
        {
            var delimterService = new DelimiterService();

            var validationService = new ValidationService(delimterService);

            var calService = new CalculatorService(validationService);
            try
            {
                var sum = calService.AddOperands(commaSeparated);
            }catch(Exception ex)
            {
                Assert.Contains(string.Join(',', expected), ex.Message);
            }
            

        }

        [Theory]
        [InlineData("1,5000", 0)]
        [InlineData("5000\n2", 2500)]
        [InlineData("1000,2,2", 250)]
        [InlineData("100,2\n2", 25)]
        public void DivisionListAndTestWitLimit2000(string input, int expectedResult)
        {
            var delimterService = new DelimiterService();
            var validationService = new ValidationService(delimterService);

            var calService = new CalculatorService(validationService);
            var sum = calService.DivisionOperands(input, "", true, 6000);
            Assert.Equal(expectedResult, sum.result);

        }
        [Theory]
        [InlineData("1,5000", 5000)]
        [InlineData("5000\n2", 10000)]
        [InlineData("1000,2,2", 4000)]
        [InlineData("100,2\n2", 400)]
        public void MultiplyListAndTestWitLimit2000(string input, int expectedResult)
        {
            var delimterService = new DelimiterService();
            var validationService = new ValidationService(delimterService);

            var calService = new CalculatorService(validationService);
            var sum = calService.MultiplyOperands(input, "", true, 6000);
            Assert.Equal(expectedResult, sum.result);

        }
        [Theory]
        [InlineData("5000,1", 4999)]
        [InlineData("5000\n2", 4998)]
        [InlineData("1000,2,2", 996)]
        [InlineData("100,2\n2", 96)]
        public void SubtractListAndTestWitLimit2000(string input, int expectedResult)
        {
            var delimterService = new DelimiterService();
            var validationService = new ValidationService(delimterService);

            var calService = new CalculatorService(validationService);
            var sum = calService.SubtractOperands(input, "", true, 6000);
            Assert.Equal(expectedResult, sum.result);

        }
    }
}
