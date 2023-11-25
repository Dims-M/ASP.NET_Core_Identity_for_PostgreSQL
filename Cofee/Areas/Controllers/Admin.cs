using Microsoft.AspNetCore.Mvc;

namespace Cofee.Areas.Controllers
{
    public class Admin : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
