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

        /// <summary>
        /// Получаем новость по id
        /// </summary>
        /// <returns></returns>
        public async Task<News> GetNewsIdAsync(int idNews)
        {
            var res = await _applicationDbContext.News.AsNoTracking().AsQueryable().FirstOrDefaultAsync(x => x.Id == idNews);
            return res;
        }

        /// <summary>
        /// Получаем новость по имени
        /// </summary>
        /// <returns></returns>
        public async Task<List<News>> GetNewsNameAsync(string NameNews)
        {
            var res = await _applicationDbContext.News.AsNoTracking().AsQueryable().Where(n => n.Title.Contains(NameNews)).ToListAsync(); ;
            return res;
        }

    }
}
