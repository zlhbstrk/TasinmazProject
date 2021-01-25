using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tasinmaz.Entities
{
    public class Mahalle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int IlceID { get; set; }
        
        [MaxLength(30)]
        [Required(ErrorMessage="Ad alanı boş geçilemez!")]
        public string Ad { get; set; }
    }
}