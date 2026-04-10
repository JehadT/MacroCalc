using MacroCalc.Application.Dtos.MacroEntry.In;
using MacroCalc.Application.Interfaces;
using MacroCalc.ViewModels;
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
            var macroEntryViewModel = await GetMacroEntryViewModel();
            if (macroEntryViewModel is null)
                return Unauthorized();
            return View(macroEntryViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Entry(MacroEntryViewModel macroEntryViewModel)
        {
            var macroEntryDto = macroEntryViewModel.CreateEntry;
            await _macroEntriesService.UpdateByAddingMacroEntries(macroEntryDto);
            return RedirectToAction("Entry");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewDay()
        {
            var userId = _userManager.GetUserId(User);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var macroEntryDto = await _macroEntriesService.AddMacroEntry(userId);
            return Json(macroEntryDto.Id);
        }

        [HttpGet]
        public async Task<IActionResult> EditEntry()
        {
            var macroEntryViewModel = await GetMacroEntryViewModel();
            if (macroEntryViewModel is null)
                return Unauthorized();
            return View(macroEntryViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEntry(MacroEntryViewModel macroEntryViewModel)
        {
            var macroEntryDto = macroEntryViewModel.CreateEntry;
            await _macroEntriesService.UpdateByReplacingMacroEntries(macroEntryDto);
            return RedirectToAction("Entry", "MacroEntries");
        }

        public IActionResult History()
        {
            return View();
        }

        // Helper Methods
        private async Task<MacroEntryViewModel?> GetMacroEntryViewModel()
        {
            var userId = _userManager.GetUserId(User);
            if (string.IsNullOrEmpty(userId))
                return null;

            var macroEntryDto = await _macroEntriesService.GetSingleMacroEntry(userId);

            return new MacroEntryViewModel
            {
                ReadEntry = macroEntryDto,
                CreateEntry = new MacroEntryIn()
            };
        }
    }
}
