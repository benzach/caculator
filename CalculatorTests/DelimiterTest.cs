using calculator.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CalculatorTests
{
    public class DelimiterTest
    {
        [Theory]
        [InlineData(@"//#\n2#5",new string[] { "#"},"2#5")]
        [InlineData(@"2,3,4", new string[] { },"2,3,4")]
        [InlineData(@"//[***]\n11***22***33",new string[] {"***"},"11***22***33")]
        public void ParseInputTest(string input,string[] delimiter, string customCharDelimiter)
        {
            var service = new DelimiterService();
            var res=service.Parse(input);
            Assert.Equal(delimiter,res.delimiter);
            Assert.Equal(customCharDelimiter, res.operandSeparatedByDelimiter);
        }
    }
}
