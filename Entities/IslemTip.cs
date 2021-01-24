using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tasinmaz.Entities
{
    public class IslemTip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Ad { get; set; } // Dışarıdan İşlemTip tanımlaması olmayacağından DataAnnotations kullanmadım
    }
}