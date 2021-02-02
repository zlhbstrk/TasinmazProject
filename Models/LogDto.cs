using Tasinmaz.Entities;

namespace Tasinmaz.Models
{
    public class LogDto
    {
        public int Id { get; set; }
        public Kullanici Kullanici { get; set; }
        public Durum Durum { get; set; }
        public IslemTip IslemTip { get; set; }
    }
}