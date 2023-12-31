﻿using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Diagnostics;

namespace Cofee.Service
{
    /// <summary>
    /// Проверки работоспособности вненшнего(или внутреннего) сервиса Api
    /// </summary>
    public class RequestTimeHealthCheck : IHealthCheck
    {
        int degraded_level = 2000;  // уровень плохой работы
        int unhealthy_level = 5000; // нерабочий уровень
        HttpClient httpClient;
        public RequestTimeHealthCheck(HttpClient client) => httpClient = client;
       
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            // получаем время запроса
            Stopwatch sw = Stopwatch.StartNew();
            await httpClient.GetAsync("https://localhost:33333/data");
            sw.Stop();

            var responseTime = sw.ElapsedMilliseconds;
            // в зависимости от времени запроса возвращаем определенный результат
            if (responseTime < degraded_level)
            {
                return HealthCheckResult.Healthy("Система функционирует хорошо");
            }
            else if (responseTime < unhealthy_level)
            {
                return HealthCheckResult.Degraded("Снижение качества работы системы");
            }
            else
            {
                return HealthCheckResult.Unhealthy("Система в нерабочем состоянии. Необходим ее перезапуск.");
            }
        }
    }
}
