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

        public DbSet<Kullanici> tblKullanici { get; set; }
        public DbSet<Il> tblIl {get; set; }
        public DbSet<Ilce> tblIlce {get; set; }
        public DbSet<Mahalle> tblMahalle { get; set; }
        public DbSet<Tasinmaz> tblTasinmaz { get; set; }
        public DbSet<IslemTip> tblIslemTip {get; set; }
        public DbSet<Durum> tblDurum { get; set; }
        public DbSet<Log> tblLog {get; set; }
    }
}