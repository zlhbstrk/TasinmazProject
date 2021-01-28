using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tasinmaz.Entities
{
    public class Durum
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; }

        [MaxLength(30)]
        public string Ad { get; } // Dışarıdan Durum tanımlaması olmayacağından DataAnnotations kullanmadım

        public ICollection<Log> tblLog {get; set; }
    }
}