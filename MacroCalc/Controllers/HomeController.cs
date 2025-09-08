using System.Diagnostics;
using MacroCalc.Data;
using MacroCalc.Models;
using Microsoft.AspNetCore.Mvc;

namespace MacroCalc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var macroEntry = _db.MacroEntries.OrderByDescending(m => m.Id).FirstOrDefault();
            return View(macroEntry);
        }

        [HttpPost]
        public IActionResult Index(MacroEntry obj)
        {
            var existingEntry = _db.MacroEntries.FirstOrDefault(m => m.Id == obj.Id);

            if (existingEntry == null)
            {
                return NotFound();
            }

            existingEntry.Fat += obj.Fat ?? 0;
            existingEntry.Carb += obj.Carb ?? 0;
            existingEntry.Protein += obj.Protein ?? 0;

            existingEntry.CalculateCalorie();

            _db.MacroEntries.Update(existingEntry);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult NewDay()
        {
            MacroEntry entry = new MacroEntry
            {
                Fat = 0,
                Carb = 0,
                Protein = 0,
            };
            _db.MacroEntries.Add(entry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(
                new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                }
            );
        }
    }
}
