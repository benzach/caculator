using calculator.Models.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace calculator.Services
{
    public class DelimiterService : IDelimiterService
    {
        public (string[] delimiter, string operandSeparatedByDelimiter) Parse(string input)
        {
            var delimiterAtFront = new Regex(@"^//(.)\\n(.*)");
            var match = delimiterAtFront.Match(input);
            if(match.Success && match.Groups.Count>2)
            {
                return (new string[] { match.Groups[1].Value }, match.Groups[2].Value);
            }else
            {
                return (new string[] { }, input);
            }
        }
    }
}
