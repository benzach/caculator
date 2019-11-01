using calculator.Models;
using calculator.Models.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

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
            var operands = commaSeparatedOperands.Split(new char[] { ',' });
            if(operands.Length>2)
            {
                throw new NotBinaryOperandException();
            }
            if(operands.Length==1)
            {
                if(int.TryParse(operands[0], out int operandNumber1))
                {
                    return new BinaryOperands { Operand1 = operandNumber1, Operand2 = 0 };
                }else
                {
                    return new BinaryOperands { Operand1 = 0, Operand2 = 0 };
                }
            }
            if(operands.Length==2)
            {
                BinaryOperands ret = new BinaryOperands { Operand1 = 0, Operand2 = 0 };
                if(int.TryParse(operands[0],out int operandNumber1))
                {
                    ret.Operand1 = operandNumber1;
                }
                if(int.TryParse(operands[1],out int operandNumber2))
                {
                    ret.Operand2 = operandNumber2;
                }
                return ret;
            }
            throw new ArgumentException();
        }
    }
}
