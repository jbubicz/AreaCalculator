using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AreaCalculator.Models
{
    public class Circle : Figure
    {
        public double DimR { get; set; }
        public override double CalculateArea()
        {
            return (DimR * DimR * Math.PI);
        }
    }
}

