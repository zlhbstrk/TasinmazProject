namespace Tasinmaz.Models
{
    public class PasswordChangeDto
    {
        public int Id { get; set; }
        public string MevcutSifre { get; set; }
        public string YeniSifre { get ; set; }
        public string YeniSifreTekrar { get; set; }
    }
}