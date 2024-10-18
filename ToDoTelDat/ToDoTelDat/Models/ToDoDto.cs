using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ToDoTelDat.Models
{
    public class ToDoDto
    {
        public int ToDoId { get; set; }
        public string TaskName { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime StartDate { get; set; } = new();
        public int UserId { get; set; }

        public bool IsDisabled {get; set;} = false;
        public bool TurnAlarm {get; set;} = false;
    }
}
