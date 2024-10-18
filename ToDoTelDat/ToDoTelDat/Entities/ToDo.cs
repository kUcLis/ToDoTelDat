using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoTelDat.Entities
{
    public class ToDo
    {
        public int ToDoId { get; set; }

        [MaxLength(100)]
        [MinLength(3)]
        public string TaskName { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime StartDate { get; set; } = new();

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User? User { get; set; } = null!;

    }
}
