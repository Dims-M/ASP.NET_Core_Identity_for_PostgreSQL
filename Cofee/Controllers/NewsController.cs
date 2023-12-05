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
        private readonly ILogger<NewsController> _logger;

        /// <summary>
        /// Контролер работы с новостями
        /// </summary>
        public NewsController(ILogger<NewsController> logger, ApplicationDbContext applicationDbContext, NewsRepository newsRepository)
        {
            _applicationDbContext = applicationDbContext;
            _newsRepository = newsRepository;
            _logger = logger;
        }
       
        public async Task<IActionResult> Index()
        {
            
           _logger.LogInformation("Запрос новостей");
            var news = await _newsRepository.GetOpenNewsAsync();
            
            return View(news);
        }
    }
}
