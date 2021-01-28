using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tasinmaz.Entities
{
    public class Mahalle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; }

        [ForeignKey("Ilce")]
        public int IlceID { get; }
        public Ilce Ilce { get; set; }
        
        [MaxLength(30)]
        [Required(ErrorMessage="Ad alanı boş geçilemez!")]
        public string Ad { get; set; }

        public ICollection<ETasinmaz> tblTasinmaz {get; set; }
    }
}