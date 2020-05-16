using AreaCalculator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AreaCalculator.Models
{
    public class Square : Figure
    {
        public double DimA { get; set; }
        public override double CalculateArea()
        {            
            return DimA*DimA;
        }
    }
}
