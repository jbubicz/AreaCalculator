﻿using System;
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
            string sizes = formData.Sizes;
            double result = 0;

            try
            {
                if (formData.Sizes.Contains("."))
                {
                    sizes = formData.Sizes.Replace('.', ',');
                }
                string[] sizesArray = sizes.Split(new Char[] { ';' });


                switch (formData.Shape)
                {
                    case Shapes.Kwadrat:
                        Square sq = new Square();
                        sq.a = Convert.ToDouble(sizesArray[0].Trim());
                        result = Math.Round(sq.CalculateArea(), 2);
                        break;
                }
                formData.ResultNotification = string.Format("Pole powierzchni wybranej figury {0} wynosi: {1}", formData.Shape, result);
            
            }
            catch (FormatException)
            {
                formData.ResultNotification = "Podano nieprawidłowe dane";
            }
            catch (NullReferenceException)
            {
                formData.ResultNotification = "Należy podać wymiary";
            }
            catch (IndexOutOfRangeException)
            {
                formData.ResultNotification = "Należy podać wszystkie wymagane wymiary oddzielone ;";
            }
            
            return View(formData);
        }
    }
}
