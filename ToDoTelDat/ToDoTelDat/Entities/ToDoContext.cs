using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace ToDoTelDat.Entities
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDo> ToDoes { get; set; }

        public DbSet<User> Users { get; set; }

        public ToDoContext(DbContextOptions options) : base(options)
        {
        }
    }
}
