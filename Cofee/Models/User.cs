using Microsoft.AspNetCore.Identity;

namespace Cofee.Models
{
    /// <summary>
    /// Модель DTO описыающая пользователя системы. Наслеуется от IdentityUser
    /// </summary>
    public class User : IdentityUser
    {
        public DateTime Created { get; set; }
    }
}
