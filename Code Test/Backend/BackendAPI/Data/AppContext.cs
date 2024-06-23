using BackendAPI.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<tr_bpkb> tr_bpkb { get; set; }
    public DbSet<ms_storage_location> ms_storage_location { get; set; }
    public DbSet<ms_user> ms_user { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Fluent API configuration if needed
        modelBuilder.Entity<tr_bpkb>()
            .HasOne(b => b.ms_storage_location)
            .WithMany()
            .HasForeignKey(b => b.location_id);
    }
}