using System;
using System.Collections.Generic;
using System.Text;

namespace calculator.Models.interfaces
{
    public interface ICalculatorService
    {
        int Add(string numbersSeparatedByComma);
        (List<int> operands, int sum) AddOperands(string numbersSeparatedByComma, string alternative = "", bool denyNegative = true, int maxOperand = 1000);
    }
}
