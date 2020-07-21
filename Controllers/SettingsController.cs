using Member.Factories;
using Member.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Member.Controllers
{
    #region snippet
    public class SettingsController : Controller
    {
        private readonly SampleWebSettings _settings;
        public static SampleWebSettings GlobalSettings = new SampleWebSettings() { BUCode = "BETWAY", ProjectFlag = 1 };
        public SettingsController(IOptions<SampleWebSettings> settingsOptions)
        {
            _settings = settingsOptions.Value;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = _settings.Title;
            ViewData["Updates"] = _settings.Updates;
            return View(GlobalSettings);
        }

        [HttpPost]
        public IActionResult ConfigureServices(SampleWebSettings settings)
        {
            GlobalSettings = settings;
            return View("Index");
        }


    }
    #endregion
}