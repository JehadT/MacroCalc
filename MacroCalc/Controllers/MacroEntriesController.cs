using MacroCalc.Data;
using MacroCalc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MacroCalc.Controllers
{
    public class MacroEntriesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MacroEntriesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Entry()
        {
            var macroEntry = _db.MacroEntries.OrderByDescending(m => m.Id).FirstOrDefault();
            return View(macroEntry);
        }

        [HttpPost]
        public IActionResult Entry(MacroEntry obj)
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

            return RedirectToAction("Entry");
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
            return RedirectToAction("Entry");
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
            return RedirectToAction("Entry", "MacroEntries");
        }
        public IActionResult History()
        {
            return View();
        }
    }
}
