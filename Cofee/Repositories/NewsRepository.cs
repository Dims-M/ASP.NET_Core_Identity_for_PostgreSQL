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
        /// Получаем список всех новостей из БД
        /// </summary>
        /// <returns></returns>
        public async Task<List<News>> GetNewsAsync()
        {
            return await _applicationDbContext.News.OrderBy(n=>n.Id).AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Получаем список всех открытых, незабаненых новостей из БД
        /// </summary>
        /// <returns></returns>
        public async Task<List<News>> GetOpenNewsAsync()
        {
            return await _applicationDbContext.News.Where(n=>n.IsDelite!=true & n.IsActive !=false ).OrderBy(n => n.Id).AsNoTracking().ToListAsync();
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


        public async Task<List<News>> GetOnlyActiveNewsAsync()
        {
            return await _applicationDbContext.News.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<News> GetOneNewsAsync(int id)
        {
            return await _applicationDbContext.News.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Создание новостей
        /// </summary>
        /// <param name="news">DTO c формы</param>
        /// <returns></returns>
        public async Task<News> CreateNewsAsync(News news)
        {
            _applicationDbContext.News.Add(news);
            try
            {
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }

            return news;
        }

        public async Task<News> UpdateNewsAsync(News news)
        {
            var item = await _applicationDbContext.News.Where(x => x.Id == news.Id).FirstOrDefaultAsync();

            item.Title = news.Title;
            item.Text = news.Text;
            item.DatePublication = news.DatePublication;
            item.IsActive = news.IsActive;

            await _applicationDbContext.SaveChangesAsync();

            return item;
        }

        public async Task DeleteNewsAsync(int id)
        {
            var item = await _applicationDbContext.News.Where(x => x.Id == id).FirstOrDefaultAsync();

            _applicationDbContext.News.Remove(item);
            await _applicationDbContext.SaveChangesAsync();
        }

    }
}
