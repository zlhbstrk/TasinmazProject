using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tasinmaz.Entities
{
    public class Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int KullaniciID { get; set; }

        [MaxLength(30)]
        [Required(ErrorMessage="Ad alanı boş geçilemez!")]
        public string KullaniciAdi { get; set; }
        public int DurumID { get; set; }
        public int IslemTipID { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage="Açıklama alanı boş geçilemez!")]
        public string Aciklama { get; set; }

        [Required(ErrorMessage="Tarih alanı boş geçilemez!"), DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:dd MMM yyyy HH:mm:ss}")]
        public DateTime Tarih { get; set; }

        [MaxLength(20)]
        [Required(ErrorMessage="Ip alanı boş geçilemez!")]
        public string IP { get; set; }
    }
}