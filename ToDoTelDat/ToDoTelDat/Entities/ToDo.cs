namespace ToDoTelDat.Entities
{
    public class ToDo
    {
        public string TaskName { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime StartDate { get; set; } = new();

        public DateTime EndDate { get; set; } = new();

    }
}
