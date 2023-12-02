using System.ComponentModel.DataAnnotations.Schema;

namespace Cofee.Models.Entities
{
    /// <summary>
    /// DTO Модель описывающая новость
    /// </summary>
    public class News
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// ID  автора
        /// </summary>
        public string? AuthorId { get; set; }

        /// <summary>
        /// Автор новости из таблички AspNetUsers
        /// </summary>
        public User Author { get; set; }

        /// <summary>
        /// Заголовок
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Тескт новости
        /// </summary>
        public string? Text { get; set; }

        /// <summary>
        /// Коментарии к новости.
        /// </summary>
        public string? Сomments { get; set; }

        /// <summary>
        /// Теги новости
        /// </summary>
        public string? Tags { get; set; }

        /// <summary>
        /// Сылки но внещние сайти
        /// </summary>
        public string[]? Urls { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Дата публикации
        /// </summary>
        public DateTime DatePublication { get; set; }

        /// <summary>
        /// Дата обновлления
        /// </summary>
        public DateTime DateUpdate { get; set; }

        /// <summary>
        /// Являетсяли новость активной(опубликованной)
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Являтся ли удаленным
        /// </summary>
        public bool IsDelite { get; set; }


    }
}
