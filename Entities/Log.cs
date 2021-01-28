using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tasinmaz.Entities
{
    public class Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; }

        [ForeignKey("Kullanici")]
        public int KullaniciID { get; }
        public Kullanici Kullanici { get; set; } 

        [MaxLength(30)]
        [Required(ErrorMessage="Ad alanı boş geçilemez!")]
        public string KullaniciAdi { get; }

        [ForeignKey("Durum")]
        public int DurumID { get; }
        public Durum Durum { get; set; } 

        [ForeignKey("IslemTip")]
        public int IslemTipID { get; }
        public IslemTip IslemTip { get; set; } 

        [MaxLength(100)]
        [Required(ErrorMessage="Açıklama alanı boş geçilemez!")]
        public string Aciklama { get; }

        [Required(ErrorMessage="Tarih alanı boş geçilemez!"), DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:dd MMM yyyy HH:mm:ss}")]
        public DateTime Tarih { get; }

        [MaxLength(20)]
        [Required(ErrorMessage="IP alanı boş geçilemez!")]
        public string IP { get; }
    }
}