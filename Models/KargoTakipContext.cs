using Microsoft.EntityFrameworkCore;

namespace KargoTakibi.Models
{
    public class KargoTakipContext : DbContext
    {
        public KargoTakipContext(DbContextOptions<KargoTakipContext> options)
            : base(options)
        {
        }

        public DbSet<Kullanici> Kullanicilar { get; set; } = null!;
        public DbSet<Kargo> Kargolar { get; set; } = null!;
        public DbSet<Hareket> Hareketler { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Kargo>()
                .HasOne(k => k.Kullanici)
                .WithMany(u => u.Kargolar)
                .HasForeignKey(k => k.KullaniciID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Hareket>()
                .HasOne(h => h.Kargo)
                .WithMany(k => k.Hareketler)
                .HasForeignKey(h => h.KargoID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
