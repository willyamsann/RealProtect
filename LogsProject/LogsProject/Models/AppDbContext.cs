using System.Data.Entity;

namespace LogsProject.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("LogContext")
        { }
        public DbSet<Log> LogsProject { get; set; }
    }
}