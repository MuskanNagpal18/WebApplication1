using System.Data.Entity;

namespace WebApplication1.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<User> Users { get; set; }

        // 👉 ADD THIS
        public DbSet<Medicine> Medicines { get; set; }
    }
}
