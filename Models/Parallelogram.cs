﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AreaCalculator.Models
{
    public class Parallelogram : Figure
    {
        public double DimA { get; set; }
        public double DimH { get; set; }
        public override double CalculateArea()
        {
            return DimA * DimH;
        }
    }
}
