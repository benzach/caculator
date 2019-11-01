using System;
using System.Collections.Generic;
using System.Text;

namespace calculator.Models.interfaces
{
    public interface IValidationService
    {
        BinaryOperands Validate(string commaSeparatedOperands);
        (bool isValid, Operands operands) ValidateMultipleOperands(string commaSeparatedOperands, string alternative="", bool denyNegative = true, int maxOperand = 1000);
    }
            
}
