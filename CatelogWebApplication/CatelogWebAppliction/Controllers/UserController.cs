using CatelogWebAppliction.Interfaces;
using CatelogWebAppliction.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatelogWebAppliction.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(User user)
        {
            var responseStatus = await _userService.RegisterUserAsync(user);
            if (!responseStatus)
            {
                return View();
            }
            return RedirectToAction("Login", "User");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            return View();
        }
    }
}
