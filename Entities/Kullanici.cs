using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tasinmaz.Helpers;

namespace Tasinmaz.Entities
{
    public class Kullanici
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //1'den başlar ve birer birer artar
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail alanı boş geçilemez!")]
        public string Email { get; set; }

        [Required(ErrorMessage="Yetki alanı boş geçilemez!")]
        public YetkiTipi Yetki { get; set; } // Enum Kullanılıyor.

        [MinLength(8)]
        [Required(ErrorMessage="Şifre alanı boş geçilemez!")]
        public string Sifre { get; set; }

        [MaxLength(30)]
        public string Ad { get; set; }

        [MaxLength(30)]
        public string Soyad { get; set; }
        public bool AktifMi { get; set; }

        public ICollection<Log> tblLog {get; set; }
    }
}