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
        private DataUserRepository _dataUserRepository;

        public Admin(NewsRepository newsRepository, DataUserRepository dataUserRepository)
        {
            _newsRepository = newsRepository;
            _dataUserRepository = dataUserRepository;
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
        //[Route("/admin/news/createNews")]
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
        //[Route("/admin/news/createNews")]
        [HttpPost]
        public async Task<ActionResult> CreateNews(News news)
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
        public async Task<ActionResult> Users()
        {
            var list = await _dataUserRepository.GetUsersAsync();

            return View(list);
        }

        /// <summary>
        /// Блокировка пользователя.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       // [Route("/admin/users/block/{id}")]
        public async Task<ActionResult> BlockUsers(string id)
        {
            await _dataUserRepository.BlockUsersAsync(id);

            return Redirect("/Admin/Users");
        }

        /// <summary>
        /// Разблокировка пользователя.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       // [Route("/admin/users/unblock/{id}")]
        public async Task<ActionResult> UnBlockUsers(string id)
        {
            await _dataUserRepository.UnBlockUsersAsync(id);

            return Redirect("/Admin/Users");
        }

        //[Route("/admin/news/edit/{id}")]
        [HttpGet]
        public async Task<ActionResult> EditNews(int id)
        {
            var news = await _newsRepository.GetOneNewsAsync(id);

            return View(news);
        }

        /// <summary>
        /// Редактирование новости
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        //[Route("/admin/news/edit/{id}")]
        [HttpPost]
        public async Task<ActionResult> EditNews(News news)
        {
            news.DatePublication = DateTime.SpecifyKind(news.DatePublication, DateTimeKind.Utc);

            var result = await _newsRepository.UpdateNewsAsync(news);

            return Redirect("/Admin/News");
        }

        /// <summary>
        /// Удаление новости
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[Route("/admin/news/delete/{id}")]
        [HttpGet]
        public async Task<ActionResult> DeleteNews(int id)
        {
            await _newsRepository.DeleteNewsAsync(id);

            return Redirect("/Admin/News");
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Страница редактирование
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        /// <summary>
        /// Страница редактирование сохранение отредактированного
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Удаление повости по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        /// <summary>
        /// Удаление обьекта по id  
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}
