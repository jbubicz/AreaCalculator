using AreaCalculator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AreaCalculator.Models
{
    public abstract class Figure
    {
        public string Name { get; set; }
        public Shapes Shape { get; set; }

        public string Sizes { get; set; }
        public abstract double CalculateArea();

    }
}
