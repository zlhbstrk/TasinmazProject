using Microsoft.EntityFrameworkCore;

namespace Tasinmaz.Entities
{
    public class DefaultDbContext : DbContext

    {
        public DefaultDbContext()
        {

        }

        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=msn.msn123;Database=dbTasinmaz;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Il>(entity =>
            {
                entity.HasIndex(e => new { e.Ad, e.Plaka }).IsUnique();
            });

            builder.Entity<Ilce>(entity =>
            {
                entity.HasIndex(e => new { e.Ad, e.IlId }).IsUnique();
            });

            builder.Entity<Mahalle>(entity =>
            {
                entity.HasIndex(e => new { e.Ad, e.IlceId }).IsUnique();
            });

            builder.Entity<Kullanici>().HasAlternateKey(k => k.Email);

            builder.Entity<ETasinmaz>(entity =>
            {
                entity.HasIndex(e => new { e.Ada, e.Parsel, e.Nitelik, e.IlId, e.IlceId, e.MahalleId }).IsUnique();
            });
        }

        public DbSet<Kullanici> tblKullanici { get; set; }
        public DbSet<Il> tblIl { get; set; }
        public DbSet<Ilce> tblIlce { get; set; }
        public DbSet<Mahalle> tblMahalle { get; set; }
        public DbSet<ETasinmaz> tblTasinmaz { get; set; }
        public DbSet<IslemTip> tblIslemTip { get; set; }
        public DbSet<Durum> tblDurum { get; set; }
        public DbSet<Log> tblLog { get; set; }
    }
}