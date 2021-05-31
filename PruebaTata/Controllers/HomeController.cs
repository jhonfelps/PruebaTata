using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaTata.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTata.Controllers
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
            return View();
        }
        [HttpPost]
        public IActionResult Contarrepetidos(string textoentrada)
        {
            ViewBag.textoentrada = textoentrada;
            ViewBag.repeticiones = 0;
            string[] strings = System.Text.RegularExpressions.Regex.Split(textoentrada, @"\W|_");


            List<ContadordePalabras> ContadordePalabras = new List<ContadordePalabras>();
            foreach (var w in strings)
            {
                ContadordePalabras PalabraEncontrada = ContadordePalabras.Find(x => x.palabra == w.ToString());
                if(PalabraEncontrada == null)
                {
                    // la palabra es nueva
                    ContadordePalabras.Add(new ContadordePalabras(w.ToString(), 1));
                } else
                {
                    // la palabra ya esta en la lista
                    PalabraEncontrada.frecuencia++;
                }
            }

            return View(ContadordePalabras);
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
    }
}
