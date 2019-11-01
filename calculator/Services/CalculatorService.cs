using calculator.Models;
using calculator.Models.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace calculator.Services
{
    public class CalculatorService : ICalculatorService
    {
        IValidationService _ValidationService;
        public CalculatorService(IValidationService validationService)
        {
            _ValidationService = validationService;
        }
        public int Add(string numbersSeparatedByComma)
        {

            var binaryOperands=_ValidationService.Validate(numbersSeparatedByComma);
            return binaryOperands.Operand1 + binaryOperands.Operand2;
        }

        public (List<int> operands, int sum) AddOperands(string numbersSeparatedByComma)
        {
            var isValidOperands = _ValidationService.ValidateMultipleOperands(numbersSeparatedByComma);
            if(!isValidOperands.isValid)
            {
                throw new NegativeOperandsException(isValidOperands.operands.Values);
            }
            return (isValidOperands.operands.Values, isValidOperands.operands.Values.Sum());
        }
    }
}
