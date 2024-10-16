using System.ComponentModel.DataAnnotations;

namespace ToDoTelDat.Entities
{
    public class User
    {
        public int UserId { get; set; }
        [MaxLength(30)]
        public string UserName { get; set; } = null!;
    }
}
