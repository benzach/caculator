using calculator.Models;
using calculator.Models.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using static calculator.Models.extension.OperandExtensions;

namespace calculator.Services
{
    public class ValidationService : IValidationService
    {
        private readonly IDelimiterService _DelimiterService;
        public ValidationService(IDelimiterService DelimiterService)
        {
            _DelimiterService = DelimiterService;
        }
        public BinaryOperands Validate(string commaSeparatedOperands)
        {
            //empty input string is converted to 0
            if(string.IsNullOrEmpty(commaSeparatedOperands))
            {
                return new BinaryOperands { Operand1 = 0, Operand2 = 0 };
            }
            var operands = commaSeparatedOperands.Split(new char[] { ',','\n' });
            if(operands.Length>2)
            {
                throw new NotBinaryOperandException();
            }
            if(operands.Length==1)
            {
                return new BinaryOperands { Operand1 = operands[0].ToIntOperand(), Operand2= 0 };
            }
            if(operands.Length==2)
            {
                BinaryOperands ret = new BinaryOperands { Operand1 = 0, Operand2 = 0 };
                ret.Operand1 = operands[0].ToIntOperand();
                ret.Operand2 = operands[1].ToIntOperand();
                return ret;
            }
            throw new ArgumentException();
        }

        public (bool isValid, Operands operands) ValidateMultipleOperands(string commaSeparatedOperands)
        {
            var ret = new Operands();

            if (string.IsNullOrEmpty(commaSeparatedOperands))
            {
                ret.Values.AddRange(new[] { 0, 0 });
                return (true, ret);
            }


            var delimterAndInput = _DelimiterService.Parse(commaSeparatedOperands);

            string[] delimiters;
            if(delimterAndInput.delimiter.Length==0)
            {
                delimiters = new string[] { ",", "\n" };
            }else
            {
                delimiters = delimterAndInput.delimiter;
                commaSeparatedOperands = delimterAndInput.operandSeparatedByDelimiter;
            }

            var operands = commaSeparatedOperands.Split(delimiters,StringSplitOptions.None);
            if (operands.Select(x => x.ToIsValidOperand()).Any(x => !x.isValid))
            {
                var negativeResult = new Operands();
                negativeResult.Values.AddRange(
                                            operands.Select(x => x.ToIsValidOperand())
                                            .Where(x => !x.isValid)
                                            .Select(x => x.value)
                                        );
                return (false, negativeResult);
            }

            ret.Values.AddRange(operands.Select(x => x.ToIsValidOperand().value));
            return (true,ret);
        }
    }
}
