using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tasinmaz.Entities
{
    public class ETasinmaz
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Il")]
        public int IlId { get; set; }
        public Il Il { get; set; }

        [ForeignKey("Ilce")]
        public int IlceId { get; set; }
        public Ilce Ilce { get; set; }

        [ForeignKey("Mahalle")]
        public int MahalleId { get; set; }
        public Mahalle Mahalle { get; set; }

        [MaxLength(10)]
        [Required(ErrorMessage="Ada alanı boş geçilemez!")]
        public string Ada { get; set; }

        [MaxLength(10)]
        [Required(ErrorMessage="Parsel alanı boş geçilemez!")]
        public string Parsel { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage="Nitelik alanı boş geçilemez!")]
        public string Nitelik { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage="Adres alanı boş geçilemez!")]
        public string Adres { get; set; }

        [ForeignKey("Kullanici")]
        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }
        public bool AktifMi { get; set; }
    }
}