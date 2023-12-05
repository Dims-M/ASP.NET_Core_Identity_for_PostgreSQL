using Cofee.Data;
using Cofee.Models.Entities;
using Cofee.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Cofee.Controllers
{
    /// <summary>
    /// Контролер работы с новостями
    /// </summary>
    public class NewsController : Controller
    {
        private ApplicationDbContext _applicationDbContext;
        private readonly NewsRepository _newsRepository;

        /// <summary>
        /// Контролер работы с новостями
        /// </summary>
        public NewsController(ApplicationDbContext applicationDbContext, NewsRepository newsRepository)
        {
            _applicationDbContext = applicationDbContext;
            _newsRepository = newsRepository;
        }

        public IActionResult Index()
        {
            var news = _newsRepository.GetOpenNewsAsync().Result;
            return View(news);
        }
    }
}
