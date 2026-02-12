using System;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("ApplicationDbContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserMedicine> UserMedicines { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
    }
}