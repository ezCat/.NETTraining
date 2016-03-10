using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDiscovery
{
    public class StringCalculator : Calculator 
    {
        public double OnePlusTwo(string text)
        {
            double result = text.Split('+').Sum(int.Parse);
        
            return result;
        }
    }
}
