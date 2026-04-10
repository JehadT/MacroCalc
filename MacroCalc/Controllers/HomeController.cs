using MacroCalc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MacroCalc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Error(int? statusCode = null)
        {
            var model = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                StatusCode = statusCode,
                Message = statusCode switch
                {
                    404 => "The page you’re looking for doesn’t exist.",
                    403 => "You don’t have permission to access this page.",
                    _ => "An unexpected error occurred."
                }
            };

            return View("Error", model);
        }
    }
}
