using MacroCalc.Models;
using MacroCalc.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MacroCalc.Controllers
{
    [Authorize]
    public class MacroEntriesController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMacroEntriesService _macroEntriesService;

        public MacroEntriesController(
            UserManager<IdentityUser> userManager, IMacroEntriesService macroEntriesService
        )
        {
            _macroEntriesService = macroEntriesService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Entry()
        {
            var userId = _userManager.GetUserId(User);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var macroEntry = await _macroEntriesService.GetAsyncByUserId(userId);
            return View(macroEntry);
        }

        [HttpPost]
        public async Task<IActionResult> Entry(MacroEntry obj)
        {
            await _macroEntriesService.UpdateByAddingAsync(obj);
            return RedirectToAction("Entry");
        }

        [HttpPost]
        public async Task<IActionResult> NewDay()
        {
            var userId = _userManager.GetUserId(User);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            await _macroEntriesService.AddAsync(userId);
            return RedirectToAction("Entry");
        }

        [HttpGet]
        public async Task<IActionResult> EditEntry()
        {
            var userId = _userManager.GetUserId(User);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var macroEntry = await _macroEntriesService.GetAsyncByUserId(userId);
            return View(macroEntry);
        }

        [HttpPost]
        public async Task<IActionResult> EditEntry(MacroEntry obj)
        {
            await _macroEntriesService.UpdateByReplacingAsync(obj);
            return RedirectToAction("Entry", "MacroEntries");
        }

        public IActionResult History()
        {
            return View();
        }
    }
}
