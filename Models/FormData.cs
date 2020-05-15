using AreaCalculator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AreaCalculator.Models
{
    public class FormData
    {
        public Shapes Shapes { get; set;}
        public Shapes ChosenFigure { get; set;}
        public string Sizes { get; set; }
        public string Area { get; set; }
    }
}
