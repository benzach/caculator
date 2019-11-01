using calculator.Models.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace calculator.Services
{
    public class DelimiterService : IDelimiterService
    {
        public (string[] delimiter, string operandSeparatedByDelimiter) Parse(string input)
        {
            if(string.IsNullOrEmpty(input) || input.Substring(0,2)!="//")
            {
                return (new string[] { }, input);
            }
            var delimiterAtFront = new Regex(@"^//(.)\\n(.*)");

            var match = delimiterAtFront.Match(input);
            if(match.Success && match.Groups.Count>2)
            {
                return (new string[] { match.Groups[1].Value }, match.Groups[2].Value);
            }else
            {
                var delimiterAndInput = input.Split(new string[] { @"\n" },StringSplitOptions.None);
                var delimeters = delimiterAndInput[0].Split(new char[] { '[' });
                if(delimeters.Length==2)
                {
                    var a = delimeters[1].Substring(0, delimeters[1].Length - 1);
                    return (new string[] { a}, delimiterAndInput[1]);
                }else
                {
                    var delim = delimeters.Skip(1).Select(x => x.Substring(0, x.Length - 1)).ToArray();
                    return (delim, delimiterAndInput[1]);
                }
            }
        }
    }
}
