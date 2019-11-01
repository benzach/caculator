﻿using calculator.Services;
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
        public void OperandListAddTest(string commaSeparated, int expected)
        {
            var delimterService = new DelimiterService();
            var validationService = new ValidationService(delimterService);
            
            var calService = new CalculatorService(validationService);
            var sum = calService.AddOperands(commaSeparated);
            Assert.Equal(expected, sum);

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
    }
}
