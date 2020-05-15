using AreaCalculator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AreaCalculator.Models
{
    public class Square : Figure
    {
        private readonly string Name = Shapes.Kwadrat.ToString();
        public double a { get; set; }

        public override double CalculateArea(Figure figure)
        {
            double area = this.a * this.a; 
            return area;
        }
    }
}
