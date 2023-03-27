using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1.Models
{
    class Calculator
    {
        public int a { get; set; }
        public int b { get; set; }

        public int Add(int a, int b) => a + b;
        public int Subtract(int a, int b) => a - b;
        public int Multiply(int a, int b) => a * b;
        public int Divide(int a, int b)
        {
            try
            {
                return a / b;
            }
            catch(DivideByZeroException)
            {
                throw new Exception("You can't divide by 0");
            }
        }

    }
}
