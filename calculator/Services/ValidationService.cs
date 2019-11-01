using calculator.Models;
using calculator.Models.interfaces;
using System;
using System.Linq;
using static calculator.Models.extension.OperandExtensions;

namespace calculator.Services
{
    public class ValidationService : IValidationService
    {
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
                ret.Values.AddRange(new [] { 0, 0 });
                return (true,ret);
            }
            var operands = commaSeparatedOperands.Split(new char[] { ',','\n' });
            if (operands.Length <= 2)
            {
                var binary = Validate(commaSeparatedOperands);
                ret.Values.Add(binary.Operand1);
                ret.Values.Add(binary.Operand2);
                if(binary.Operand1<0 || binary.Operand2<0)
                {
                    var negativeoperands = new Operands();
                    if (binary.Operand1 < 0)
                    {
                        negativeoperands.Values.Add(binary.Operand1);
                    }
                    if (binary.Operand2 < 0)
                    {
                        negativeoperands.Values.Add(binary.Operand2);
                    }
                    return (false, negativeoperands);
                }
                return (true,ret);
            }
            ret.Values.AddRange(operands.Select(x => x.ToIntOperand()));
            if(ret.Values.Any(x=>x<0))
            {
                var negativeResult = new Operands();
                negativeResult.Values.AddRange(ret.Values.Where(x => x < 0).ToList());
                return (false, negativeResult);
            }
            return (true,ret);
        }
    }
}
