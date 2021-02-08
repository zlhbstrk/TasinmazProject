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
                entity.HasIndex(e => e.Ad).IsUnique();
            });

            builder.Entity<Ilce>(entity =>
            {
                entity.HasIndex(e => e.Ad).IsUnique();
            });

            builder.Entity<Mahalle>(entity =>
            {
                entity.HasIndex(e => e.Ad).IsUnique();
            });

            // builder.Entity<Kullanici>(entity =>
            // {
            //     entity.HasIndex(e => e.Email).IsUnique();
            // });

            builder.Entity<Kullanici>().HasAlternateKey(k => k.Email).HasName("AlternatifEmail");

            builder.Entity<ETasinmaz>(entity =>
            {
                entity.HasIndex(e => new {e.Ada, e.Parsel}).IsUnique();
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