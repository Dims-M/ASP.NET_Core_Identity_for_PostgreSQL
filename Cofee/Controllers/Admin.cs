using Cofee.Models.Entities;
using Cofee.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            var listNews = _newsRepository.GetNewsAsync().Result;
            return View(listNews);
        }

        /// <summary>
        /// Создание новости
        /// </summary>
        /// <returns></returns>
        [Route("/admin/news/createNews")]
        [HttpGet]
        public async Task<ActionResult> CreateNews()
        {
            return View();
        }

        /// <summary>
        /// Создание новости
        /// </summary>
        /// <param name="news">Обьект DTO с формы</param>
        /// <returns></returns>
        [Route("/admin/news/createNews")]
        [HttpPost]
        public async Task<ActionResult> Create(News news)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!string.IsNullOrEmpty(userId))
            {
                news.AuthorId = userId;

                news.DatePublication = DateTime.SpecifyKind(news.DatePublication, DateTimeKind.Utc);

                var result = await _newsRepository.CreateNewsAsync(news);
            }

            return Redirect("/Admin/News");
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
