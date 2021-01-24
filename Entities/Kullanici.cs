using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tasinmaz.Helpers;

namespace Tasinmaz.Entities
{
    public class Kullanici
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail alanı boş geçilemez!")]
        public string Email { get; set; }

        [Required(ErrorMessage="Yetki alanı boş geçilemez!")]
        public YetkiTipi Yetki { get; set; } // Enum Kullanılıyor

        [Required(ErrorMessage="Şifre alanı boş geçilemez!")]
        public string Sifre { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public bool AktifMi { get; set; }
    }
}