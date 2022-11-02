using Microsoft.EntityFrameworkCore;

namespace DSM.SalesData.WebApi.Data;

public class SalesDbContext : DbContext
{
    public SalesDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SalesData>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.LookupId)
            .IsRequired()
            .HasMaxLength(64);

            entity
            .HasIndex(entity => entity.LookupId)
            .IsUnique();

            entity.Property(e => e.TotalRevenue)
            .IsRequired();

            entity.Property(e => e.UnitsSold)
            .IsRequired();
        });
    }

    //entities
    public DbSet<SalesData> SalesData => Set<SalesData>();
}