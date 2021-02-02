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

        [Required(ErrorMessage="Ada alanı boş geçilemez!")]
        public int Ada { get; set; }

        [Required(ErrorMessage="Parsel alanı boş geçilemez!")]
        public int Parsel { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage="Nitelik alanı boş geçilemez!")]
        public string Nitelik { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage="Adres alanı boş geçilemez!")]
        public string Adres { get; set; }
    }
}