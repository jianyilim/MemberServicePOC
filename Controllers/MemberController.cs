using Member.Interfaces;
using Member.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using Member.Factories;
using Member.Services;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Member.Controllers
{
    public class MemberController : Controller
    {
        private readonly MemberServiceBase _memberService;
        private readonly MemberFactory _memberFactory;

        public MemberController()
        {
            _memberFactory = MemberFactory.CreateMemberFactory();
            _memberService = _memberFactory.CreateMemberService();
        }

        public IActionResult Index()
        {
            var member = new Models.UserModel()
            {
                Username = "Test"
            };
            return View(member);
        }
        /// <summary>
        /// Register new member.
        /// </summary>
        /// <param name="memberService">Member service from services.</param>
        /// <param name="usermodel">User model from view.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult RegisterNewMember(UserModel usermodel)
        {
            var hc = _memberService.GetHashCode();
            var message = "";
            _memberService.RegisterNewMember(usermodel, out message);
            ViewBag.Message = hc.ToString() + message;
            return View("Index");
        }

        /// <summary>
        /// Update member detail.
        /// </summary>
        /// <param name="memberService">Member service from services.</param>
        /// <param name="usermodel">User model from view.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateMember(UserModel usermodel)
        {
            string result = "";
            _memberService.UpdateMember(usermodel, out result);
            ViewBag.Message = result;
            return View("Index");
        }


        /// <summary>
        /// User login.
        /// </summary>
        /// <param name="userName">Username.</param>
        /// <param name="password">Password.</param>
        /// <returns>True if login successful.</returns>
        [HttpPost]
        public IActionResult Login( UserModel usermodel)
        {
            usermodel = _memberService.Login(usermodel);
            if (usermodel is null)
                ViewBag.Message = "Login failed!";
            return View("Index", usermodel);
        }
    }
}
