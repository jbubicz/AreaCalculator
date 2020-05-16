using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AreaCalculator.Models;
using AreaCalculator.Enums;

namespace AreaCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new FigureData());
            //return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult Index(FigureData formData)
        {
            string dims = formData.Dimensions;
            double result = 0;

            try
            {
                if (formData.Dimensions.Contains("."))
                {
                    dims = formData.Dimensions.Replace('.', ',');
                }
                string[] sizesArray = dims.Split(new Char[] { ';' });


                switch (formData.Shape)
                {
                    case Shapes.Koło:
                        Circle circle = new Circle();
                        circle.DimR = Convert.ToDouble(sizesArray[0].Trim());
                        result = Math.Round(circle.CalculateArea(), 2);
                        break;
                    case Shapes.Kwadrat:
                        Square square = new Square();
                        square.DimA = Convert.ToDouble(sizesArray[0].Trim());
                        result = Math.Round(square.CalculateArea(), 2);
                        break;
                    case Shapes.Prostokąt:
                        Rectangle rectangle = new Rectangle();
                        rectangle.DimA = Convert.ToDouble(sizesArray[0].Trim());
                        rectangle.DimB = Convert.ToDouble(sizesArray[1].Trim());
                        result = Math.Round(rectangle.CalculateArea(), 2);
                        break;
                    case Shapes.Romb:
                        Rhombus rhombus = new Rhombus();
                        rhombus.DimA = Convert.ToDouble(sizesArray[0].Trim());
                        rhombus.DimH = Convert.ToDouble(sizesArray[1].Trim());
                        result = Math.Round(rhombus.CalculateArea(), 2);
                        break;
                    case Shapes.Równoległobok:
                        Parallelogram parallelogram = new Parallelogram();
                        parallelogram.DimA = Convert.ToDouble(sizesArray[0].Trim());
                        parallelogram.DimH = Convert.ToDouble(sizesArray[1].Trim());
                        result = Math.Round(parallelogram.CalculateArea(), 2);
                        break;
                    case Shapes.Trapez:
                        Trapezoid trapezoid = new Trapezoid();
                        trapezoid.DimA = Convert.ToDouble(sizesArray[0].Trim());
                        trapezoid.DimB = Convert.ToDouble(sizesArray[1].Trim());
                        trapezoid.DimH = Convert.ToDouble(sizesArray[2].Trim());
                        result = Math.Round(trapezoid.CalculateArea(), 2);
                        break;
                    case Shapes.Trójkąt:
                        Triangle triangle = new Triangle();
                        triangle.DimA = Convert.ToDouble(sizesArray[0].Trim());
                        triangle.DimH = Convert.ToDouble(sizesArray[1].Trim());
                        result = Math.Round(triangle.CalculateArea(), 2);
                        break;
                }

                formData.ResultNotification = string.Format("Pole powierzchni figury {0} dla podanych wymiarów wynosi: {1}.", formData.Shape, result);
            
            }
            catch (NullReferenceException)
            {
                formData.ResultNotification = "Podaj wymiary figury";
            }
            catch (FormatException)
            {
                formData.ResultNotification = "Podaj prawidłowe dane";
            }
            catch (IndexOutOfRangeException)
            {
                formData.ResultNotification = "Podaj wszystkie wymagane wymiary w formacie podanym w instrukcji";
            }
            
            return View(formData);
        }
    }
}
