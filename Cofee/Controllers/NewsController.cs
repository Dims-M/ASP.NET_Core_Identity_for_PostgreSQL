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
        private readonly IHttpContextAccessor _httpContext;

        /// <summary>
        /// Контролер работы с новостями
        /// </summary>
        public NewsController(ILogger<NewsController> logger,
            ApplicationDbContext applicationDbContext,
            IHttpContextAccessor httpContext,
            NewsRepository newsRepository)
        {
            _applicationDbContext = applicationDbContext;
            _newsRepository = newsRepository;
            _logger = logger;
            _httpContext = httpContext;
        }
       
        public async Task<IActionResult> Index()
        {
            
           _logger.LogInformation("Запрос новостей");
            var news = await _newsRepository.GetOpenNewsAsync();
            
            return View(news);
        }
    }
}
