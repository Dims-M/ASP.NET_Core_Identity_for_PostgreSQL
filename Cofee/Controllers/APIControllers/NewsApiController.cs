using Cofee.Data;
using Cofee.Models.Entities;
using Cofee.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cofee.Controllers.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsApiController : ControllerBase
    {
        private ApplicationDbContext _applicationDbContext;
        private readonly NewsRepository _newsRepository;
        private readonly ILogger<NewsApiController> _logger;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IHttpClientFactory _httpClientFactory;


        public NewsApiController(ILogger<NewsApiController> logger,
            ApplicationDbContext applicationDbContext,
            IHttpContextAccessor httpContext,
            IHttpClientFactory httpClientFactory,
            NewsRepository newsRepository)
        {
            _applicationDbContext = applicationDbContext;
            _newsRepository = newsRepository;
            _logger = logger;
            _httpContext = httpContext;
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Получение новостей по ID
        /// </summary>
        /// <param name="id">Id новости</param>
        /// <returns>Найденая данные</returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [HttpGet]
        [Route("GetNewsId")]
        //[FeatureGroupName("Categories")]
        public async Task<News> GetNewsId(int id)
        {
            _logger.LogInformation("Запрос новостей");
            var news = await _newsRepository.GetOpenNewsAsync();
            var newsId = await _newsRepository.GetNewsIdAsync(id);

            if (newsId!=null)
            {
                return newsId;
            }
            return null;
        }


        /// <summary>
        /// Получение новостей
        /// </summary>
        /// <param name="countNews">Количество новостей</param>
        /// <returns>Найденая данные</returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [HttpGet]
        [Route("GetAllNews")]
        //[FeatureGroupName("Categories")]
        public async Task<ActionResult> GetAllNews(int countNews = 20)
        {
            _logger.LogInformation("Запрос новостей");
            var news = await _newsRepository.GetOpenNewsAsync();
            //var newsId = await _newsRepository.GetNewsIdAsync(id);

            if (news != null)
            {
                return Ok(news);
            }
            return Ok(null);
        }


    }
}
