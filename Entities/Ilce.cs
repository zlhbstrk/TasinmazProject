using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tasinmaz.Entities
{
    public class Ilce
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("Il")]
        public int IlID { get; set; }
        public Il Il { get; set; } //Navigation Property

        [MaxLength(30)]
        [Required(ErrorMessage="Ad alanı boş geçilemez!")]
        public string Ad { get; set; }

        public ICollection<Mahalle> tblMahalle {get; set; }
        public ICollection<ETasinmaz> tblTasinmaz {get; set; }
    }
}