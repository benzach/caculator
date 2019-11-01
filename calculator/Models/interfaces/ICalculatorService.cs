using System;
using System.Collections.Generic;
using System.Text;

namespace calculator.Models.interfaces
{
    public interface ICalculatorService
    {
        int Add(string numbersSeparatedByComma);
    }
}
