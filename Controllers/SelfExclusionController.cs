using Member.Interfaces;
using Member.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using Member.Factories;
using Member.Services;
using System.Linq;

namespace Member.Controllers
{
    public class SelfExclusionController : Controller
    {
        private readonly SelfExclusionServiceBase _selfExclusionService;
        public SelfExclusionController()
        {
            _selfExclusionService = MemberFactory.GetRequiredService<SelfExclusionServiceBase>();
        }

        public IActionResult Index()
        {
            var member = new Models.UserModel()
            {
                Username = "Test"
            };
            return View(member);
        }


        [HttpPost]
        public IActionResult CheckSelfExclusion(UserModel usermodel)
        {
            ViewBag.Message = "Has self-exclusion = " + _selfExclusionService.CheckHasSelfExclusion(usermodel.Username);
            return View("Index");
        }

        /// <summary>
        /// Create Self-exclusion.
        /// </summary>
        /// <param name="userName">Username.</param>
        [HttpPost]
        public IActionResult CreateSelfExclusion(UserModel usermodel)
        {
            ViewBag.Message = _selfExclusionService.CreateSelfExclusion(usermodel.Username);
            return View("Index");
        }
    }
}
