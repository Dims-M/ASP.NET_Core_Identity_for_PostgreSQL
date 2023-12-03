using Cofee.Data;
using Cofee.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cofee.Repositories
{
    /// <summary>
    /// Манипулирование с новостями, постами в БД
    /// </summary>
    public class NewsRepository
    {
        private ApplicationDbContext _applicationDbContext;

        /// <summary>
        /// Манипулирование с новостями, постами в БД
        /// </summary>
        public NewsRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        /// <summary>
        /// Получаем список новостей
        /// </summary>
        /// <returns></returns>
        public async Task<List<News>> GetNewsAsync()
        {
            return await _applicationDbContext.News.ToListAsync();
        }

    }
}
