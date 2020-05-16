using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AreaCalculator.Models
{
    public class Rectangle : Figure
    {
        public double DimA { get; set; }
        public double DimB { get; set; }
        public override double CalculateArea()
        {
            return DimA * DimB;
        }
    }
}
