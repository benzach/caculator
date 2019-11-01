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
        public static (bool isValid, int value) ToIsValidOperand(this string operand,int maxVal,bool denyNegative)
        {
            if(int.TryParse(operand, out int ret))
            {
                if(denyNegative && ret<0)
                {
                    return (false, ret);
                }
                if(ret>maxVal)
                {
                    return (true, 0);
                }
                return (true, ret);
            }else
            {
                return (true, 0);
            }
        }
    }
}
