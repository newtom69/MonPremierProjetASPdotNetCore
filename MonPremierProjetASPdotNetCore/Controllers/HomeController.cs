using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MonPremierProjetASPdotNetCore.DAL;
using MonPremierProjetASPdotNetCore.Models;

namespace MonPremierProjetASPdotNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ArticlesDAL articlesDAL = new ArticlesDAL();
            List<Article> articles = articlesDAL.ListerTout(50);
            return View(articles);
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
