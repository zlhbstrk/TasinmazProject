using Microsoft.EntityFrameworkCore;

namespace Tasinmaz.Entities
{
    public class DefaultContext : DbContext

    {
        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
        {

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