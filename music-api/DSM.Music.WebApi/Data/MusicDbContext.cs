using Microsoft.EntityFrameworkCore;

namespace DSM.Music.WebApi.Data;

public class MusicDbContext : DbContext
{
    public MusicDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artist>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.LookupId)
            .IsRequired()
            .HasMaxLength(64);

            entity.HasIndex(e => e.LookupId)
                .IsUnique();

            entity.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(255);

            entity.Property(x => x.Genre)
            .IsRequired()
            .HasMaxLength(255);

            entity.Property(e => e.ThumbnailUrl)
            .IsRequired()
            .HasMaxLength(1024);

            entity.HasMany(artist => artist.Albums)
            .WithOne(x => x.Artist)
            .HasForeignKey(x => x.ArtistId)
            .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Album>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.LookupId)
            .IsRequired()
            .HasMaxLength(64);

            entity.HasIndex(e => e.LookupId)
                .IsUnique();

            entity.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(255);

            entity.Property(e => e.SalesId)
            .IsRequired()
            .HasMaxLength(64);

            entity.Property(e => e.ThumbnailUrl)
            .IsRequired()
            .HasMaxLength(1024);
        });
    }

    //entities
    public DbSet<Artist> Artists => Set<Artist>();
    public DbSet<Album> Albums => Set<Album>();
}