using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tasinmaz.Entities
{
    public class Il
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [MaxLength(30)]
        [Required(ErrorMessage="Ad alanı boş geçilemez!")]
        public string Ad { get; set; }
        public int Plaka { get; set; }

        public ICollection<Ilce> tblIlce {get; set; }
        public ICollection<ETasinmaz> tblTasinmaz {get; set; }
    }
}