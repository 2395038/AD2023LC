using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Problem2.Models
{
    public class CalcCharges
    {
        public double getCharges(double a, double b)
        {
            double r = 0;

            if (a <= 2.0)
            {
                r = 1.10;
            }
            else if (a <= 6.0)
            {
                r = 2.20;
            }
            else if (a <= 10.0)
            {
                r = 3.70;
            }
            else
            {
                r = 4.80;
            }

            return (b / 500) * r;
        }
    }
}
