using Microsoft.EntityFrameworkCore;
using TPPProject.Models;

namespace TPPProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }

        public DbSet<BurnoutRisk> BurnoutRisks { get; set; }

        public DbSet<Performance> Performances { get; set; }

        public DbSet<Team> Teams { get; set; }
    }
}
