using Microsoft.AspNetCore.Identity;

namespace Cofee.Models
{
    /// <summary>
    /// Модель DTO описыающая пользователя системы. Наслеуется от IdentityUser
    /// </summary>
    public class User : IdentityUser
    {
        public User(DateTime created)
        {
            Created = created;
        }

        public DateTime Created { get; set; }
    }
}
