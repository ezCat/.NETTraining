using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDiscovery
{
    using System.Runtime.InteropServices;

    public class Calculator
    {
        public string name;

        //public Calculator(string name)
        //{
        //    this.name = name;
        //}

        public double SumOfTheArray(double[] array)
        {
            double result = 0;
            int i;

            for (i = 0; i < array.Length; i++)
            {
                result = result + array[i];
            }
            return result;
        }

    }
}
