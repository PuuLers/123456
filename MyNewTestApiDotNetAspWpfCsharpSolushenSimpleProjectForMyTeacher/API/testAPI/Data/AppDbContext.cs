using Microsoft.EntityFrameworkCore;
using testAPI.Models;

namespace testAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Staff> Staff { get; set; }
    public DbSet<Division> Division { get; set; }
    public DbSet<Post> Post { get; set; }
    public DbSet<StaffPostDivision> StaffPostDivision { get; set; }
    public DbSet<Users> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // StaffPostDivision - это представление (view), у него нет ключа
        modelBuilder.Entity<StaffPostDivision>()
            .HasNoKey()
            .ToView("StaffPostDivision");
    }
}
