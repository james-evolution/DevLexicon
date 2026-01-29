using System.Diagnostics;
using DevLexicon.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevLexicon.Controllers
{
    public class HomeController : Controller
    {
        // Renders the application landing page with an overview of the app.
        public IActionResult Index()
        {
            return View();
        }

        // Renders an error view with diagnostic information for troubleshooting.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
