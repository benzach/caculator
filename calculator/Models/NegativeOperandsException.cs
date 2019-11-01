using System;
using System.Collections.Generic;
using System.Text;

namespace calculator.Models
{
    public class NegativeOperandsException:Exception
    {
        public NegativeOperandsException(List<int> negativeNumbers):base($"List of negative numbers: {string.Join(',', negativeNumbers)}")  {
        }
    }
}
