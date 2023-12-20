using Cofee.Data;
using Cofee.Models.Entities;
using Cofee.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Diagnostics;
using System.Net.Http;

namespace Cofee.Controllers.APIControllers
{
    /// <summary>
    /// Проверка работоспособности сервиса
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {

        private ApplicationDbContext _applicationDbContext;
        private readonly NewsRepository _newsRepository;
        private readonly ILogger<HealthCheckController> _logger;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IHttpClientFactory _httpClientFactory;


        public HealthCheckController(ILogger<HealthCheckController> logger,
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
        /// Проверка работы БД
        /// </summary>
        [HttpGet]
        [Route("HealthCheckBD")]
        public async Task<HealthCheckResult> HealthCheckBD(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Проверка работоспособности сервиса. Подключение к БД");
            long responseTime = default;

            try
            { // получаем время запроса
                Stopwatch sw = Stopwatch.StartNew();
                //await httpClient.GetAsync("https://localhost:33333/data");

                int degraded_level = 3000;  // уровень плохой работы
                int unhealthy_level = 7000; // нерабочий уровень

                bool CheckBDConnect = _applicationDbContext.Database.CanConnect();
               
                if (CheckBDConnect)
                {
                    _logger.LogInformation("Успешное подключение к БД. Даза данных подключена и доступна");
                    _logger.LogInformation("Проверка получения данных");

                   var CheckBD = await _applicationDbContext.News.FirstAsync();

                    sw.Stop();

                    responseTime = sw.ElapsedMilliseconds;
                    // в зависимости от времени запроса возвращаем определенный результат
                    if (responseTime < degraded_level)
                    {
                        return HealthCheckResult.Healthy($"Система функционирует хорошо. Запрос обработался за {responseTime} ");
                    }
                    else if (responseTime < unhealthy_level)
                    {
                        return HealthCheckResult.Degraded($"Снижение качества работы системы Запрос обработался за {responseTime} ");
                    }
                    else
                    {
                        return HealthCheckResult.Unhealthy($"Система в нерабочем состоянии. Необходим ее перезапуск. Запрос обработался за {responseTime} ");
                    }
                    //return HealthCheckResult.Healthy("Система функционирует хорошо");
                }

                
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Degraded(exception: ex);
            }

            return HealthCheckResult.Healthy($"Неполадки в системе Запрос обработался за {responseTime} "); ;
        }

    }
}
