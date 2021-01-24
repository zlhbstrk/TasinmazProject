using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tasinmaz.Entities
{
    public class Tasinmaz
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int IlID { get; set; }
        public int IlceID { get; set; }
        public int MahalleID { get; set; }

        [Required(ErrorMessage="Ada alanı boş geçilemez!")]
        public int Ada { get; set; }

        [Required(ErrorMessage="Parsel alanı boş geçilemez!")]
        public int Parsel { get; set; }

        [Required(ErrorMessage="Nitelik alanı boş geçilemez!")]
        public string Nitelik { get; set; }

        [Required(ErrorMessage="Adres alanı boş geçilemez!")]
        public string Adres { get; set; }
    }
}