using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQToObject.Models
{
    interface IMath
    {
        /// <summary>
        /// It callculats the log of the base 10.
        /// <returns>Only returns streight numbers</returns>
        public static int Log10(int number)
        {
            double numberTemp = number;
            int counter = 0;
            while (numberTemp >= 10)
            {

                numberTemp = numberTemp / 10;
                counter++;

            }
            return counter;
        }
    }
}
