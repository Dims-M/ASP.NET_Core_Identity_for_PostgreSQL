using Microsoft.AspNetCore.Identity;

namespace Cofee.Models
{
    /// <summary>
    /// Модель DTO описыающая пользователя системы.
    /// </summary>
    public class User : IdentityUser
    {
        public DateTime Created { get; set; }
    }
}
