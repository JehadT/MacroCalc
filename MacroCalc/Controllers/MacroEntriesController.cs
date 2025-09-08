using MacroCalc.Data;
using MacroCalc.Models;
using Microsoft.AspNetCore.Mvc;

namespace MacroCalc.Controllers
{
    public class MacroEntriesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MacroEntriesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult EditEntry()
        {
            var macroEntry = _db.MacroEntries.OrderByDescending(m => m.Id).FirstOrDefault();
            return View(macroEntry);
        }
        [HttpPost]
        public IActionResult EditEntry(MacroEntry obj)
        {
            var existingEntry = _db.MacroEntries.FirstOrDefault(m => m.Id == obj.Id);

            if (existingEntry == null)
            {
                return NotFound();
            }

            existingEntry.Fat = obj.Fat;
            existingEntry.Carb = obj.Carb;
            existingEntry.Protein = obj.Protein;

            existingEntry.CalculateCalorie();

            _db.MacroEntries.Update(existingEntry);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult History()
        {
            return View();
        }
    }
}
