using Cofee.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cofee.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class Admin : Controller
    {
        private readonly NewsRepository _newsRepository;

       public Admin(NewsRepository newsRepository)
        {
           _newsRepository = newsRepository;
        }

        public IActionResult Index()
        {
            var user = User.Identity;
            var userRole = User.IsInRole("Administrator");
            return View();
        }

        /// <summary>
        /// Получаем все новости
        /// </summary>
        /// <returns></returns>
        public IActionResult News()
        {
            var listNews = _newsRepository.GetNewsAsync();
            return View();
        }


        /// <summary>
        /// Получаем всех пользователей
        /// </summary>
        /// <returns></returns>
        public IActionResult Users()
        {
            var listUser = new List<string>();
            return View();
        }
    }
}
