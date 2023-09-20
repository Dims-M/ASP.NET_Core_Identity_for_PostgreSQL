namespace MVC.Models
{
    /// <summary>
    /// Описание пользователя в системе.
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsMarried { get; set; }
    }
}
