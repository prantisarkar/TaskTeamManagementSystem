using TaskManagement.Domain;

namespace TaskManagement.DAL;

using Microsoft.EntityFrameworkCore;

public class TaskDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<TaskInfo> TaskInfos { get; set; }

    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed Default Users
        modelBuilder.Entity<User>().HasData(
            new User { FullName = "Admin", Email = "admin@demo.com", Role = "Admin" },
            new User { FullName = "Manager", Email = "manager@demo.com", Role = "Manager" },
            new User { FullName = "Employee", Email = "employee@demo.com", Role = "Employee" }
        );
    }
}