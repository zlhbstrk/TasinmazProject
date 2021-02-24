using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tasinmaz.Entities
{
    public class Il
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(30)]
        [Required(ErrorMessage = "Ad alanı boş geçilemez!")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Plaka alanı boş geçilemez!")]
        public int Plaka { get; set; }
        public bool AktifMi { get; set; }
    }
}