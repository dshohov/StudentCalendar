using Microsoft.AspNetCore.Mvc;
using StudentCalendarAdmin.IServices;

namespace StudentCalendarAdmin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _userService.GetNotConfirmUsers());
        }
        public async Task<IActionResult> ConfirmUser(string idUser)
        {
            if (await _userService.ConfirmUser(idUser))
                return RedirectToAction("Index","User");
            return RedirectToAction("Error","Home");
        }
    }
}
