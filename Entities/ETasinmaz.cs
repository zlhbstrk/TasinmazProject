using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tasinmaz.Entities
{
    public class ETasinmaz
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get;}

        [ForeignKey("Il")]
        public int IlID { get; }
        public Il Il { get; set; }

        [ForeignKey("Ilce")]
        public int IlceID { get;}
        public Ilce Ilce { get; set; }

        [ForeignKey("Mahalle")]
        public int MahalleID { get; }
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