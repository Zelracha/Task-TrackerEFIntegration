using Microsoft.EntityFrameworkCore;
using Task = TTracker.Models.Task;
namespace TTracker.Data
{
   
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Task> Tasks { get; set; }
    }
}
