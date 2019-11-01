using System;
using System.Collections.Generic;
using System.Text;

namespace calculator.Models.interfaces
{
    public interface IValidationService
    {
        BinaryOperands Validate(string commaSeparatedOperands);
    }
}
