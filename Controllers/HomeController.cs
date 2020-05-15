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
            FormData form = new FormData().ChosenFigure = null;
            return View(new FormData());
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
        public ActionResult Index(FormData formData)
        {
            string sizes = formData.Sizes;
            double result = 0;

            switch (formData.ChosenFigure)
            {
                case Shapes.Kwadrat:
                    Square sq = new Square();
                    sq.a = Convert.ToDouble(sizes.Trim());
                    result = Math.Round(sq.CalculateArea(sq), 3);
                    break;

              
            }
            formData.Area = "Pole wynosi: "+ result;
            
            return View(formData);
        }
    }
}
