using System;
using System.Collections.Generic;
using System.Text;

namespace calculator.Models.interfaces
{
    public interface IDelimiterService
    {
        (string[] delimiter, string operandSeparatedByDelimiter) Parse(string input);
    }
}
