using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cofee.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class Admin : Controller
    {
        public IActionResult Index()
        {
            var user = User.Identity;
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }
    }
}
