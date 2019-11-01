using System;
using System.Collections.Generic;
using System.Text;

namespace calculator.Models.extension
{
    public static class OperandExtensions
    {
        public static int ToIntOperand(this string operand)
        {
            if(int.TryParse(operand, out int ret))
            {
                return ret;
            }else
            {
                return 0;
            }
        }
    }
}
