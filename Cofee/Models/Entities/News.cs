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

        public string Title { get; set; }

        public string Text { get; set; }
        /// <summary>
        /// Коментарии к новости.
        /// </summary>
        public string Сomments { get; set; }
        public string Tags { get; set; }

        public DateTime Date { get; set; }

        public string AuthorId { get; set; }
        public User Author { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsActive { get; set; }

        /// <summary>
        /// Являтся ли удаленным
        /// </summary>
        public bool IsDelite { get; set; }
    }
}
